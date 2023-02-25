namespace Xil2;

/// <summary>
/// Provides an interface for ordinals (i.e. int, char, bool).
/// </summary>
public interface IOrdinal : INode, IComparable<IOrdinal>
{
    int OrdinalValue { get; }

    IOrdinal Ord();

    IOrdinal Chr();

    IOrdinal Succ();

    IOrdinal Pred();

    IOrdinal Min(IOrdinal node);

    IOrdinal Max(IOrdinal node);
}
