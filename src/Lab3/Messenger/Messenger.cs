namespace Itmo.ObjectOrientedProgramming.Lab3.Messenger;

public class Messenger : IMessenger
{
    private readonly IMessengerDriver _messengerDriver;
    private string? _message;

    public Messenger(IMessengerDriver messengerDriver)
    {
        _messengerDriver = messengerDriver;
    }

    public void ShowMessage(string message)
    {
        _message = message + _messengerDriver.AddSub();
        _messengerDriver.ShowMessage(message);
    }
}