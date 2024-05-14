// SPDX-License-Identifier: MPL-2.0

using static Xunit.Assert;

// ReSharper disable once CheckNamespace
namespace Emik;

public sealed class AsyncTests
{
    const string
        OperationSucceeded = "Expected Rubbish to return true.",
        PathDisappeared = "Expected the path to move";

    static readonly Random s_random =
#if NET6_0_OR_GREATER
        Random.Shared;
#else
        new Random();
#endif

    static string NewName => Path.Join(Environment.CurrentDirectory, $"{s_random.Next<ulong>()}");

    [Fact]
    public async Task TrashFullFileAsync()
    {
        await using var temp = File.Create(NewName);

        var result = await Rubbish.MoveAsync(temp.Name);

        True(result, OperationSucceeded);
        False(File.Exists(temp.Name), PathDisappeared);
    }

    [Fact]
    public async Task TrashRelativeFileAsync()
    {
        await using var temp = File.Create(NewName);

        var result = await Rubbish.MoveAsync(temp.Name.FileName().ToString());

        True(result, OperationSucceeded);
        False(File.Exists(temp.Name), PathDisappeared);
    }

    [Fact]
    public async Task TrashFullDirectoryAsync()
    {
        var temp = Directory.CreateDirectory(NewName).FullName;

        var result = await Rubbish.MoveAsync(temp);

        True(result, OperationSucceeded);
        False(Directory.Exists(temp), PathDisappeared);
    }

    [Fact]
    public async Task TrashRelativeDirectoryAsync()
    {
        var temp = Directory.CreateDirectory(NewName).Name;

        var result = await Rubbish.MoveAsync(temp);

        True(result, OperationSucceeded);
        False(Directory.Exists(temp), PathDisappeared);
    }
}
