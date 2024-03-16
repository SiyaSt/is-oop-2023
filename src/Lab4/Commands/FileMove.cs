using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileMove : ICommand
{
    private readonly FileMoveModel _fileMoveModel;
    public FileMove(FileMoveModel fileMoveModel)
    {
        _fileMoveModel = fileMoveModel;
    }

    public void Execute(FileSystemContext fileSystemContext)
    {
        fileSystemContext.FileSystem?.FileMoveCommand(_fileMoveModel, fileSystemContext.DirectoryPath);
    }
}