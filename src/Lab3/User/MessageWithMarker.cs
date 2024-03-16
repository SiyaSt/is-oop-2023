namespace Itmo.ObjectOrientedProgramming.Lab3.User;

public record MessageWithMarker
{
    public MessageWithMarker(Message.Message message, bool marker)
    {
        Message = message;
        ReadMessageMarker = marker;
    }

    public Message.Message Message { get; }
    public bool ReadMessageMarker { get; set; }
}
