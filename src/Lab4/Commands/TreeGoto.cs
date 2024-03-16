using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeGoto : ICommand
{
    private readonly TreeGotoModel _treeGotoModel;
    public TreeGoto(TreeGotoModel treeGotoModel)
    {
        _treeGotoModel = treeGotoModel;
    }

    public void Execute(FileSystemContext fileSystemContext)
    {
        fileSystemContext.DirectoryPath = _treeGotoModel.Path;
    }
}