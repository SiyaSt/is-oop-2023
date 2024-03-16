namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public class Display : IDisplay
{
    private readonly IDisplayDriver _displayDriver;
    public Display(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void ShowText(string message)
    {
        _displayDriver.Clean();
        _displayDriver.SetMessages(message);
        _displayDriver.ShowText();
    }
}