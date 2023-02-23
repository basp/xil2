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

        public INode Add(INode node) =>
            node switch
            {
                Node.Integer y => new Node.Float(this.value + y.Value),
                Node.Float y => new Node.Float(this.value + y.Value),
                _ => throw new InvalidOperationException(),
            };

        public INode Subtract(INode node) =>
            node switch
            {
                Node.Integer y => new Node.Float(this.value - y.Value),
                Node.Float y => new Node.Float(this.value - y.Value),
                _ => throw new InvalidOperationException(),
            };

        public INode Modulo(INode node) =>
            node switch
            {
                Node.Integer y => new Node.Float(this.value % y.Value),
                Node.Float y => new Node.Float(this.value % y.Value),
                _ => throw new InvalidOperationException(),
            };

        public INode Divide(INode node) =>
            node switch
            {
                Node.Integer y => new Node.Float(this.value / y.Value),
                Node.Float y => new Node.Float(this.value / y.Value),
                _ => throw new InvalidOperationException(),
            };

        public INode Multiply(INode node) =>
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
    }
}
