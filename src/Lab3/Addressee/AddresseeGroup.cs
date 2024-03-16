using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeGroup : IAddressee
{
    private readonly IList<IAddressee> _addressees;
    public AddresseeGroup(IList<IAddressee> addressees)
    {
        _addressees = addressees;
    }

    public void DeliverMessage(Message.Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.DeliverMessage(message);
        }
    }
}