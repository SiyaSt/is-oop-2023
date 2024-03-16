using Itmo.ObjectOrientedProgramming.Lab3.Messenger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeMessenger : IAddressee
{
    private IMessenger _messenger;
    public AddresseeMessenger(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void DeliverMessage(Message.Message message)
    {
        _messenger.ShowMessage($"header--{message.Header} text--{message.Text} ");
    }
}