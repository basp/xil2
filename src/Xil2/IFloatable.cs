namespace Xil2;

public interface IFloatable : INode
{
    INode Add(INode node);

    INode Subtract(INode node);

    INode Modulo(INode node);

    INode Multiply(INode node);

    INode Divide(INode node);
}
