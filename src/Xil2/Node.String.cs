namespace Xil2;

public abstract partial class Node
{
    /// <summary>
    /// Represents a string node in the interpreter.
    /// </summary>
    public class String : Node, IAggregate
    {
        private readonly string value;

        public String(string value)
        {
            this.value = value;
        }

        public override Operand Op => Operand.String;

        public override bool IsAggregate => true;

        public int Size => throw new NotImplementedException();

        public override INode Clone() =>
            new Node.String(this.value);

        public override string ToString() =>
            $"String({this.value})";

        public override string ToRepresentation() =>
            string.Concat('"', this.value, '"');

        public INode Cons(INode node) =>
            node switch
            {
                _ => 
                    throw new RuntimeException(
                        Validator.GetErrorMessage("cons", "ordinal")),
            };

        public INode Concat(INode node) =>
            node switch
            {
                Node.String y =>
                    new Node.String(string.Concat(this.value, y.value)),
                _ => throw new InvalidOperationException(),
            };

        public INode First() => new Node.Char(this.value[0]);

        public INode Rest() => new Node.String(this.value.Substring(1));
    }
}
