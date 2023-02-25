namespace Xil2;

/// <summary>
/// Provides an interface for aggregates (i.e. list, string or set).
/// </summary>
public interface IAggregate : INode
{
    int Size { get; }

    IEnumerable<INode> Elements { get; }

    INode Cons(INode node);

    INode Concat(INode node);

    INode First();

    IAggregate Rest();
}
