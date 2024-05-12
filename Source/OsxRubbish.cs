// SPDX-License-Identifier: MPL-2.0
namespace Emik;

/// <summary>Implementation for trashing files on macOS.</summary>
static class OsxRubbish
{
    /// <inheritdoc cref="Rubbish.Move"/>
    internal static bool Move(string path)
    {
        using var process = CreateProcess(path);

        if (process is null)
            return false;

        process.WaitForExit();
        return process.ExitCode is 0;
    }
#if NET5_0_OR_GREATER
    /// <inheritdoc cref="Rubbish.MoveAsync"/>
    internal static async Task<bool> MoveAsync(string path, CancellationToken token)
    {
        using var process = CreateProcess(path);

        if (process is null)
            return false;

        await process.WaitForExitAsync(token);
        return process.ExitCode is 0;
    }
#endif
    static Process? CreateProcess(string path)
    {
        ProcessStartInfo info =
#if NET8_0_OR_GREATER
            new("osascript", ["-e", $"tell application \"Finder\" to delete POSIX file \"{Escape(path)}\""])
#else
            new("osascript")
#endif
            {
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
            };
#if !NET8_0_OR_GREATER
        info.ArgumentList.Add("-e");
        info.ArgumentList.Add($"tell application \"Finder\" to delete POSIX file \"{Escape(path)}\"");
#endif
        return Process.Start(info);
    }

    static string Escape(string path) =>
        new StringBuilder(path)
           .Replace("\\", @"\\")
           .Replace("\"", "\\\"")
           .Replace("\n", "\\n")
           .Replace("\r", "\\r")
           .Replace("\t", "\\t")
           .ToString();
}
