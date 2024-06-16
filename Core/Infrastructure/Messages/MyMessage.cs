namespace Core;

public class MyMessage : ValueChangedMessage<string>
{
    public MyMessage(string value) : base(value)
    {
    }
}
