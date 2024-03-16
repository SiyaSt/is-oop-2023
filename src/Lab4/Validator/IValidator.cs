using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Validator;

public interface IValidator
{
    bool CheckFileSystemContext(string? fileSystemAddress);
    string CheckFilePath(string filePath, string? directoryPath, string? fileSystemAddress);
    string CheckDirectoryPath(string directoryPath, string? fileSystemAddress);
    bool CheckExistenceFile(FileInfo file);
    bool CheckExistenceDirectory(DirectoryInfo directory);
}