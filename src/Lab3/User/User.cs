using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab3.User;

public class User
{
    public User()
    {
        Messages = new List<MessageWithMarker>();
    }

    public IList<MessageWithMarker> Messages { get; private set; }

    public void SetMessage(Message.Message message)
    {
        Messages.Add(new MessageWithMarker(message, false));
    }

    public MessageIsRead ReadMessage(string header)
    {
        MessageWithMarker? newMessage = Messages.FirstOrDefault(x => x.Message.Header == header);
        if (newMessage is not null)
        {
            if (newMessage.ReadMessageMarker is false)
            {
                newMessage.ReadMessageMarker = true;
            }
            else
            {
                return new MessageIsRead.ErrorRead();
            }
        }

        return new MessageIsRead.SuccessfulRead();
    }
}