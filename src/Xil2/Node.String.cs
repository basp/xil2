namespace Joy;

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

        public override INode Clone() =>
            new Node.String(this.value);

        public override string ToString() =>
            $"String({this.value})";
    }
}
