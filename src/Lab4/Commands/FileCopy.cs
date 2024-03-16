using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileCopy : ICommand
{
    private readonly FileCopyModel _fileCopyModel;
    public FileCopy(FileCopyModel fileCopyModel)
    {
        _fileCopyModel = fileCopyModel;
    }

    public void Execute(FileSystemContext fileSystemContext)
    {
        fileSystemContext.FileSystem?.FileCopyCommand(_fileCopyModel, fileSystemContext.DirectoryPath);
    }
}