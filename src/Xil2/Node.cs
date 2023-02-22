namespace Joy;

public abstract partial class Node : INode
{
    public abstract Operator Op { get; }

    public abstract INode Clone();
}
