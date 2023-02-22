using System.Globalization;

namespace Joy;

public abstract partial class Node
{
    public class Float : Node, IFloatable
    {
        private double value;

        public Float(double value)
        {
            this.value = value;
        }

        public double Value => this.value;

        public override Operator Op => Operator.Float;


        public INode Add(INode node) =>
            node switch
            {
                Node.Integer y => new Node.Float(this.value + y.Value),
                Node.Float y => new Node.Float(this.value + y.Value),
                _ => throw new NotImplementedException(),
            };

        public INode Subtract(INode node) =>
            node switch
            {
                Node.Integer y => new Node.Float(this.value - y.Value),
                Node.Float y => new Node.Float(this.value - y.Value),
                _ => throw new NotImplementedException(),
            };

        public INode Divide(INode node) =>
            node switch
            {
                Node.Integer y => new Node.Float(this.value / y.Value),
                Node.Float y => new Node.Float(this.value / y.Value),
                _ => throw new NotImplementedException(),
            };

        public INode Multiply(INode node) =>
            node switch
            {
                Node.Integer y => new Node.Float(this.value * y.Value),
                Node.Float y => new Node.Float(this.value * y.Value),
                _ => throw new NotImplementedException(),
            };

        public override INode Clone() =>
            new Node.Float(this.value);

        public override string ToString() =>
            $"Float({this.ToRepresentation()})";

        public override string ToRepresentation() =>
            this.value.ToString(new CultureInfo("en-US"));
    }
}
