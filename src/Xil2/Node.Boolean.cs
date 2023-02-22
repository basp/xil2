namespace Joy;

public abstract partial class Node
{
    public class Boolean : Node
    {
        private readonly bool value;

        public Boolean(bool value)
        {
            this.value = value;
        }

        public override Operator Op => Operator.Boolean;

        public override INode Clone() =>
            new Boolean(this.value);

        public override string ToString() =>
            $"Boolean({this.value})";
    }
}
