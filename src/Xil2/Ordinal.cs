namespace Xil2;

public abstract class Ordinal : Node, IOrdinal
{
    public abstract int OrdinalValue { get; }

    public IOrdinal Min(IOrdinal node) =>
        this.OrdinalValue <= node.OrdinalValue
            ? this
            : node;

    public IOrdinal Max(IOrdinal node) =>
        this.OrdinalValue >= node.OrdinalValue
            ? this
            : node;

    public int CompareTo(IOrdinal? other)
    {
        if (other == null)
        {
            return 1;
        }

        return this.OrdinalValue.CompareTo(other.OrdinalValue);
    }

    public abstract IOrdinal Ord();

    public abstract IOrdinal Chr();

    public abstract IOrdinal Succ();

    public abstract IOrdinal Pred();
}