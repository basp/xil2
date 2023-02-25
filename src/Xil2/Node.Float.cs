namespace Xil2;

using System.Globalization;

public abstract partial class Node
{
    /// <summary>
    /// Represents a floating point node in the interpreter.
    /// </summary>
    public class Float : Node, IFloatable
    {
        private double value;

        public Float(double value)
        {
            this.value = value;
        }

        public double Value => this.value;

        public override Operand Op => Operand.Float;

        public override bool IsFloatable => true;

        public double FloatValue => this.value;

        public IFloatable Add(INode node) =>
            node switch
            {
                Node.Integer y => new Node.Float(this.value + y.Value),
                Node.Float y => new Node.Float(this.value + y.Value),
                _ => throw new InvalidOperationException(),
            };

        public IFloatable Subtract(INode node) =>
            node switch
            {
                Node.Integer y => new Node.Float(this.value - y.Value),
                Node.Float y => new Node.Float(this.value - y.Value),
                _ => throw new InvalidOperationException(),
            };

        public IFloatable Modulo(INode node) =>
            node switch
            {
                Node.Integer y => new Node.Float(this.value % y.Value),
                Node.Float y => new Node.Float(this.value % y.Value),
                _ => throw new InvalidOperationException(),
            };

        public IFloatable Divide(INode node) =>
            node switch
            {
                Node.Integer y => new Node.Float(this.value / y.Value),
                Node.Float y => new Node.Float(this.value / y.Value),
                _ => throw new InvalidOperationException(),
            };

        public IFloatable Multiply(INode node) =>
            node switch
            {
                Node.Integer y => new Node.Float(this.value * y.Value),
                Node.Float y => new Node.Float(this.value * y.Value),
                _ => throw new InvalidOperationException(),
            };

        public override INode Clone() =>
            new Node.Float(this.value);

        public override string ToString() =>
            $"Float({this.ToRepresentation()})";

        public override string ToRepresentation() =>
            this.value.ToString(new CultureInfo("en-US"));

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
