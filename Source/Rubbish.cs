// SPDX-License-Identifier: MPL-2.0
namespace Emik;

/// <summary>Allows for trashing files.</summary>
public static class Rubbish
{
#if !NET5_0_OR_GREATER
    static readonly OSPlatform s_bsd = OSPlatform.Create("FREEBSD");
#endif

    /// <summary>Trashes the file.</summary>
    /// <param name="path">The path to trash.</param>
    /// <returns>
    /// The value <see langword="true"/> if the operation was successful, otherwise; <see langword="false"/>.
    /// </returns>
    public static bool Move(string path) =>
#if NET5_0_OR_GREATER
        OperatingSystem.IsWindows() ? WindowsRubbish.Move(path) :
        OperatingSystem.IsMacOS() ? OsxRubbish.Move(path) :
        (OperatingSystem.IsLinux() || OperatingSystem.IsFreeBSD()) && FreedesktopRubbish.Move(path);
#else
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? WindowsRubbish.Move(path) :
        RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? OsxRubbish.Move(path) :
        (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(s_bsd)) &&
        FreedesktopRubbish.Move(path);
#endif

    /// <summary>Trashes the file asynchronously.</summary>
    /// <param name="path">The path to trash.</param>
    /// <param name="token">The token to cancel the operation.</param>
    /// <returns>
    /// The <see cref="Task{TResult}"/> that trashes the file, returning the value <see langword="true"/>
    /// if the operation was successful, otherwise; <see langword="false"/>.
    /// </returns>
    public static async Task<bool> MoveAsync(string path, CancellationToken token = default) =>
#if NET5_0_OR_GREATER
        OperatingSystem.IsWindows() ? WindowsRubbish.Move(path) :
        OperatingSystem.IsMacOS() ? await OsxRubbish.MoveAsync(path, token) :
        (OperatingSystem.IsLinux() || OperatingSystem.IsFreeBSD()) && await FreedesktopRubbish.MoveAsync(path, token);
#else
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? WindowsRubbish.Move(path) :
        RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? OsxRubbish.Move(path) :
        (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(s_bsd)) &&
        await FreedesktopRubbish.MoveAsync(path, token);
#endif
}
