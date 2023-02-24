namespace Xil2;

public class Entry
{
    public Entry(Action<Interpreter> action, bool isUserDefined = false)
    {
        this.Action = action;
        this.IsUserDefined = isUserDefined;
        this.Effect = string.Empty;
    }

    public Action<Interpreter> Action { get; }

    public string Effect { get; }

    public bool IsUserDefined {get; }
}