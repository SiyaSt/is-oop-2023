using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileDelete : ICommand
{
    private readonly FileDeleteModel _fileDeleteModel;
    public FileDelete(FileDeleteModel fileDeleteModel)
    {
        _fileDeleteModel = fileDeleteModel;
    }

    public void Execute(FileSystemContext fileSystemContext)
    {
        fileSystemContext.FileSystem?.FileDeleteCommand(_fileDeleteModel, fileSystemContext.DirectoryPath);
    }
}