using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Composite;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Validator;
using Itmo.ObjectOrientedProgramming.Lab4.Writer;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Composite.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class LocalFileSystem : IFileSystem
{
    private readonly string? _fileSystemAddress;
    private readonly IWriter _writer = new ConsoleWriter();
    public LocalFileSystem(string fileSystemAddress)
    {
        _fileSystemAddress = fileSystemAddress;
    }

    public IValidator Validator { get; } = new Validator.Validator();

    public void FileCopyCommand(FileCopyModel fileCopyModel, string? currentDirectoryPath)
    {
        string filePath = fileCopyModel.SourcePath;
        string directoryPath = fileCopyModel.DestinationPath;

        if (Validator.CheckFileSystemContext(_fileSystemAddress) is false) return;
        filePath = Validator.CheckFilePath(filePath, currentDirectoryPath, _fileSystemAddress);
        directoryPath = Validator.CheckDirectoryPath(directoryPath, _fileSystemAddress);

        var file = new FileInfo(filePath);
        var directory = new DirectoryInfo(directoryPath);

        if (Validator.CheckExistenceFile(file) is false) return;
        if (Validator.CheckExistenceDirectory(directory) is false) return;

        filePath = CreateNewFilePath(file, fileCopyModel.DestinationPath);
        file.CopyTo(filePath);
    }

    public void FileMoveCommand(FileMoveModel fileMoveModel, string? currentDirectoryPath)
    {
        string filePath = fileMoveModel.SourcePath;
        string directoryPath = fileMoveModel.DestinationPath;

        if (Validator.CheckFileSystemContext(_fileSystemAddress) is false) return;
        filePath = Validator.CheckFilePath(filePath, currentDirectoryPath, _fileSystemAddress);
        directoryPath = Validator.CheckDirectoryPath(directoryPath, _fileSystemAddress);

        var file = new FileInfo(filePath);
        var directory = new DirectoryInfo(directoryPath);

        if (Validator.CheckExistenceFile(file) is false) return;
        if (Validator.CheckExistenceDirectory(directory) is false) return;

        filePath = CreateNewFilePath(file, fileMoveModel.DestinationPath);
        file.MoveTo(filePath);
    }

    public void FileShowCommand(FileShowModel fileShowModel, string? currentDirectoryPath)
    {
        string filePath = fileShowModel.Path;
        if (Validator.CheckFileSystemContext(_fileSystemAddress) is false) return;
        filePath = Validator.CheckFilePath(filePath, currentDirectoryPath, _fileSystemAddress);

        string fileText = File.ReadAllText(filePath);
        _writer.Write(fileText);
    }

    public void FileRenameCommand(FileRenameModel fileRenameModel, string? currentDirectoryPath)
    {
        string filePath = fileRenameModel.Path;
        if (Validator.CheckFileSystemContext(_fileSystemAddress) is false) return;
        filePath = Validator.CheckFilePath(filePath, currentDirectoryPath, _fileSystemAddress);

        var file = new FileInfo(filePath);
        string? directoryPath = file.DirectoryName;
        var newFile = new FileInfo(directoryPath + '\\' + fileRenameModel.Name);
        if (newFile.Exists)
        {
            newFile = new FileInfo(CreateNewFilePath(newFile, fileRenameModel.Path));
        }

        File.Move(filePath, newFile.FullName);
    }

    public void FileDeleteCommand(FileDeleteModel fileDeleteModel, string? currentDirectoryPath)
    {
        string filePath = fileDeleteModel.Path;
        if (Validator.CheckFileSystemContext(_fileSystemAddress) is false) return;

        filePath = Validator.CheckFilePath(filePath, currentDirectoryPath, _fileSystemAddress);

        var file = new FileInfo(filePath);
        if (Validator.CheckExistenceFile(file) is false) return;

        file.Delete();
    }

    public Directory? TreeListComponent(TreeListModel treeListModel, string? currentDirectoryPath)
    {
        Directory? component = null;
        if (Validator.CheckFileSystemContext(_fileSystemAddress) is false) return null;

        if (_fileSystemAddress is null) return component;
        var directory = new DirectoryInfo(_fileSystemAddress);
        if (currentDirectoryPath?.Contains(_fileSystemAddress, StringComparison.Ordinal) is false)
        {
            directory = new DirectoryInfo(_fileSystemAddress + currentDirectoryPath);
        }

        component = new Directory(directory.Name);
        OutputTree(directory, component, treeListModel.Depth);

        return component;
    }

    private static string CreateNewFilePath(FileInfo file, string path)
    {
        string newFilePath = path + '\\' + file.Name;
        var newFile = new FileInfo(newFilePath);
        int counter = 1;
        while (newFile.Exists)
        {
            newFilePath = path + '\\' + '[' + counter + ']' + newFile.Name;
            newFile = new FileInfo(newFilePath);
            counter++;
        }

        return newFilePath;
    }

    private IComponent OutputTree(DirectoryInfo directory, IComponent component, int depth)
    {
        depth -= 1;
        if (depth < 0)
        {
            return component;
        }

        foreach (DirectoryInfo dir in directory.GetDirectories())
        {
            if (dir.GetDirectories().Length > 0)
            {
                component.Add(OutputTree(dir, new Directory(dir.Name), depth));
            }
            else
            {
                component.Add(new Directory(dir.Name));
            }
        }

        return component;
    }
}