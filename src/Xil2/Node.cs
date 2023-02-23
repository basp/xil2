namespace Xil2;

public abstract partial class Node : INode
{
    public Position Position { get; set; }

    public abstract Operator Op { get; }

    public virtual bool IsFloatable => false;

    public virtual bool IsAggregate => false;

    public virtual bool IsOrdinal => false;

    public static bool IsZero(INode node) =>
        node switch
        {
            Node.Boolean x => x.Value ? false : true,
            Node.Integer x => x.Value == 0,
            Node.Float x => x.Value == 0,
            _ => false,
        };

    public static bool IsTruthy(INode node) =>
        node switch
        {
            Node.Boolean x => x.Value,
            Node.Integer x => !IsZero(x),
            Node.Float x => !IsZero(x),
            Node.List x => x.Size > 0,
            _ => true,
        };

    public abstract INode Clone();

    public abstract string ToRepresentation();
}
