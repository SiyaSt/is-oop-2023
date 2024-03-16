using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Reader;

public class ConsoleReader : IReader
{
    public string? Read()
    {
        string? text = Console.ReadLine();
        return text;
    }
}