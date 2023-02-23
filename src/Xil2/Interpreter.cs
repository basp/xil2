namespace Xil2;

public abstract class Interpreter : Dictionary<string, Action<Interpreter>>
{
    private readonly C5.IStack<INode> stack = new C5.ArrayList<INode>();

    public C5.IStack<INode> Stack => this.stack;

    public virtual void AddDefinition(string name, IEnumerable<INode> body)
    {
        this.Add(name, _ => Eval(body));
    }

    public virtual void Eval(IEnumerable<INode> factors)
    {
        foreach (var node in factors)
        {
            switch (node.Op)
            {
                case Operand.None:
                    break;
                case Operand.Boolean:
                case Operand.Integer:
                case Operand.Char:
                case Operand.Float:
                case Operand.String:
                case Operand.Set:
                case Operand.List:
                    this.stack.Push(node);
                    break;
                default:
                    var symbol = (Node.Symbol)node;
                    if (this.TryGetValue(symbol.Name, out var action))
                    {
                        action(this);
                    }
                    break;
            }
        }
    }

    public T Pop<T>() where T : INode => (T)this.stack.Pop();

    public void Push(INode value) => this.stack.Push(value);
}
