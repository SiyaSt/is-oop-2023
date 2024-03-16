using Itmo.ObjectOrientedProgramming.Lab3.Addressee;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topic;

public class Topic : ITopic
{
    public Topic(string header, IAddressee addressee)
    {
        Header = header;
        Addressee = addressee;
    }

    public string Header { get; }
    public IAddressee Addressee { get; }

    public void GetMessage(Message.Message message)
    {
        Addressee.DeliverMessage(message);
    }
}