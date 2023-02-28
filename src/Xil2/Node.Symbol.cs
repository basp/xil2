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
