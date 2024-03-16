namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeFilterDecorator : IAddressee
{
    private readonly IAddressee _addressee;
    private ImportanceLevel _importanceLevel;

    public AddresseeFilterDecorator(IAddressee addressee, ImportanceLevel importanceLevel)
    {
        _addressee = addressee;
        _importanceLevel = importanceLevel;
    }

    public void DeliverMessage(Message.Message message)
    {
        if (message.ImportanceLevel == _importanceLevel)
        {
            _addressee.DeliverMessage(message);
        }
    }
}