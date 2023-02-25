namespace Xil2;

/// <summary>
/// Provides an interface for floatable (i.e. int or float) nodes.
/// </summary>
public interface IFloatable : INode, IComparable<IFloatable>
{
    double FloatValue { get; }

    IFloatable Add(INode node);

    IFloatable Subtract(INode node);

    IFloatable Modulo(INode node);

    IFloatable Multiply(INode node);

    IFloatable Divide(INode node);
}
