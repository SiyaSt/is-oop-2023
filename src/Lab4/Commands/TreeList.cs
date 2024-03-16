using Itmo.ObjectOrientedProgramming.Lab4.Composite;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeList : ICommand
{
    private readonly TreeListModel _treeListModel;
    public TreeList(TreeListModel treeListModel)
    {
        _treeListModel = treeListModel;
    }

    public void Execute(FileSystemContext fileSystemContext)
    {
        var visitor = new Visitor.Visitor(fileSystemContext.Sign1, fileSystemContext.Sign2);
        IComponent? component = fileSystemContext.FileSystem?.
            TreeListComponent(_treeListModel, fileSystemContext.DirectoryPath);
        component?.Accept(visitor);
    }
}