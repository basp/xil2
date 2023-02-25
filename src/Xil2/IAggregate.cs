namespace Xil2;

/// <summary>
/// Provides an interface for aggregate (i.e. list, string or set) nodes.
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
