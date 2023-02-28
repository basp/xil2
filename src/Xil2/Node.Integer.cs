namespace Xil2;


public abstract partial class Node
{
    /// <summary>
    /// Represents an integer node in the interpreter.
    /// </summary>
    public class Integer : Ordinal, IFloatable
    {
        private readonly int value;

        public Integer(int value)
        {
            this.value = value;
        }

        public int Value => this.value;

        public override Operand Op => Operand.Integer;

        public override bool IsFloatable => true;

        public override bool IsOrdinal => true;

        public override int OrdinalValue => this.value;

        public double FloatValue => this.value;

        public IFloatable Add(INode node) =>
            node switch
            {
                Node.Integer y => new Node.Integer(this.value + y.Value),
                Node.Float y => new Node.Float(this.value + y.Value),
                _ => throw new InvalidOperationException(),
            };

        public IFloatable Subtract(INode node) =>
            node switch
            {
                Node.Integer y => new Node.Integer(this.value - y.Value),
                Node.Float y => new Node.Float(this.value - y.Value),
                _ => throw new InvalidOperationException(),
            };

        public IFloatable Modulo(INode node) =>
            node switch
            {
                Node.Integer y => new Node.Integer(this.value % y.Value),
                Node.Float y => new Node.Float(this.value % y.Value),
                _ => throw new InvalidOperationException(),
            };

        public IFloatable Divide(INode node) =>
            node switch
            {
                Node.Integer y => new Node.Integer(this.value / y.Value),
                Node.Float y => new Node.Float(this.value / y.Value),
                _ => throw new InvalidOperationException(),
            };

        public IFloatable Multiply(INode node) =>
            node switch
            {
                Node.Integer y => new Node.Integer(this.value * y.value),
                Node.Float y => new Node.Float(this.value * y.Value),
                _ => throw new InvalidOperationException(),
            };

        public override INode Clone() =>
            new Node.Integer(this.value);

        public override string ToString() =>
            $"Integer({this.ToRepresentation()})";

        public override string ToRepresentation() =>
            this.value.ToString();

        public override IOrdinal Chr() => new Node.Char((char)this.value);

        public override IOrdinal Ord() => new Node.Integer(this.value);

        public override IOrdinal Succ() => new Node.Integer(this.value + 1);

        public override IOrdinal Pred() => new Node.Integer(this.value - 1);

        public override bool Equals(object? obj)
        {
            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            var other = obj as Integer;
            if (other == null)
            {
                return false;
            }

            return this.value == other.value;
        }

        public override int GetHashCode() =>
            HashCode.Combine(Tags.Integer, this.value.GetHashCode());

        public int CompareTo(IFloatable? other)
        {
            if (other == null)
            {
                return 1;
            }

            return this.FloatValue.CompareTo(other.FloatValue);
        }
    }
}
