namespace Xil2;

public abstract class Interpreter : Dictionary<string, Action>
{
    private readonly C5.IStack<INode> stack = new C5.ArrayList<INode>();

    public C5.IStack<INode> Stack => this.stack;

    public virtual void AddDefinition(string name, IEnumerable<INode> body)
    {
        this.Add(name, () => Eval(body));
    }

    public virtual void Eval(IEnumerable<INode> factors)
    {
        foreach (var node in factors)
        {
            switch (node.Op)
            {
                case Operator.None:
                    break;
                case Operator.Boolean:
                case Operator.Integer:
                case Operator.Char:
                case Operator.Float:
                case Operator.String:
                case Operator.Set:
                case Operator.List:
                    this.stack.Push(node);
                    break;
                default:
                    var symbol = (Node.Symbol)node;
                    if (this.TryGetValue(symbol.Name, out var action))
                    {
                        action();
                    }
                    break;
            }
        }
    }

    protected T Pop<T>() where T : INode => (T)this.stack.Pop();

    protected void Push(INode value) => this.stack.Push(value);
}
