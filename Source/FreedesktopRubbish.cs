// SPDX-License-Identifier: MPL-2.0

namespace Emik;
#pragma warning disable CA2012, CA2101, CS8500, S2178, S5034, SA1121, SA1300, SA1310, SYSLIB1054, RCS1075, RCS1187, VSTHRD002
using static SmallList;
using Slice =
#if NET6_0_OR_GREATER
    ReadOnlySpan<char>; // ReSharper disable once MissingBlankLines
#else
    string;
#endif

/// <summary>Implementation for trashing files on Linux and BSD.</summary>
/// <remarks><para>
/// This implementation attempts to use
/// <a href="https://flatpak.github.io/xdg-desktop-portal/docs/doc-org.freedesktop.portal.Trash.html">
/// <c>org.freedesktop.portal.Trash.TrashFile</c>
/// </a>, with a fallback implementation that carefully follows the specification laid out in
/// <a href="https://specifications.freedesktop.org/trash-spec/trashspec-latest.html">
/// The FreeDesktop.org Trash specification
/// </a>, Version 1.0 from January 2, 2014.
/// </para></remarks>
static partial class FreedesktopRubbish
{
    const int O_PATH = 2097152; // ReSharper disable once UseSymbolAlias

    // ReSharper disable ConvertToConstant.Local
    // Any sane person would make these constants, however in doing so it causes the compiler to
    // generate one reference for both use cases when passed as as 'in'/'ref readonly' parameters.
    // This causes unexpected mutation during the loop, and an 'IndexOutOfRangeException' is thrown.
    // For more details, see: https://github.com/dotnet/roslyn/issues/73438.
    static readonly byte s_escape = (byte)'\\', s_newLine = (byte)'\n';

    static readonly Connection? s_connection;
#if NET8_0_OR_GREATER
    static readonly SearchValues<byte> s_whitespace = SearchValues.Create([(byte)' ', (byte)'\t']);
#endif
    static readonly Trash? s_trash;

    static FreedesktopRubbish()
    {
        try
        {
            Connect(out s_connection, out s_trash);
        }
        catch (Exception)
        {
            // ignored
        }
    }

    /// <inheritdoc cref="Rubbish.Move"/>
    // ReSharper disable UseSymbolAlias
    internal static bool Move(string path) =>
        DBusMove(path) ||
        GetTrashDirectory(path) is { } trashDirectory &&
        $"{trashDirectory}/info" is var trashInfoDirectory &&
        $"{trashDirectory}/files" is var trashFilesDirectory &&
        EnsureTrashStructure(trashInfoDirectory, trashFilesDirectory) &&
        UniqueTrashName(trashInfoDirectory, trashFilesDirectory, path, out var trashInfoFile) is
            { } trashFilesFile &&
        CreateTrashInfoFile(path, trashInfoFile) &&
        Move(path, trashInfoFile, trashFilesFile);

    /// <inheritdoc cref="Rubbish.MoveAsync"/>
    internal static async Task<bool> MoveAsync(string path, CancellationToken token) =>
        await DBusMoveAsync(path) ||
        await GetTrashDirectoryAsync(path, token) is { } trashDirectory &&
        $"{trashDirectory}/info" is var trashInfoDirectory &&
        $"{trashDirectory}/files" is var trashFilesDirectory &&
        EnsureTrashStructure(trashInfoDirectory, trashFilesDirectory) &&
        UniqueTrashName(trashInfoDirectory, trashFilesDirectory, path, out var trashInfoFile) is { } trashFilesFile &&
        await CreateTrashInfoFileAsync(path, trashInfoFile, token) &&
        Move(path, trashInfoFile, trashFilesFile);

    static bool DBusMove(string path)
    {
        if (s_trash is null || open(path, O_PATH) is var preexistingHandle && preexistingHandle is -1)
            return false;

        using SafeFileHandle handle = new((nint)preexistingHandle, true);
        return s_trash.TrashFileAsync(handle).GetAwaiter().GetResult() is not 0;
    }

    static async Task<bool> DBusMoveAsync(string path)
    {
        if (s_trash is null || open(path, O_PATH) is var preexistingHandle && preexistingHandle is -1)
            return false;

        using SafeFileHandle handle = new((nint)preexistingHandle, true);
        return await s_trash.TrashFileAsync(handle) is not 0;
    }

