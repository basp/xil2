using System.Text;

namespace Xil2;

public class Interpreter
{
    public C5.ArrayList<INode> Stack { get; set; } =
        new C5.ArrayList<INode>();

    public C5.ArrayList<Node.List> Queue { get; set; } =
        new C5.ArrayList<Node.List>();

    public IDictionary<string, Entry> Env { get; set; } =
        new Dictionary<string, Entry>
        {
            ["+"] = new Entry(Operations.Add),
            ["i"] = new Entry(Operations._I),
            ["x"] = new Entry(Operations._X),
            ["pop"] = new Entry(Operations.Pop),
            ["swap"] = new Entry(Operations.Swap),
            ["dip"] = new Entry(Operations.Dip),
            ["cons"] = new Entry(Operations.Cons),
            ["dup"] = new Entry(Operations.Dup),
            ["clear"] = new Entry(Operations.Clear),
            ["trace"] = new Entry(Operations.Trace),
            ["branch"] = new Entry(Operations.Branch),
            ["choice"] = new Entry(Operations.Choice),
            ["first"] = new Entry(Operations.First),
            ["rest"] = new Entry(Operations.Rest),
            ["concat"] = new Entry(Operations.Concat),
            ["swaack"] = new Entry(Operations.Swaack),
            ["infra"] = new Entry(Operations.Infra),
            ["map"] = new Entry(Operations.Map),
            ["ifte"] = new Entry(Operations.Ifte),
        };

    public void AddDefinition(string name, IEnumerable<INode> body)
    {
        this.Env.Add(name, new Entry(body));
    }

    public void Execute(IEnumerable<INode> factors)
    {
        this.Queue.Clear();
        this.Queue.InsertFirst(new Node.List(factors));
        while (this.TryDequeue(out var node))
        {
            if (node!.Op == Operand.Symbol)
            {
                var symbol = (Node.Symbol)node;
                if (!this.Env.TryGetValue(symbol.Name, out var entry))
                {
                    var msg = $"Unknown symbol: '{symbol.Name}";
                    throw new RuntimeException(msg);
                }

                if (entry.IsRuntime)
                {
                    this.Queue.InsertFirst(new Node.List(entry.Body));
                }
                else
                {
                    entry.Action(this);
                }
            }
            else
            {
                this.Stack.Push(node);
            }
        }
    }

    /// <summary>
    /// Peek at the value on top of the stack.
    /// </summary>
    public T Peek<T>() where T : INode => (T)this.Stack.Last();

    /// <summary>
    /// Pops a node from the stack.
    /// </summary>
    public T Pop<T>() where T : INode => (T)this.Stack.Pop();

    /// <summary>
    /// Pushes a node onto the stack.
    /// </summary>
    public void Push(INode node) => this.Stack.Push(node);

    public void Enqueue(INode node) =>
        this.Queue.InsertFirst(new Node.List(node));

    public bool TryDequeue(out INode? node) => TryDequeue(this.Queue, out node);

    private static bool TryDequeue(C5.ArrayList<Node.List> queue, out INode? node)
    {
        node = null;

        if (!queue.Any())
        {
            return false;
        }

        var quote = queue.RemoveFirst();
        node = quote.Elements.FirstOrDefault();
        if (node == null)
        {
            return false;
        }

        var rest = quote.Elements.Skip(1);
        if (rest.Any())
        {
            queue.InsertFirst(new Node.List(rest));
        }

        return true;
    }
}
