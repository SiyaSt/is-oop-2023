using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messenger;

public class MessengerDriver : IMessengerDriver
{
    public string AddSub()
    {
        return "-- messenger";
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}