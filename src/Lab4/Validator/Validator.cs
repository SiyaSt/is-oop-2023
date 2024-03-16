using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Validator;

public class Validator : IValidator
{
    private readonly IWriter _writer = new ConsoleWriter();
    public bool CheckFileSystemContext(string? fileSystemAddress)
    {
        if (fileSystemAddress is not null) return true;
        _writer.Write("No connect to file system");
        return false;
    }

    public string CheckFilePath(string filePath, string? directoryPath, string? fileSystemAddress)
    {
        string result = directoryPath + filePath;
        if (Path.IsPathRooted(result))
        {
            result = fileSystemAddress + result;
        }

        return result;
    }

    public string CheckDirectoryPath(string directoryPath, string? fileSystemAddress)
    {
        if (Path.IsPathRooted(directoryPath))
        {
            return fileSystemAddress + directoryPath;
        }

        return directoryPath;
    }

    public bool CheckExistenceFile(FileInfo file)
    {
        if (file.Exists) return true;
        _writer.Write("No such file");
        return false;
    }

    public bool CheckExistenceDirectory(DirectoryInfo directory)
    {
        if (directory.Exists) return true;
        _writer.Write("No such directory");
        return false;
    }
}