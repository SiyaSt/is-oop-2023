using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;
[GenerateBuilder]
public partial record FileShowModel(string Path, string? Mode);