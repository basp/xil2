namespace Xil2;

public abstract partial class Node
{
    /// <summary>
    /// Represents a character node in the interpreter.
    /// </summary>
    public class Char : Ordinal
    {
        private readonly char value;

        public Char(char value)
        {
            this.value = value;
        }

        public override Operand Op => Operand.Char;

        public override bool IsOrdinal => true;

        public override int OrdinalValue => this.value;

        public override INode Clone() =>
            new Char(this.value);

        public override string ToString() => $"Char({this.value})";

        public override string ToRepresentation() => $"'{this.value}";

        public override IOrdinal Ord() => new Node.Integer(this.value);

        public override IOrdinal Chr() => new Node.Char(this.value);

        public override IOrdinal Succ() => new Node.Char((char)(this.value + 1));

        public override IOrdinal Pred() => new Node.Char((char)(this.value - 1));
    }
}
