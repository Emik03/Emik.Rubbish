// SPDX-License-Identifier: MPL-2.0
namespace Emik;

/// <summary>
/// Contains the methods <see cref="Move"/> and <see cref="MoveAsync"/> for sending files to the recycling bin.
/// </summary>
public static class Rubbish
{
#if !NET5_0_OR_GREATER
    static readonly OSPlatform s_bsd = OSPlatform.Create("FREEBSD");
#endif

    /// <summary>Moves the file or directory to the recycling bin.</summary>
    /// <remarks><para>Unlike other IO operations, this method does not ever throw.</para></remarks>
    /// <example><para>
    /// The following example moves the file or directory <c>test.txt</c>
    /// (which is relative to the current working directory) to the recycling bin.
    /// </para><code language="csharp">
    /// using System;
    /// using Emik;
    /// &#0;
    /// if (Rubbish.Move("test.txt"))
    ///     Console.WriteLine("Sent text.txt to the recycle bin.");
    /// else
    ///     Console.WriteLine("Failed to move test.txt.");
    /// </code></example>
    /// <param name="path">The path to move to the recycling bin. This can be relative or absolute.</param>
    /// <returns>
    /// The value <see langword="true"/> if the operation was successful, otherwise; <see langword="false"/>.
    /// </returns>
    public static bool Move([NotNullWhen(true)] string? path) =>
        path is not null &&
#if NET5_0_OR_GREATER
        (OperatingSystem.IsWindows() ? WindowsRubbish.Move(path) :
        OperatingSystem.IsMacOS() ? OsxRubbish.Move(path) :
        (OperatingSystem.IsLinux() || OperatingSystem.IsFreeBSD()) && FreedesktopRubbish.Move(path));
#else
        (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? WindowsRubbish.Move(path) :
        RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? OsxRubbish.Move(path) :
        (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(s_bsd)) &&
        FreedesktopRubbish.Move(path));
#endif

    /// <summary>Moves the file or directory to the recycling bin asynchronously.</summary>
    /// <remarks><para>Unlike other IO operations, this method does not ever throw.</para></remarks>
    /// <example><para>
    /// The following example moves the file or directory <c>test.txt</c>
    /// (which is relative to the current working directory) to the recycling bin.
    /// </para><code language="csharp">
    /// using System;
    /// using Emik;
    /// &#0;
    /// if (await Rubbish.MoveAsync("test.txt"))
    ///     Console.WriteLine("Sent text.txt to the recycle bin.");
    /// else
    ///     Console.WriteLine("Failed to move test.txt.");
    /// </code></example>
    /// <param name="path">The path to move to the recycling bin. This can be relative or absolute.</param>
    /// <param name="token">The token to cancel the operation.</param>
    /// <returns>
    /// The <see cref="Task{TResult}"/> responsible for the operation, returning the value <see langword="true"/>
    /// if the operation was successful, otherwise; <see langword="false"/>.
    /// </returns>
    public static async Task<bool> MoveAsync([NotNullWhen(true)] string? path, CancellationToken token = default) =>
        path is not null &&
#if NET5_0_OR_GREATER
        (OperatingSystem.IsWindows() ? WindowsRubbish.Move(path) :
        OperatingSystem.IsMacOS() ? await OsxRubbish.MoveAsync(path, token) :
        (OperatingSystem.IsLinux() || OperatingSystem.IsFreeBSD()) && await FreedesktopRubbish.MoveAsync(path, token));
#else
        (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? WindowsRubbish.Move(path) :
        RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? OsxRubbish.Move(path) :
        (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(s_bsd)) &&
        await FreedesktopRubbish.MoveAsync(path, token));
#endif
}
