namespace Joy;

public abstract partial class Node
{
    public class Symbol : Node
    {
        private readonly string name;

        public Symbol(string name)
        {
            this.name = name;
        }

        public string Name => this.name;

        public override Operator Op => Operator.Symbol;

        public override INode Clone() =>
            new Node.Symbol(this.name);

        public override string ToString() =>
            $"Symbol({this.name})";
    }
}
