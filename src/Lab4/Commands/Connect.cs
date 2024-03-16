using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class Connect : ICommand
{
    private string _address;
    private string? _mode;

    public Connect(ConnectModel connectModel)
    {
        _address = connectModel.Address;
        _mode = connectModel.Mode;
    }

    public void Execute(FileSystemContext fileSystemContext)
    {
        if (_mode is "local")
        {
            fileSystemContext.FileSystem = new FileSystem.LocalFileSystem(_address);
        }
    }
}