namespace Xil2;

public interface IAggregate : INode
{
    INode Cons(INode node);

    INode Concat(INode node);
}