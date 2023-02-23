namespace Xil2;

using System.Diagnostics.CodeAnalysis;

public abstract partial class Node
{
    public class List : Node, IAggregate
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

        public override string ToRepresentation()
        {
            var xs = this.elements.Select(x => x.ToRepresentation()).ToArray();
            return $"[{string.Join(' ', xs)}]";
        }

        public INode Cons(INode node) =>
            new List(new[] { node }.Concat(this.elements));

        public INode Concat(INode node) =>
            node switch
            {
                Node.List y => new List(this.elements.Concat(y.elements)),
                _ => throw new NotSupportedException(),
            };
    }
}
