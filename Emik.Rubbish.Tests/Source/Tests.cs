// SPDX-License-Identifier: MPL-2.0

using static Xunit.Assert;

// ReSharper disable once CheckNamespace
namespace Emik;

public sealed class Tests
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
    public void TrashFullFile()
    {
        using var temp = File.Create(NewName);

        var result = Rubbish.Move(temp.Name);

        True(result, OperationSucceeded);
        False(File.Exists(temp.Name), PathDisappeared);
    }

    [Fact]
    public void TrashRelativeFile()
    {
        using var temp = File.Create(NewName);

        var result = Rubbish.Move(temp.Name.FileName().ToString());

        True(result, OperationSucceeded);
        False(File.Exists(temp.Name), PathDisappeared);
    }

    [Fact]
    public void TrashFullDirectory()
    {
        var temp = Directory.CreateDirectory(NewName).FullName;

        var result = Rubbish.Move(temp);

        True(result, OperationSucceeded);
        False(Directory.Exists(temp), PathDisappeared);
    }

    [Fact]
    public void TrashRelativeDirectory()
    {
        var temp = Directory.CreateDirectory(NewName).Name;

        var result = Rubbish.Move(temp);

        True(result, OperationSucceeded);
        False(Directory.Exists(temp), PathDisappeared);
    }
}
