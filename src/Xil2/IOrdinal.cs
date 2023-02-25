namespace Xil2;

public interface IOrdinal : IComparable<IOrdinal>
{
    int InternalValue { get; }

    IOrdinal Ord();

    IOrdinal Chr();

    IOrdinal Succ();

    IOrdinal Pred();

    IOrdinal Min(IOrdinal node);

    IOrdinal Max(IOrdinal node);
}
