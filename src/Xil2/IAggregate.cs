namespace Xil2;

public interface IAggregate : INode
{
    int Size { get; }

    IEnumerable<INode> Elements { get; }

    INode Cons(INode node);

    INode Concat(INode node);

    INode First();

    IAggregate Rest();
}
