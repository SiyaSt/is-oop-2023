using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;
[GenerateBuilder]
public partial record FileCopyModel(string SourcePath, string DestinationPath);