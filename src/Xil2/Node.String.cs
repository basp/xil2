namespace Xil2;

public abstract partial class Node
{
    public class String : Node
    {
        private readonly string value;

        public String(string value)
        {
            this.value = value;
        }

        public override Operator Op => Operator.String;

        public override bool IsAggregate => true;

        public override INode Clone() =>
            new Node.String(this.value);

        public override string ToString() =>
            $"String({this.value})";

        public override string ToRepresentation() =>
            string.Concat('"', this.value, '"');
    }
}
