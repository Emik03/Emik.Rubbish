// SPDX-License-Identifier: MPL-2.0

using static Xunit.Assert;

// ReSharper disable once CheckNamespace
namespace Emik;

public sealed class Tests : IDisposable
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
    public void TrashFullFile()
    {
        using var temp = File.Create(NewName);

        var result = Rubbish.Move(temp.Name);

        False(result, OperationSucceeded);
        True(File.Exists(temp.Name), PathDisappeared);
    }

    [Fact]
    public void TrashRelativeFile()
    {
        using var temp = File.Create(NewName);

        var result = Rubbish.Move(temp.Name.FileName().ToString());

        False(result, OperationSucceeded);
        True(File.Exists(temp.Name), PathDisappeared);
    }

    [Fact]
    public void TrashFullDirectory()
    {
        var temp = Directory.CreateDirectory(NewName).FullName;

        var result = Rubbish.Move(temp);

        False(result, OperationSucceeded);
        True(Directory.Exists(temp), PathDisappeared);
    }

    [Fact]
    public void TrashRelativeDirectory()
    {
        var temp = Directory.CreateDirectory(NewName).Name;

        var result = Rubbish.Move(temp);

        False(result, OperationSucceeded);
        True(Directory.Exists(temp), PathDisappeared);
    }
}
