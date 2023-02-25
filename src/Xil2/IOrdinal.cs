namespace Xil2;

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
