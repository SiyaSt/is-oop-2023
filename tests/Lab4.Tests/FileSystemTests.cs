using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class FileSystemTests
{
    public static IEnumerable<object[]> CommandTextLines =>
        new List<object[]>
        {
            new object[] { "connect D:\\ -m local", new Connect(new ConnectModel("D:\\", "local")) },
            new object[] { "disconnect", new Disconnect(new DisconnectModel()) },
            new object[] { "file copy \\lab1\\lab.txt \\lab2", new FileCopy(new FileCopyModel("\\lab1\\lab.txt", "\\lab2")) },
            new object[] { "file move \\lab1\\lab.txt \\lab2", new FileMove(new FileMoveModel("\\lab1\\lab.txt", "\\lab2")) },
            new object[] { "file delete \\lab1\\lab.txt", new FileDelete(new FileDeleteModel("\\lab1\\lab.txt")) },
            new object[] { "file show \\lab1\\lab.txt -m console", new FileShow(new FileShowModel("\\lab1\\lab.txt", "console")) },
            new object[] { "file rename \\lab1\\lab.txt lab2.txt", new FileRename(new FileRenameModel("\\lab1\\lab.txt", "lab2.txt")) },
            new object[] { "tree goto \\lab1", new TreeGoto(new TreeGotoModel("\\lab1")) },
            new object[] { "tree list -d 3", new TreeList(new TreeListModel(3)) },
        };
    [Theory]
    [MemberData(nameof(CommandTextLines))]
    public void ParseCommand_ShouldBeSuccessCommand_WhenWriteRightArguments(string text, ICommand command)
    {
        // Arrange
        var chain = new Chain();
        var parser = new ConsoleParser(chain.CommandChain);

        // Act
        ParseResultTypes resultTypes = parser.Parse(text);

        // Assert
        if (resultTypes is ParseResultTypes.SuccessCommand result)
        {
            Assert.Equal(command.GetType(), result.CommandResult.GetType());
        }
    }
}