using System.Text;

namespace Xil2;

public class Interpreter : Dictionary<string, Entry>
{
    public Interpreter()
    {
        this["id"] = new Entry(_ => { });
        this["+"] = new Entry(Operations.Add);
        this["-"] = new Entry(Operations.Sub);
        this["*"] = new Entry(Operations.Mul);
        this["/"] = new Entry(Operations.Div);
        this["<"] = new Entry(Operations.Lt);
        this[">"] = new Entry(Operations.Gt);
        this["<="] = new Entry(Operations.Lte);
        this[">="] = new Entry(Operations.Gte);
        this["="] = new Entry(Operations.Eq);
        this["!="] = new Entry(Operations.Neq);
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
        this["unit"] = new Entry(Operations.Unit);
        this["intern"] = new Entry(Operations.Intern);
        this["name"] = new Entry(Operations.Name);
        this["stack"] = new Entry(Operations.Stack);
        this["unstack"] = new Entry(Operations.Unstack);
        this["def"] = new Entry(Operations.Def);
        this["type"] = new Entry(Operations.Type);
        this["char"] = new Entry(Operations.Char);
        this["int"] = new Entry(Operations.Int);
        this["float"] = new Entry(Operations.Float);
        this["bool"] = new Entry(Operations.Bool);
    }

    /// <summary>
    /// Gets or sets the interpreter stack.
    /// </summary>
    public C5.ArrayList<INode> Stack { get; set; } =
        new C5.ArrayList<INode>();

    /// <summary>
    /// Gets or sets the interpreter queue.
    /// </summary>
    public C5.ArrayList<Node.List> Queue { get; set; } =
        new C5.ArrayList<Node.List>();

    /// <summary>
    /// Adds a new runtime definition to the interpreter environment.
    /// </summary>
    public void AddDefinition(string name, IEnumerable<INode> body)
    {
        this.Add(name, new Entry(body));
    }

    /// <summary>
    /// Executes a term (a list of factors) as a new queue.
    /// </summary>
    /// <remarks>
    /// Note that this should only be called (once) every cycle from the 
    /// top-level since it will reset the current queue. It is not
    /// recommended to invoke this from inside an interpreter operation
    /// unless you save and restore the queue or intentionally want
    /// to destroy it.
    /// </remarks>
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
                    var msg = $"Unknown symbol: '{symbol.Name}'";
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

    /// <summary>
    /// Tries to dequeue a value from the queue.
    /// </summary>
    /// <remarks>
    /// <p>
    /// Values on the queue are always assumed to be quoted. This means that 
    /// a list literal such as <c>[1 2 3]</c> will appear as <c>[[1 2 3]]</c> 
    /// and literals such as <c>true</c>, <c>1</c>, <c>"foo"</c> will appear 
    /// as <c>[true]</c>, <c>[1]</c> and <c>["foo"]</c> or (when they are 
    /// packed into a single quotation) as <c>[true 1 "foo"]</c>. The packed
    /// and unpacked forms are semantically equivalent to the interpreter.
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
