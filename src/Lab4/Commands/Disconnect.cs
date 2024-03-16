using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class Disconnect : ICommand
{
    private readonly DisconnectModel _model;

    public Disconnect(DisconnectModel model)
    {
        _model = model;
    }

    public void Execute(FileSystemContext fileSystemContext)
    {
        fileSystemContext.DirectoryPath = null;
        fileSystemContext.FileSystem = null;
        fileSystemContext.Sign1 = null;
        fileSystemContext.Sign2 = null;
    }
}