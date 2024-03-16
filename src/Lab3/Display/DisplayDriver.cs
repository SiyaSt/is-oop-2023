using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public class DisplayDriver : IDisplayDriver
{
    private string? _message;
    private Color _color;

    public DisplayDriver(Color color)
    {
        _color = color;
    }

    public void SetMessages(string message)
    {
        _message = message;
    }

    public void Clean()
    {
        _message = null;
        Console.Clear();
    }

    public void ShowText()
    {
        Console.WriteLine(Crayon.Output.Rgb(_color.R, _color.G, _color.B)
            .Text($"display{_message}"));
    }
}