namespace Xil2;

public abstract partial class Node
{
    public class Char : Node, IOrdinal
    {
        private readonly char value;

        public Char(char value)
        {
            this.value = value;
        }

        public override Operator Op => Operator.Char;

        public override bool IsOrdinal => true;

        public override INode Clone() =>
            new Char(this.value);

        public override string ToString() => $"Char({this.value})";

        public override string ToRepresentation() => $"'{this.value}";
    }
}
