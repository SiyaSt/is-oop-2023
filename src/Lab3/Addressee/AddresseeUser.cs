namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeUser : IAddressee
{
    private readonly User.User _user;
    public AddresseeUser(User.User user)
    {
        _user = user;
    }

    public void DeliverMessage(Message.Message message)
    {
        _user.SetMessage(message);
    }
}