using System.Diagnostics.CodeAnalysis;

namespace Joy;

public abstract partial class Node
{
    public class List : Node
    {
        private readonly IList<INode> elements;

        public List(params INode[] elements)
        {
            this.elements = elements.ToList();
        }

        public List([NotNull] IEnumerable<INode> elements)
            : this(elements.ToArray())
        {
        }

        public IEnumerable<INode> Elements => this.elements;

        public override Operator Op => Operator.List;

        public override INode Clone()
        {
            var xs = this.elements.Select(x => x.Clone());
            return new Node.List(xs);
        }

        public override string ToString()
        {
            var xs = this.elements.Select(x => x.ToString()).ToArray();
            return $"[{string.Join(' ', xs)}]";
        }
    }
}
