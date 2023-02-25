namespace Xil2;

public interface IFloatable : INode, IComparable<IFloatable>
{
    double FloatValue { get; }

    IFloatable Add(INode node);

    IFloatable Subtract(INode node);

    IFloatable Modulo(INode node);

    IFloatable Multiply(INode node);

    IFloatable Divide(INode node);
}
