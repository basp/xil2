namespace Xil2;

public static class Operations
{
    public static void Add(Interpreter i)
    {
        new Validator("+")
            .TwoArguments()
            .TwoFloatsOrIntegers()
            .Validate(i.Stack);
        var y = i.Pop<IFloatable>();
        var x = i.Pop<IFloatable>();
        i.Push(x.Add(y));
    }

    public static void Swap(Interpreter i)
    {
        var y = i.Pop<INode>();
        var x = i.Pop<INode>();
        i.Push(y);
        i.Push(x);
    }

    public static void Cons(Interpreter i)
    {
        new Validator("cons")
            .TwoArguments()
            .ListOnTop()
            .Validate(i.Stack);
        var a = i.Pop<Node.List>();
        var x = i.Pop<INode>();
        i.Push(a.Cons(x));
    }

    public static void Branch(Interpreter i)
    {
        new Validator("branch")
            .ThreeArguments()
            .TwoQuotes()
            .Validate(i.Stack);
        var @else = i.Pop<Node.List>();
        var @then = i.Pop<Node.List>();
        var cond = i.Pop<INode>();
        var cons = Node.IsTruthy(cond) ? @then : @else;
        i.Queue.InsertFirst(cons!);
    }

    public static void Choice(Interpreter i)
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

    public static void Ifte(Interpreter i)
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

    public static void Dip(Interpreter i)
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

    public static void Concat(Interpreter i)
    {
        new Validator("concat")
            .TwoArguments()
            .TwoQuotes()
            .Validate(i.Stack);
        var y = i.Pop<Node.List>();
        var x = i.Pop<Node.List>();
        i.Push(x.Concat(y));
    }

    public static void Pop(Interpreter i)
    {
        new Validator("pop")
            .OneArgument()
            .Validate(i.Stack);
        i.Pop<INode>();
    }

    public static void First(Interpreter i)
    {
        new Validator("first")
            .OneArgument()
            .AggregateOnTop()
            .Validate(i.Stack);
        var xs = i.Pop<IAggregate>();
        i.Push(xs.First());
    }

    public static void Rest(Interpreter i)
    {
        new Validator("rest")
            .OneArgument()
            .NonEmptyAggregateOnTop<IAggregate>()
            .Validate(i.Stack);
        var xs = i.Pop<IAggregate>();
        i.Push(xs.Rest());
    }

    public static void Clear(Interpreter i)
    {
        i.Stack = new C5.ArrayList<INode>();
    }

    public static void Dup(Interpreter i)
    {
        new Validator("dup")
            .OneArgument()
            .Validate(i.Stack);
        var x = i.Peek<INode>();
        i.Queue.InsertFirst(new Node.List(x));
    }

    public static void _X(Interpreter i)
    {
        new Validator("x")
            .OneArgument()
            .OneQuote()
            .Validate(i.Stack);
        var quote = i.Peek<Node.List>();
        i.Queue.InsertFirst(quote);
    }

    public static void _I(Interpreter i)
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

    public static void Swaack(Interpreter i)
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

    public static void Infra(Interpreter i)
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

    public static void Map(Interpreter i)
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

    public static void Trace(Interpreter i)
    {
        new Validator("trace")
            .OneArgument()
            .OneQuote()
            .Validate(i.Stack);

        var history = new Trace();
        var saved = i.Queue;

        i.Queue = new C5.ArrayList<Node.List>();
        i.Queue.InsertFirst(i.Pop<Node.List>());

        history.Record(i);

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

            history.Record(i);
        }

        i.Queue = saved;

        Console.WriteLine(history.ToString());
    }
}
