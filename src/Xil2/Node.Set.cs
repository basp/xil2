namespace Xil2;

public abstract partial class Node
{
    public class Set : Node, IAggregate
    {
        public override Operator Op => throw new NotImplementedException();

        public override bool IsAggregate => true;

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
