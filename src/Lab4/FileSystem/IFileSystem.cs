using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Validator;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public interface IFileSystem
{
    public IValidator Validator { get; }
    void FileCopyCommand(FileCopyModel fileCopyModel, string? currentDirectoryPath);
    void FileMoveCommand(FileMoveModel fileMoveModel, string? currentDirectoryPath);
    void FileShowCommand(FileShowModel fileShowModel, string? currentDirectoryPath);
    void FileRenameCommand(FileRenameModel fileRenameModel, string? currentDirectoryPath);
    void FileDeleteCommand(FileDeleteModel fileDeleteModel, string? currentDirectoryPath);
    Composite.Directory? TreeListComponent(TreeListModel treeListModel, string? currentDirectoryPath);
}