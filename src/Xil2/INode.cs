namespace Xil2;

public interface INode
{
    Operator Op { get; }   

    INode Clone();

    bool IsFloatable { get; }

    bool IsAggregate { get; }

    bool IsOrdinal { get; }

    string ToRepresentation();
}