    static string? GetTrashDirectory(string path) =>
        Environment.GetEnvironmentVariable("HOME") is var home &&
        !string.IsNullOrEmpty(home) &&
        path.StartsWith(home) &&
        path.Nth(home.Length) is '/'
            ? HomeTrash(home)
            : FindNonHomeTrash(path);

    static async Task<string?> GetTrashDirectoryAsync(string path, CancellationToken token) =>
        Environment.GetEnvironmentVariable("HOME") is var home &&
        !string.IsNullOrEmpty(home) &&
        path.StartsWith(home) &&
        path.Nth(home.Length) is '/'
            ? HomeTrash(home)
            : await FindNonHomeTrashAsync(path, token);

    static bool EnsureTrashStructure(string trashInfoDirectory, string trashFilesDirectory)
    {
        try
        {
            Directory.CreateDirectory(trashInfoDirectory);
            Directory.CreateDirectory(trashFilesDirectory);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    static string? UniqueTrashName(
        string trashInfoDirectory,
        string trashFilesDirectory,
        string path,
        out string trashInfoFile
    )
    {
        var name = Path.GetFileName(path);

        if (IsUniqueTrashName(trashInfoDirectory, trashFilesDirectory, name, out trashInfoFile, out var ret))
            return ret;

        for (var i = 2; i < int.MaxValue; i++)
        {
            var dot = name.IndexOf('.') is var first and not -1 ? first : name.Length;
#if NET6_0_OR_GREATER
            var newName = $"{name.AsSpan()[..dot]}.{i}{name.AsSpan()[dot..]}";
#else
            var newName = $"{name[..dot]}.{i}{name[dot..]}";
#endif
            if (IsUniqueTrashName(trashInfoDirectory, trashFilesDirectory, newName, out trashInfoFile, out var newRet))
                return newRet;
        }

        // ???????
        return null;
    }

    static bool CreateTrashInfoFile(string path, string trashInfoFile)
    {
        try
        {
            var contents =
                $"""
                 [Trash Info]
                 Path={path}
                 DeletionDate={DateTime.Now.ToString("s", CultureInfo.InvariantCulture)}

                 """;

            File.WriteAllText(trashInfoFile, contents);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    static async Task<bool> CreateTrashInfoFileAsync(string path, string trashInfoFile, CancellationToken token)
    {
        try
        {
            var contents =
                $"""
                 [Trash Info]
                 Path={path}
                 DeletionDate={DateTime.Now.ToString("s", CultureInfo.InvariantCulture)}

                 """;

            await File.WriteAllTextAsync(trashInfoFile, contents, token);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    static bool Move(string path, string trashInfoFile, string trashFilesFile)
    {
        try
        {
            Directory.Move(path, trashFilesFile);
            return true;
        }
        catch (Exception)
        {
            try
            {
                File.Delete(trashInfoFile);
                return false;
            }
            catch (Exception)
            {
                // This leaves an artifact in the trash directory, but it's not like we can do anything about it.
                return false;
            }
        }
    }

    static string HomeTrash(string home) =>
        Environment.GetEnvironmentVariable("XDG_DATA_HOME") is var dataHome && !string.IsNullOrEmpty(dataHome)
            ? $"{dataHome}/Trash"
            : $"{home}/.local/share/Trash";

    static string? FindNonHomeTrash(string path) =>
        CreateTrashDirectory(FindMountOfPath(Path.GetFullPath(path), ReadMounts()));

    static async Task<string?> FindNonHomeTrashAsync(string path, CancellationToken token) =>
        CreateTrashDirectory(FindMountOfPath(Path.GetFullPath(path), await ReadMountsAsync(token)));

    static bool IsUniqueTrashName(
        string trashInfoDirectory,
        string trashFilesDirectory,
        string name,
        out string trashInfoFile,
        out string trashFilesFile
    ) =>
        !File.Exists(trashFilesFile = trashInfoFile = $"{trashInfoDirectory}/{name}.trashinfo") &&
        !File.Exists(trashFilesFile = $"{trashFilesDirectory}/{name}");

    static string? CreateTrashDirectory(Slice mount)
    {
        if (mount is "")
            return null;

        if (Directory.Exists($"{mount}/.Trash"))
            try
            {
                var directory = $"{mount}/.Trash/{geteuid()}";
                Directory.CreateDirectory(directory);
                return directory;
            }
            catch (Exception)
            {
                // ignored
            }

        try
        {
            var directory = $"{mount}/.Trash-{geteuid()}";
            Directory.CreateDirectory(directory);
            return directory;
        }
        catch (Exception)
        {
            return null;
        }
    }

    static byte[] ReadMounts()
    {
        try
        {
            return File.ReadAllBytes("/proc/mounts");
        }
        catch (Exception)
        {
            try
            {
                return File.ReadAllBytes("/etc/mtab");
            }
            catch (Exception)
            {
                return [];
            }
        }
    }

    static async Task<byte[]> ReadMountsAsync(CancellationToken token)
    {
        try
        {
            return await File.ReadAllBytesAsync("/proc/mounts", token);
        }
        catch (Exception)
        {
            try
            {
                return await File.ReadAllBytesAsync("/etc/mtab", token);
            }
            catch (Exception)
            {
                return [];
            }
        }
    }

    // ReSharper disable once CognitiveComplexity
    static Slice FindMountOfPath(string fullPath, byte[] mountTable)
    {
        ReadOnlySpan<byte> longest = default; // ReSharper disable once ConvertToConstant.Local
        var entries = mountTable.AsSpan().SplitOn(s_newLine);
        var fullPathBytes = Encoding.UTF8.GetBytes(fullPath).AsSpan();
        using var unescaped = New4<byte>();

        foreach (var entry in entries)
        {
            unescaped.AsRef.Length = 0;

            if (entry is [(byte)'#', ..])
                continue;
#if NET8_0_OR_GREATER
            var escaped = entry.SplitOn(s_whitespace)[1];
#else
            var escaped = entry.SplitAny([(byte)' ', (byte)'\t'])[1];
#endif // ReSharper disable once ConvertToConstant.Local
            var (first, rest) = escaped.SplitOn(s_escape);

            if (!fullPathBytes.StartsWith(first))
                continue;

            unescaped.Append(first);

            foreach (var part in rest)
            {
                var octal = (part[0] - '0') * 64 + (part[1] - '0') * 8 + (part[2] - '0');
                unescaped.Append((byte)octal);
                unescaped.Append(part[3..]);
            }

            if (unescaped[^1] is not (byte)'/')
                unescaped.Append((byte)'/');

            if (unescaped.Length > longest.Length && fullPathBytes.StartsWith(unescaped.View))
                longest = fullPathBytes[..unescaped.Length];
        }

        return Encoding.UTF8.GetString(longest);
    }

    static void Connect(out Connection? connection, out Trash? trash)
    {
        if (Address.Session is not { } session)
        {
            connection = null;
            trash = null;
            return;
        }

        connection = new(session);
        var task = connection.ConnectAsync();
        task.GetAwaiter().GetResult();

        while (!task.IsCompleted)
            Thread.Sleep(1);

        if (!task.IsCompletedSuccessfully)
        {
            connection = null;
            trash = null;
            return;
        }

        AppDomain.CurrentDomain.ProcessExit += Disconnect;

        trash = new DesktopService(connection, "org.freedesktop.portal.Desktop")
           .CreateTrash("/org/freedesktop/portal/desktop");
    }

    static void Disconnect(object? _, EventArgs? __)
    {
        try
        {
            s_connection?.DisconnectedAsync().GetAwaiter().GetResult();
        }
        catch (Exception)
        {
            // ignored
        }
    }

#if NET7_0_OR_GREATER
    [LibraryImport("c", EntryPoint = nameof(geteuid))]
    private static partial uint geteuid();

    [LibraryImport("c", EntryPoint = nameof(open), StringMarshalling = StringMarshalling.Utf8)]
    private static partial int open(string pathname, int flags);
#else
    [DllImport("c", CallingConvention = CallingConvention.Cdecl, EntryPoint = nameof(geteuid), ExactSpelling = true)]
    static extern uint geteuid();

    [DllImport(
        "c",
        CallingConvention = CallingConvention.Cdecl,
        CharSet = CharSet.Ansi,
        EntryPoint = nameof(open),
        ExactSpelling = true
    )]
    static extern int open(string pathname, int flags);
#endif
}
