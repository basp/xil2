using System.Text;

namespace Xil2;

public class Interpreter : Dictionary<string, Entry>
{
    public C5.ArrayList<INode> Stack { get; set; } =
        new C5.ArrayList<INode>();

    public C5.ArrayList<Node.List> Queue { get; set; } =
        new C5.ArrayList<Node.List>();

    public Interpreter()
    {
        this["+"] = new Entry(Operations.Add);
        this["i"] = new Entry(Operations._I);
        this["x"] = new Entry(Operations._X);
        this["pop"] = new Entry(Operations.Pop);
        this["swap"] = new Entry(Operations.Swap);
        this["dip"] = new Entry(Operations.Dip);
        this["cons"] = new Entry(Operations.Cons);
        this["dup"] = new Entry(Operations.Dup);
        this["clear"] = new Entry(Operations.Clear);
        this["trace"] = new Entry(Operations.Trace);
        this["branch"] = new Entry(Operations.Branch);
        this["choice"] = new Entry(Operations.Choice);
        this["first"] = new Entry(Operations.First);
        this["rest"] = new Entry(Operations.Rest);
        this["concat"] = new Entry(Operations.Concat);
        this["swaack"] = new Entry(Operations.Swaack);
        this["infra"] = new Entry(Operations.Infra);
        this["map"] = new Entry(Operations.Map);
        this["ifte"] = new Entry(Operations.Ifte);
    }

    public void AddDefinition(string name, IEnumerable<INode> body)
    {
        this.Add(name, new Entry(body));
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
                if (!this.TryGetValue(symbol.Name, out var entry))
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

    /// <summary>
    /// Tries to dequeue a value from the queue.
    /// </summary>
    /// <remarks>
    /// <p>
    /// This method will first check if there is a quotation on the queue. If
    /// there is and if the quotation has any elements then it will remove the 
    /// first node from the quotation and use this as the <c>node</c> output 
    /// argument. If the quotation has any elements left then they will be
    /// enqueued for further processing. After all this the value <c>true</c> 
    /// will be returned. If there are no nodes to be dequeued then the 
    /// <c>node</c> output parameter will be <c>null</c> and the method will 
    /// return <c>false</c>.
    /// </p>
    /// <p>
    /// Values on the queue are always assumed to be quoted. This means that 
    /// a list literal such as <c>[1 2 3]</c> will appear as <c>[[1 2 3]]</c> 
    /// and literals such as <c>true</c>, <c>1</c>, <c>"foo"</c> will appear 
    /// as <c>[true]</c>, <c>[1]</c> and <c>["foo"]</c> or <c>[true 1 "foo"]</c>
    /// when packed together in a single quotation.
    /// </p>
    /// </remarks>
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
