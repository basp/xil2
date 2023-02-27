using System.Text;

namespace Xil2;

public class Interpreter
{
    public C5.IStack<INode> Stack { get; set; } =
        new C5.ArrayList<INode>();

    public C5.ArrayList<Node.List> Queue { get; set; } =
        new C5.ArrayList<Node.List>();

    private IDictionary<string, Entry> Env { get; set; } =
        new Dictionary<string, Entry>
        {
            ["+"] = new Entry(Interpreter.Add),
            ["i"] = new Entry(Interpreter._I),
            ["dup"] = new Entry(Interpreter.Dup),
            ["clear"] = new Entry(Interpreter.Clear),
            ["trace"] = new Entry(Interpreter.Trace),
        };

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

    private static void Add(Interpreter i)
    {
        new Validator("+")
            .TwoArguments()
            .TwoFloatsOrIntegers()
            .Validate(i.Stack);
        var y = i.Pop<IFloatable>();
        var x = i.Pop<IFloatable>();
        i.Push(x.Add(y));
    }

    private static void Clear(Interpreter i)
    {
        i.Stack = new C5.ArrayList<INode>();
    }

    private static void Dup(Interpreter i)
    {
        new Validator("dup")
            .OneArgument()
            .Validate(i.Stack);
        var x = i.Peek<INode>();
        i.Queue.InsertFirst(new Node.List(x.Clone()));
    }

    private static void _I(Interpreter i)
    {
        new Validator("i")
            .OneArgument()
            .OneQuote()
            .Validate(i.Stack);
        var quote = i.Pop<Node.List>();
        i.Queue.InsertFirst(quote);
    }

    private static void Trace(Interpreter i)
    {
        new Validator("trace")
            .OneArgument()
            .OneQuote()
            .Validate(i.Stack);

        var saved = i.Queue;
        var history = new List<(INode[], INode[])>();

        void Record()
        {
            var stack = i.Stack.ToArray();
            var queue = i.Queue.SelectMany(x => x.Elements).ToArray();
            history!.Add((stack, queue));
        }

        i.Queue = new C5.ArrayList<Node.List>();
        i.Queue.InsertFirst(i.Pop<Node.List>());

        Record();

        while (i.TryDequeue(out var node))
        {
            if (history.Count > 1000)
            {
                break;
            }

            if (node!.Op == Operand.Symbol)
            {
                var symbol = (Node.Symbol)node;
                if (!i.Env.TryGetValue(symbol.Name, out var entry))
                {
                    var msg = $"Unknown symbol: '{symbol.Name}'";
                    throw new RuntimeException(msg);
                }

                if (entry.IsRuntime)
                {
                    i.Queue.InsertFirst(new Node.List(entry.Body));
                }
                else
                {
                    entry.Action(i);
                }
            }
            else
            {
                i.Push(node);
            }

            Record();
        }

        i.Queue = saved;

        Console.WriteLine(TraceToString(history));
    }

    private static string TraceToString(List<(INode[], INode[])> history)
    {
        var buf = new StringBuilder();
        var lines = history.Select(x => new
        {
            Stack = string.Join(' ', x.Item1.Select(x => x.ToRepresentation())),
            Queue = string.Join(' ', x.Item2.Select(x => x.ToRepresentation())),
        });

        var padding = lines.Max(x => x.Stack.Length);
        foreach (var t in lines)
        {
            buf.Append(t.Stack.PadLeft(padding));
            buf.Append(" . ");
            buf.Append(t.Queue);
            buf.AppendLine();
        }

        return buf.ToString();
    }

    private bool TryDequeue(out INode? node) => TryDequeue(this.Queue, out node);

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