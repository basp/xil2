namespace Xil2;

public abstract partial class Node
{
    public class Boolean : Node
    {
        public static readonly Boolean True = new Boolean(true);

        public static readonly Boolean False = new Boolean(false);

        private readonly bool value;

        public static Boolean Get(bool value) => value ? True : False;

        private Boolean(bool value)
        {
            this.value = value;
        }

        public override Operand Op => Operand.Boolean;

        public bool Value => this.value;

        public override INode Clone() =>
            new Boolean(this.value);

        public override string ToString() =>
            $"Boolean({this.value})";

        public override string ToRepresentation() =>
            this.value.ToString().ToLower();

        public override bool Equals(object? obj)
        {
            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            var other = obj as Boolean;
            if (other == null)
            {
                return false;
            }

            return this.value == other.value;
        }

        public override int GetHashCode() =>
            HashCode.Combine(HashTags.Boolean, this.value.GetHashCode());
    }
}
