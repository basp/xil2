namespace Xil2;

public abstract partial class Node
{
    /// <summary>
    /// Represents a set node in the interpreter.
    /// </summary>
    public class Set : Node, IAggregate
    {
        public override Operand Op => throw new NotImplementedException();

        public override bool IsAggregate => true;

        public int Size => throw new NotImplementedException();

        public IEnumerable<INode> Elements => throw new NotImplementedException();

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

        public INode First()
        {
            throw new NotImplementedException();
        }

        public IAggregate Rest()
        {
            throw new NotImplementedException();
        }

        public override string ToRepresentation()
        {
            throw new NotImplementedException();
        }
    }
}
