// SPDX-License-Identifier: MPL-2.0

using static Xunit.Assert;

// ReSharper disable once CheckNamespace
namespace Emik;

public sealed class AsyncTests : IDisposable
{
    const string
        OperationSucceeded = "Expected Rubbish to return false.",
        PathDisappeared = "Expected the path to not move";

    public string NewName { get; } = Path.Join(Environment.CurrentDirectory, "0");

    /// <inheritdoc />
    public void Dispose()
    {
        if (File.Exists(NewName))
            File.Delete(NewName);
        else
            Directory.Delete(NewName);
    }

    [Fact]
    public async Task TrashFullFileAsync()
    {
        await using var temp = File.Create(NewName);

        var result = await Rubbish.MoveAsync(temp.Name);

        False(result, OperationSucceeded);
        True(File.Exists(temp.Name), PathDisappeared);
    }

    [Fact]
    public async Task TrashRelativeFileAsync()
    {
        await using var temp = File.Create(NewName);

        var result = await Rubbish.MoveAsync(temp.Name.FileName().ToString());

        False(result, OperationSucceeded);
        True(File.Exists(temp.Name), PathDisappeared);
    }

    [Fact]
    public async Task TrashFullDirectoryAsync()
    {
        var temp = Directory.CreateDirectory(NewName).FullName;

        var result = await Rubbish.MoveAsync(temp);

        False(result, OperationSucceeded);
        True(Directory.Exists(temp), PathDisappeared);
    }

    [Fact]
    public async Task TrashRelativeDirectoryAsync()
    {
        var temp = Directory.CreateDirectory(NewName).Name;

        var result = await Rubbish.MoveAsync(temp);

        False(result, OperationSucceeded);
        True(Directory.Exists(temp), PathDisappeared);
    }
}
