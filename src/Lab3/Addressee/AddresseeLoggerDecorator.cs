using Itmo.ObjectOrientedProgramming.Lab3.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeLoggerDecorator : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly ILogger _logger;

    public AddresseeLoggerDecorator(IAddressee addressee, ILogger logger)
    {
        _addressee = addressee;
        _logger = logger;
    }

    public void DeliverMessage(Message.Message message)
    {
        _logger.SetMessage($"time: {message.DateTime} -- header: {message.Header} -- text: {message.Text} " +
                           $"-- importance level: {message.ImportanceLevel}");
        _addressee.DeliverMessage(message);
    }
}