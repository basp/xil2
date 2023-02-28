namespace Xil2;

public abstract partial class Node
{
    /// <summary>
    /// Represents a symbol node in the interpreter.
    /// </summary>
    public class Symbol : Node
    {
        private static readonly IDictionary<string, Symbol> interned =
            new Dictionary<string, Symbol>();

        private readonly string name;

        public static Symbol Get(string name)
        {
            if (interned.TryGetValue(name, out var node))
            {
                return node;
            }

            node = new Symbol(name);
            interned.Add(name, node);
            return node;
        }

        private Symbol(string name)
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

        public override bool Equals(object? obj)
        {
            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            var other = obj as Symbol;
            if (other == null)
            {
                return false;
            }

            return this.name == other.name;
        }

        public override int GetHashCode() =>
            HashCode.Combine(HashTags.Symbol, this.name.GetHashCode());
    }
}
