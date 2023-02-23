namespace Xil2;

public interface INode
{
    Operator Op { get; }   

    INode Clone();

    string ToRepresentation();
}