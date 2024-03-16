using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

[GenerateBuilder]
public partial record FileSystemContext(string? DirectoryPath, IFileSystem? FileSystem, string? Sign1, string? Sign2)
{
    public string? DirectoryPath { get; set; } = DirectoryPath;
    public IFileSystem? FileSystem { get; set; } = FileSystem;
    public string? Sign1 { get; set; } = Sign1;
    public string? Sign2 { get; set; } = Sign2;
}
