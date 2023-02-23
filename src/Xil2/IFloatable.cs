namespace Xil2;

public interface IFloatable : INode
{
    public INode Add(INode node);

    public INode Subtract(INode node);

    public INode Multiply(INode node);

    public INode Divide(INode node);
}
