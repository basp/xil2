namespace Xil2;

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

    public class Set : Node, IAggregate
    {
        public override Operator Op => throw new NotImplementedException();

        public override INode Clone()
        {
            throw new NotImplementedException();
        }

        public INode Concat(INode node)
        {
            throw new NotImplementedException();
        }

        public INode Cons(INode node)
        {
            throw new NotImplementedException();
        }

        public override string ToRepresentation()
        {
            throw new NotImplementedException();
        }
    }
}
