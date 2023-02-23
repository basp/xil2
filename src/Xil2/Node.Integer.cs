namespace Xil2;

public abstract partial class Node
{
    public class Integer : Node, IFloatable
    {
        private readonly int value;

        public Integer(int value)
        {
            this.value = value;
        }

        public int Value => this.value;

        public override Operator Op => Operator.Integer;

        public INode Add(INode node) =>
            node switch
            {
                Node.Integer y => new Node.Integer(this.value + y.Value),
                Node.Float y => new Node.Float(this.value + y.Value),
                _ => throw new InvalidOperationException(),
            };

        public INode Divide(INode node) =>
            node switch
            {
                Node.Integer y => new Node.Integer(this.value / y.Value),
                Node.Float y => new Node.Float(this.value / y.Value),
                _ => throw new InvalidOperationException(),
            };

        public INode Multiply(INode node) =>
            node switch
            {
                Node.Integer y => new Node.Integer(this.value * y.value),
                Node.Float y => new Node.Float(this.value * y.Value),
                _ => throw new InvalidOperationException(),
            };

        public INode Subtract(INode node) =>
            node switch
            {
                Node.Integer y => new Node.Integer(this.value - y.Value),
                Node.Float y => new Node.Float(this.value - y.Value),
                _ => throw new InvalidOperationException(),
            };

        public override INode Clone() =>
            new Node.Integer(this.value);

        public override string ToString() =>
            $"Integer({this.ToRepresentation()})";

        public override string ToRepresentation() =>
            this.value.ToString();
    }
}
