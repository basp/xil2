namespace Xil2;

public interface IAggregate : INode
{
    int Size { get; }

    INode Cons(INode node);

    INode Concat(INode node);
}