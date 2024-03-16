namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public interface IDisplayDriver
{
    public void SetMessages(string message);
    public void Clean();
    public void ShowText();
}