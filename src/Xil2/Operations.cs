namespace Xil2;

public static class Operations
{
    public static void Add(Interpreter i) =>
        BinaryArithmetic(i, "+", (x, y) => x.Add(y));

    public static void Sub(Interpreter i) =>
        BinaryArithmetic(i, "-", (x, y) => x.Subtract(y));

    public static void Mul(Interpreter i) =>
        BinaryArithmetic(i, "*", (x, y) => x.Multiply(y));

    public static void Div(Interpreter i) =>
        BinaryArithmetic(i, "/", (x, y) => x.Divide(y));

    public static void Mod(Interpreter i) =>
        BinaryArithmetic(i, "%", (x, y) => x.Modulo(y));

    public static void Lt(Interpreter i) =>
        BinaryLogic(i, "<", (x, y) => x.CompareTo(y) < 0
            ? Node.Boolean.True
            : Node.Boolean.False);

    public static void Gt(Interpreter i) =>
        BinaryLogic(i, ">", (x, y) => x.CompareTo(y) > 0
            ? Node.Boolean.True
            : Node.Boolean.False);

    public static void Lte(Interpreter i) =>
        BinaryLogic(i, "<=", (x, y) => x.CompareTo(y) <= 0
            ? Node.Boolean.True
            : Node.Boolean.False);

    public static void Gte(Interpreter i) =>
        BinaryLogic(i, ">=", (x, y) => x.CompareTo(y) >= 0
            ? Node.Boolean.True
            : Node.Boolean.False);

    public static void Eq(Interpreter i) =>
        BinaryLogic(i, "=", (x, y) => x.CompareTo(y) == 0
            ? Node.Boolean.True
            : Node.Boolean.False);

    public static void Neq(Interpreter i) =>
        BinaryLogic(i, "!=", (x, y) => x.CompareTo(y) != 0
            ? Node.Boolean.True
            : Node.Boolean.False);

    public static void Swap(Interpreter i)
    {
        Validators.SwapValidator.Validate(i.Stack);
        var y = i.Pop<INode>();
        var x = i.Pop<INode>();
        i.Push(y);
        i.Push(x);
    }

    public static void Cons(Interpreter i)
    {
        Validators.ConsValidator.Validate(i.Stack);
        var a = i.Pop<Node.List>();
        var x = i.Pop<INode>();
        i.Push(a.Cons(x));
    }

    public static void Branch(Interpreter i)
    {
        Validators.BranchValidator.Validate(i.Stack);
        var @else = i.Pop<Node.List>();
        var @then = i.Pop<Node.List>();
        var cond = i.Pop<INode>();
        var cons = Node.IsTruthy(cond) ? @then : @else;
        i.Queue.InsertFirst(cons!);
    }

    public static void Choice(Interpreter i)
    {
        Validators.ChoiceValidator.Validate(i.Stack);
        var cond = i.Pop<INode>();
        var @then = i.Pop<INode>();
        var @else = i.Pop<INode>();
        var cons = Node.IsTruthy(cond) ? @then : @else;
        i.Push(cons);
    }

    public static void Ifte(Interpreter i)
    {
        Validators.IfteValidator.Validate(i.Stack);

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
        Validators.DipValidator.Validate(i.Stack);
        var quote = i.Pop<Node.List>();
        var x = i.Pop<INode>();
        i.Queue.InsertFirst(new Node.List(x));
        i.Queue.InsertFirst(quote);
    }

    public static void Concat(Interpreter i)
    {
        Validators.ConcatValidator.Validate(i.Stack);
        var y = i.Pop<Node.List>();
        var x = i.Pop<Node.List>();
        i.Push(x.Concat(y));
    }

    public static void Pop(Interpreter i)
    {
        Validators.PopValidator.Validate(i.Stack);
        i.Pop<INode>();
    }

    public static void First(Interpreter i)
    {
        Validators.FirstValidator.Validate(i.Stack);
        var xs = i.Pop<IAggregate>();
        i.Push(xs.First());
    }

    public static void Rest(Interpreter i)
    {
        Validators.RestValidator.Validate(i.Stack);
        var xs = i.Pop<IAggregate>();
        i.Push(xs.Rest());
    }

    public static void Clear(Interpreter i)
    {
        i.Stack = new C5.ArrayList<INode>();
    }

    public static void Dup(Interpreter i)
    {
        Validators.DupValidator.Validate(i.Stack);
        var x = i.Peek<INode>();
        i.Queue.InsertFirst(new Node.List(x));
    }

    public static void _X(Interpreter i)
    {
        Validators._XValidator.Validate(i.Stack);
        var quote = i.Peek<Node.List>();
        i.Queue.InsertFirst(quote);
    }

    public static void _I(Interpreter i)
    {
        Validators._IValidator.Validate(i.Stack);
        var quote = i.Pop<Node.List>();
        i.Queue.InsertFirst(quote);
    }

    public static void Swaack(Interpreter i)
    {
        Validators.SwaackValidator.Validate(i.Stack);
        var @new = i.Pop<Node.List>();
        i.Stack.Reverse();
        var @old = new Node.List(i.Stack);
        i.Stack = new C5.ArrayList<INode>();
        i.Stack.AddAll(@new.Elements.Reverse());
        i.Push(@old);
    }

    public static void Infra(Interpreter i)
    {
        Validators.InfraValidator.Validate(i.Stack);
        var q = i.Pop<Node.List>();
        var a = i.Pop<IAggregate>();
        i.Stack.Reverse();
        i.Queue.InsertFirst(new Node.List(new Node.Symbol("swaack")));
        i.Queue.InsertFirst(new Node.List(new Node.List(i.Stack)));
        i.Queue.InsertFirst(q);
        i.Stack = new C5.ArrayList<INode>();
        i.Stack.AddAll(a.Elements);
    }

    public static void Map(Interpreter i)
    {
        Validators.MapValidator.Validate(i.Stack);
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
        Validators.TraceValidator.Validate(i.Stack);

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
                if (!i.TryGetValue(symbol.Name, out var entry))
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

    private static void BinaryLogic(
        Interpreter i,
        string name,
        Func<IOrdinal, IOrdinal, INode> cmp)
    {
        new Validator(name)
            .TwoArguments()
            .TwoOrdinalsOnTop()
            .Validate(i.Stack);
        var y = i.Pop<IOrdinal>();
        var x = i.Pop<IOrdinal>();
        i.Push(cmp(x, y));
    }

    private static void BinaryArithmetic(
        Interpreter i,
        string name,
        Func<IFloatable, IFloatable, IFloatable> op)
    {
        new Validator(name)
            .TwoArguments()
            .TwoFloatsOrIntegers()
            .Validate(i.Stack);
        var y = i.Pop<IFloatable>();
        var x = i.Pop<IFloatable>();
        i.Push(op(x, y));
    }
}
