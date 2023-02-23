namespace Xil2;

public abstract partial class Node
{
    /// <summary>
    /// Represents a symbol node in the interpreter.
    /// </summary>
    public class Symbol : Node
    {
        private readonly string name;

        public Symbol(string name)
        {
            this.name = name;
        }

        public string Name => this.name;

        public override Operand Op => Operand.Symbol;

        public override INode Clone() =>
            new Node.Symbol(this.name);

        public override string ToString() =>
            $"Symbol({this.name})";

        public override string ToRepresentation() =>
            this.name;
    }
}
