using Itmo.ObjectOrientedProgramming.Lab3.Display;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeDisplay : IAddressee
{
    private readonly IDisplay _display;
    public AddresseeDisplay(IDisplay display)
    {
        _display = display;
    }

    public void DeliverMessage(Message.Message message)
    {
        _display.ShowText($"header--{message.Header} text--{message.Text}");
    }
}