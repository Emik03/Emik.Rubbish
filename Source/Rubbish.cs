// SPDX-License-Identifier: MPL-2.0
namespace Emik;

/// <summary>
/// Contains the methods <see cref="Move"/> and <see cref="MoveAsync"/> for sending files to the recycling bin.
/// </summary>
public static class Rubbish
{
    static readonly Task<bool> s_false = Task.FromResult(false);

    /// <summary>Moves the file or directory to the recycling bin.</summary>
    /// <remarks><para>Unlike other IO operations, this method does not ever throw.</para></remarks>
    /// <example><para>
    /// The following example moves the file or directory <c>test.txt</c>
    /// (which is relative to the current working directory) to the recycling bin.
    /// </para><code language="csharp">
    /// using System;
    /// using Emik;&#xa;&#xd;
    /// if (Rubbish.Move("test.txt"))
    ///     Console.WriteLine("Sent text.txt to the recycle bin.");
    /// else
    ///     Console.WriteLine("Failed to move test.txt.");
    /// </code></example>
    /// <param name="path">The path to move to the recycling bin. This can be relative or absolute.</param>
    /// <returns>
    /// The value <see langword="true"/> if the operation was successful, otherwise; <see langword="false"/>.
    /// </returns>
    public static bool Move([NotNullWhen(true)] string? path) => false;

    /// <summary>Moves the file or directory to the recycling bin asynchronously.</summary>
    /// <remarks><para>Unlike other IO operations, this method does not ever throw.</para></remarks>
    /// <example><para>
    /// The following example moves the file or directory <c>test.txt</c>
    /// (which is relative to the current working directory) to the recycling bin.
    /// </para><code language="csharp">
    /// using System;
    /// using Emik;&#xa;&#xd;
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
    public static Task<bool> MoveAsync([NotNullWhen(true)] string? path, CancellationToken token = default) => s_false;
}
