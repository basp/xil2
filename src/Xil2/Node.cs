namespace Xil2;

public abstract partial class Node : INode
{
    public Position Position { get; set; }

    public abstract Operator Op { get; }

    public virtual bool IsFloatable => false;

    public virtual bool IsAggregate => false;

    public virtual bool IsOrdinal => false;

    public abstract INode Clone();

    public abstract string ToRepresentation();
}
