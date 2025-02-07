namespace AspireOllama.Web;

public class Message
{
    public Message(string messageText, MessageType type)
    {
        MessageText = messageText;
        Type = type;
    }
    
    public string MessageText { get; set; }
    
    public MessageType Type { get; set; }
}

public enum MessageType
{
    Sent,
    Received,
}