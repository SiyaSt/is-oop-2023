using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logger;

public class Logger : ILogger
{
    public void SetMessage(string message)
    {
        Console.WriteLine(message);
    }
}