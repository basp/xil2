namespace Joy;

public struct Position
{
    public int Line;

    public int Column;
}

public abstract partial class Node : INode
{
    public Position Position { get; set; }

    public abstract Operator Op { get; }

    public abstract INode Clone();

    public abstract string ToRepresentation();
}
