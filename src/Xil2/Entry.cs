namespace Xil2;

using System.Diagnostics.CodeAnalysis;

public class Entry
{
    public Entry(Action<Interpreter> action)
    {
        this.Action = action;
        this.Effect = string.Empty;
        this.Body = Array.Empty<INode>();
    }

    public Entry([NotNull] IEnumerable<INode> body)
    {
        this.Action = i => {};
        this.Effect = string.Empty;
        this.Body = body;
    }

    public Action<Interpreter> Action { get; }

    public string Effect { get; }

    public IEnumerable<INode> Body { get; }

    public bool IsUserDefined => this.Body.Any();
}