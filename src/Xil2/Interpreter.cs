namespace Xil2;

/// <summary>
/// Provides a stack based interpreter environment for Xil code.
/// </summary>
/// <remarks>
/// This class provides a stack based environment for implementing 
/// an interpreter. It supports evaluating a list of factors and 
/// pushing and popping values onto the stack. It can also be used
/// to store user defined symbols (i.e. definitions).
/// </remarks>
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
                    else
                    {
                        var msg = $"Unknown symbol: {symbol.Name}";
                        throw new RuntimeException(msg);
                    }
                    break;

            }
        }
    }

    public T Pop<T>() where T : INode => (T)this.stack.Pop();

    public void Push(INode value) => this.stack.Push(value);
}
