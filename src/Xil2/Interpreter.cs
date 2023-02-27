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
            ["+"] = new Entry(Interpreter.Add),
            ["i"] = new Entry(Interpreter._I),
            ["x"] = new Entry(Interpreter._X),
            ["pop"] = new Entry(Interpreter.Pop),
            ["swap"] = new Entry(Interpreter.Swap),
            ["dip"] = new Entry(Interpreter.Dip),
            ["cons"] = new Entry(Interpreter.Cons),
            ["dup"] = new Entry(Interpreter.Dup),
            ["clear"] = new Entry(Interpreter.Clear),
            ["trace"] = new Entry(Interpreter.Trace),
            ["branch"] = new Entry(Interpreter.Branch),
            ["choice"] = new Entry(Interpreter.Choice),
            ["first"] = new Entry(Interpreter.First),
            ["rest"] = new Entry(Interpreter.Rest),
            ["concat"] = new Entry(Interpreter.Concat),
            ["swaack"] = new Entry(Interpreter.Swaack),
            ["infra"] = new Entry(Interpreter.Infra),
            ["map"] = new Entry(Interpreter.Map),
            ["ifte"] = new Entry(Interpreter.Ifte),
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

    private static void Swap(Interpreter i)
    {
        var y = i.Pop<INode>();
        var x = i.Pop<INode>();
        i.Push(y);
        i.Push(x);
    }

    private static void Cons(Interpreter i)
    {
        new Validator("cons")
            .TwoArguments()
            .ListOnTop()
            .Validate(i.Stack);
        var a = i.Pop<Node.List>();
        var x = i.Pop<INode>();
        i.Push(a.Cons(x));
    }

    private static void Branch(Interpreter i)
    {
        new Validator("branch")
            .ThreeArguments()
            .TwoQuotes()
            .Validate(i.Stack);
        var @then = i.Pop<Node.List>();
        var @else = i.Pop<Node.List>();
        var cond = i.Pop<INode>();
        var cons = Node.IsTruthy(cond) ? @then : @else;
        i.Queue.InsertFirst(cons!);
    }

    private static void Choice(Interpreter i)
    {
        new Validator("choice")
            .ThreeArguments()
            .Validate(i.Stack);
        var cond = i.Pop<INode>();
        var @then = i.Pop<INode>();
        var @else = i.Pop<INode>();
        var cons = Node.IsTruthy(cond) ? @then : @else;
        i.Push(cons);
    }

    private static readonly Validator IfteValidator =
        new Validator("ifte")
            .ThreeArguments()
            .ThreeQuotes();

    private static void Ifte(Interpreter i)
    {
        IfteValidator.Validate(i.Stack);

        var ifte = new Node.List(
            new Node.Symbol("infra"),
            new Node.Symbol("first"),
            new Node.Symbol("choice"),
            new Node.Symbol("i"));

        i.Queue.InsertFirst(ifte);

        var @else = i.Pop<Node.List>();
        var @then = i.Pop<Node.List>();
        var cond = i.Pop<Node.List>();
        var saved = new Node.List(i.Stack);

        i.Stack.Push(@else);
        i.Stack.Push(@then);
        i.Stack.Push(saved);
        i.Stack.Push(cond);
    }

    private static void Dip(Interpreter i)
    {
        new Validator("dip")
            .TwoArguments()
            .OneQuote()
            .Validate(i.Stack);
        var quote = i.Pop<Node.List>();
        var x = i.Pop<INode>();
        i.Queue.InsertFirst(new Node.List(x));
        i.Queue.InsertFirst(quote);
    }

    private static void Concat(Interpreter i)
    {
        new Validator("concat")
            .TwoArguments()
            .TwoQuotes()
            .Validate(i.Stack);
        var y = i.Pop<Node.List>();
        var x = i.Pop<Node.List>();
        i.Push(x.Concat(y));
    }

    private static void Pop(Interpreter i)
    {
        new Validator("pop")
            .OneArgument()
            .Validate(i.Stack);
        i.Pop<INode>();
    }

    private static void First(Interpreter i)
    {
        new Validator("first")
            .OneArgument()
            .AggregateOnTop()
            .Validate(i.Stack);
        var xs = i.Pop<IAggregate>();
        i.Push(xs.First());
    }

    private static void Rest(Interpreter i)
    {
        new Validator("rest")
            .OneArgument()
            .NonEmptyAggregateOnTop<IAggregate>()
            .Validate(i.Stack);
        var xs = i.Pop<IAggregate>();
        i.Push(xs.Rest());
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
        i.Queue.InsertFirst(new Node.List(x));
    }

    private static void _X(Interpreter i)
    {
        new Validator("x")
            .OneArgument()
            .OneQuote()
            .Validate(i.Stack);
        var quote = i.Peek<Node.List>();
        i.Queue.InsertFirst(quote);
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

    private static readonly Validator SwaackValidator =
        new Validator("swaack")
            .OneArgument()
            .ListOnTop();

    private static void Swaack(Interpreter i)
    {
        SwaackValidator.Validate(i.Stack);
        var @new = i.Pop<Node.List>();
        i.Stack.Reverse();
        var @old = new Node.List(i.Stack);
        i.Stack = new C5.ArrayList<INode>();
        i.Stack.AddAll(@new.Elements.Reverse());
        i.Push(@old);
    }

    private static readonly Validator InfraValidator =
        new Validator("infra")
            .TwoArguments()
            .TwoQuotes();

    private static void Infra(Interpreter i)
    {
        InfraValidator.Validate(i.Stack);
        var q = i.Pop<Node.List>();
        var a = i.Pop<IAggregate>();
        i.Stack.Reverse();
        i.Queue.InsertFirst(new Node.List(new Node.Symbol("swaack")));
        i.Queue.InsertFirst(new Node.List(new Node.List(i.Stack)));
        i.Queue.InsertFirst(q);
        i.Stack = new C5.ArrayList<INode>();
        i.Stack.AddAll(a.Elements);
    }

    private static readonly Validator MapValidator =
        new Validator("map")
            .TwoArguments()
            .OneQuote()
            .ListAsSecond();

    private static void Map(Interpreter i)
    {
        MapValidator.Validate(i.Stack);
        var q = i.Pop<Node.List>();
        var a = i.Pop<IAggregate>();
        if (!a.Elements.Any())
        {
            i.Stack.Push(a);
            return;
        }

        var batch = new C5.ArrayList<INode>();
        foreach (var x in a.Elements)
        {
            batch.InsertFirst(new Node.Symbol("first"));
            batch.InsertFirst(new Node.Symbol("infra"));
            batch.InsertFirst(q);
            batch.InsertFirst(new Node.List(x));
        }

        i.Push(new Node.List());
        i.Push(new Node.List(batch));
        i.Queue.InsertFirst(new Node.List(new Node.Symbol("infra")));
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
            // Values in the queue are always quoted so flatten
            // them in order to produce unnested (i.e. readable) output.
            var queue = i.Queue.SelectMany(x => x.Elements).ToArray();
            var stack = i.Stack.ToArray();
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
