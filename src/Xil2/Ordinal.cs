namespace Xil2;

public abstract class Ordinal : Node, IOrdinal
{
    public abstract int InternalValue { get; }

    public IOrdinal Min(IOrdinal node) =>
        this.InternalValue <= node.InternalValue
            ? this
            : node;

    public IOrdinal Max(IOrdinal node) =>
        this.InternalValue >= node.InternalValue
            ? this
            : node;

    public int CompareTo(IOrdinal? other)
    {
        if (other == null)
        {
            return 1;
        }

        return this.InternalValue.CompareTo(other.InternalValue);
    }

    public abstract IOrdinal Ord();

    public abstract IOrdinal Chr();

    public abstract IOrdinal Succ();

    public abstract IOrdinal Pred();
}