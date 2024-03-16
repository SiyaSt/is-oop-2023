using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileRename : ICommand
{
    private readonly FileRenameModel _fileRename;
    public FileRename(FileRenameModel fileRename)
    {
        _fileRename = fileRename;
    }

    public void Execute(FileSystemContext fileSystemContext)
    {
        fileSystemContext.FileSystem?.FileRenameCommand(_fileRename, fileSystemContext.DirectoryPath);
    }
}