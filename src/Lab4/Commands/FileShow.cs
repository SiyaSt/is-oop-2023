using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileShow : ICommand
{
    private readonly FileShowModel _fileShowModel;
    public FileShow(FileShowModel fileShowModel)
    {
        _fileShowModel = fileShowModel;
    }

    public void Execute(FileSystemContext fileSystemContext)
    {
        fileSystemContext.FileSystem?.FileShowCommand(_fileShowModel, fileSystemContext.DirectoryPath);
    }
}