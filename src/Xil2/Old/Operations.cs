namespace Xil2.Old;

/// <summary>
/// This class contains predefined operations that can are used
/// by various interpreter cores.
/// </summary>
public static class Operations
{
    private static IDictionary<string, Func<IFloatable, IFloatable, INode>> floatCmpOps =
        new Dictionary<string, Func<IFloatable, IFloatable, INode>>
        {
            ["cmp"] = (x, y) => new Node.Integer(x.CompareTo(y)),
            ["<"] = (x, y) => new Node.Boolean(x.CompareTo(y) < 0),
            ["<="] = (x, y) => new Node.Boolean(x.CompareTo(y) <= 0),
            [">"] = (x, y) => new Node.Boolean(x.CompareTo(y) > 0),
            [">="] = (x, y) => new Node.Boolean(x.CompareTo(y) >= 0),
            ["="] = (x, y) => new Node.Boolean(x.CompareTo(y) == 0),
            ["!="] = (x, y) => new Node.Boolean(x.CompareTo(y) != 0),
        };

    private static IDictionary<string, Func<IOrdinal, IOrdinal, INode>> ordCmpOps =
        new Dictionary<string, Func<IOrdinal, IOrdinal, INode>>
        {
            ["cmp"] = (x, y) => new Node.Integer(x.CompareTo(y)),
            ["<"] = (x, y) => new Node.Boolean(x.CompareTo(y) < 0),
            ["<="] = (x, y) => new Node.Boolean(x.CompareTo(y) <= 0),
            [">"] = (x, y) => new Node.Boolean(x.CompareTo(y) > 0),
            [">="] = (x, y) => new Node.Boolean(x.CompareTo(y) >= 0),
            ["="] = (x, y) => new Node.Boolean(x.CompareTo(y) == 0),
            ["!="] = (x, y) => new Node.Boolean(x.CompareTo(y) != 0),
        };

    public static void False(Interpreter i)
    {
        i.Push(new Node.Boolean(false));
    }

    public static void True(Interpreter i)
    {
        i.Push(new Node.Boolean(true));
    }

    /// <summary>
    /// Pops the top two arguments and performs an addition.
    /// </summary>
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

    /// <summary>
    /// Pops the top two arguments and performs a subtraction.
    /// </summary>
    public static void Subtract(Interpreter i)
    {
        new Validator("-")
            .TwoArguments()
            .TwoFloatsOrIntegers()
            .Validate(i.Stack);
        var y = i.Pop<IFloatable>();
        var x = i.Pop<IFloatable>();
        i.Push(x.Subtract(y));
    }

    /// <summary>
    /// Pops the top two arguments and performs a modulo.
    /// </summary>
    public static void Modulo(Interpreter i)
    {
        new Validator("%")
            .TwoArguments()
            .TwoFloatsOrIntegers()
            .Validate(i.Stack);
        var a = i.Pop<IFloatable>();
        var b = i.Pop<IFloatable>();
        i.Push(b.Modulo(a));
    }

    /// <summary>
    /// Pops the top two arguments and performs a multiplication.
    /// </summary>
    public static void Multiply(Interpreter i)
    {
        new Validator("*")
            .TwoArguments()
            .TwoFloatsOrIntegers()
            .Validate(i.Stack);
        var y = i.Pop<IFloatable>();
        var x = i.Pop<IFloatable>();
        i.Push(x.Multiply(y));
    }

    /// <summary>
    /// Pops the top two arguments and performs a division.
    /// </summary>
    public static void Divide(Interpreter i)
    {
        new Validator("/")
            .TwoArguments()
            .TwoFloatsOrIntegers()
            .Validate(i.Stack);
        var y = i.Pop<IFloatable>();
        var x = i.Pop<IFloatable>();
        i.Push(x.Divide(y));
    }

    public static void Id(Interpreter i)
    {
        // nop    
    }

    /// <summary>
    /// [A] dup == [A] [A]
    /// </summary>
    public static void Dup(Interpreter i)
    {
        new Validator("dup")
            .OneArgument()
            .Validate(i.Stack);
        var x = i.Stack.Last();
        i.Push(x.Clone());
    }

    /// <summary>
    /// [B] [A] swap == [A] [B]
    /// </summary>
    public static void Swap(Interpreter i)
    {
        new Validator("swap")
            .TwoArguments()
            .Validate(i.Stack);
        var y = i.Pop<INode>();
        var x = i.Pop<INode>();
        i.Push(y);
        i.Push(x);
    }

    /// <summary>
    /// [A] pop ==
    /// </summary>
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
            .AggregateOnTop()
            .Validate(i.Stack);
        var xs = i.Pop<IAggregate>();
        i.Push(xs.Rest());
    }

    /// <summary>
    /// [B] [A] cons == [[B] A]
    /// </summary>
    public static void Cons(Interpreter i)
    {
        new Validator("cons")
            .TwoArguments()
            .AggregateOnTop()
            .Validate(i.Stack);
        var a = i.Pop<IAggregate>();
        var b = i.Pop<INode>();
        var z = a.Cons(b);
        i.Push(z);
    }

    /// <summary>
    /// [A] x == [A] A.
    /// </summary>
    public static void X(Interpreter i)
    {
        new Validator("x")
            .OneArgument()
            .OneQuote()
            .Validate(i.Stack);
        var x = i.Peek<Node.List>();
        i.Execute(x.Elements);
    }

    /// <summary>
    /// [A] i == A
    /// </summary>
    public static void I(Interpreter i)
    {
        new Validator("i")
            .OneArgument()
            .OneQuote()
            .Validate(i.Stack);
        var x = i.Pop<Node.List>();
        i.Execute(x.Elements);
    }

    /// <summary>
    /// Instead of executing directly this will push the
    /// equivalent of factors onto the execution queue.
    /// </summary>
    public static void IFlat(Interpreter i)
    {
        new Validator("i")
            .OneArgument()
            .OneQuote()
            .Validate(i.Stack);
        var x = i.Pop<Node.List>();
        i.Queue = new Queue<INode>(x.Elements.Concat(i.Queue));
    }


    /// <summary>
    /// Instead of executing directly this will push the
    /// equivalent of factors onto the execution queue.
    /// </summary>
    /// <remarks>
    /// Flattening operations will eliminate recursion since
    /// the factors to be executed are prepended to the queue
    /// instead.
    /// </remarks>
    public static void XFlat(Interpreter i)
    {
        new Validator("x")
            .OneArgument()
            .OneQuote()
            .Validate(i.Stack);
        var x = i.Peek<Node.List>();
        i.Queue = new Queue<INode>(x.Elements.Concat(i.Queue));
    }

    public static void Dip(Interpreter i)
    {
        new Validator("dip")
            .TwoArguments()
            .OneQuote()
            .Validate(i.Stack);
        var p = i.Pop<Node.List>();
        var x = i.Pop<INode>();
        i.Execute(p.Elements);
        i.Push(x);
    }

    /// <summary>
    /// [B] [A] dip == A [B]
    /// </summary>
    /// <remarks>
    /// Flattening operations will eliminate recursion since
    /// the factors to be executed are prepended to the queue
    /// instead.
    /// </remarks>
    public static void DipFlat(Interpreter i)
    {
        new Validator("dip")
            .TwoArguments()
            .OneQuote()
            .Validate(i.Stack);
        var a = i.Pop<Node.List>();
        var b = i.Pop<INode>();
        i.Queue = new Queue<INode>(a.Elements.Append(b).Concat(i.Queue));
    }

    public static void Ifte(Interpreter i)
    {
        new Validator("ifte")
            .ThreeArguments()
            .ThreeQuotes()
            .Validate(i.Stack);
        var f = i.Pop<Node.List>();
        var t = i.Pop<Node.List>();
        var b = i.Pop<Node.List>();
        var p = false;
        i.ExecuteScoped(() =>
        {
            i.Execute(b.Elements);
            p = Node.IsTruthy(i.Pop<INode>());
        });
        if (p)
        {
            i.Execute(t.Elements);
        }
        else
        {
            i.Execute(f.Elements);
        }
    }

    /// <summary>
    /// [B] [A] cat == [B A]
    /// </summary>
    public static void Cat(Interpreter i)
    {
        new Validator("cat")
            .TwoArguments()
            .TwoAggregates()
            .Validate(i.Stack);
        var b = i.Pop<Node.List>();
        var a = i.Pop<Node.List>();
        var z = a.Concat(b);
        i.Push(z);
    }

    /// <summary>
    /// [A] unit == [[A]]
    /// </summary>
    public static void Unit(Interpreter i)
    {
        new Validator("unit")
            .OneArgument()
            .Validate(i.Stack);
        var a = i.Pop<INode>();
        var z = new Node.List(a);
        i.Push(z);
    }

    /// <summary>
    /// [A] [P] map == [B]
    /// </summary>
    public static void Map(Interpreter i)
    {
        new Validator("map")
            .TwoArguments()
            .OneQuote()
            .ListAsSecond()
            .Validate(i.Stack);

        var p = i.Pop<Node.List>();
        var a = i.Pop<Node.List>();
        var z = new List<INode>();
        i.ExecuteScoped(() =>
        {
            foreach (var node in a.Elements)
            {
                i.Push(node);
                i.Execute(p.Elements);
                z.Add(i.Pop<INode>());
            }
        });
        i.Push(new Node.List(z));
    }

    /// <summary>
    /// [A] [P] step == ...
    /// </summary>
    public static void Step(Interpreter i)
    {
        new Validator("step")
            .TwoArguments()
            .OneQuote()
            .AggregateAsSecond()
            .Validate(i.Stack);

        var p = i.Pop<Node.List>();
        var a = i.Pop<IAggregate>();

        if (a.Size == 0)
        {
            return;
        }

        foreach (var node in a.Elements)
        {
            i.Push(node);
            i.Execute(p.Elements);
        }
    }

    /// <summary>
    /// Instead of executing directly this will push the
    /// equivalent of factors onto the execution queue.
    /// </summary>
    /// <remarks>
    /// Flattening operations will eliminate recursion since
    /// the factors to be executed are prepended to the queue
    /// instead.
    /// </remarks>
    public static void FlatStep(Interpreter i)
    {
        new Validator("step")
            .TwoArguments()
            .OneQuote()
            .AggregateAsSecond()
            .Validate(i.Stack);

        var p = i.Pop<Node.List>();
        var a = i.Pop<IAggregate>();

        if (a.Size == 0)
        {
            return;
        }

        var first = a.First();
        var rest = a.Rest();

        var q = new Queue<INode>();
        q.Enqueue(first);
        q.Enqueue(p);
        q.Enqueue(new Node.Symbol("i"));
        q.Enqueue(rest);
        q.Enqueue(p);
        q.Enqueue(new Node.Symbol("step"));

        i.Queue = new Queue<INode>(q.Concat(i.Queue));
    }

    /// <summary>
    ///  TODO
    /// </summary>
    public static void Stack(Interpreter i)
    {
        var xs = new List<INode>();
        var stack = i.Stack;
        for (var j = stack.Count - 1; j >= 0; j--)
        {
            xs.Add(stack[j].Clone());
        }

        i.Push(new Node.List(xs));
    }

    /// <summary>
    ///  TODO
    /// </summary>
    public static void Unstack(Interpreter i)
    {
        new Validator("unstack")
            .OneArgument()
            .ListOnTop()
            .Validate(i.Stack);
        var xs = i.Pop<Node.List>();
        var stack = new C5.ArrayList<INode>();
        stack.AddAll(xs.Elements.Reverse());
        i.Stack = stack;
    }

    public static void Cmp(Interpreter i) => Comprel(i, "cmp");

    public static void Eq(Interpreter i) => Comprel(i, "=");

    public static void Ne(Interpreter i) => Comprel(i, "!=");

    public static void Lt(Interpreter i) => Comprel(i, "<");

    public static void Le(Interpreter i) => Comprel(i, "<=");

    public static void Gt(Interpreter i) => Comprel(i, ">");

    public static void Ge(Interpreter i) => Comprel(i, "ge");

    private static void Comprel(Interpreter i, string op)
    {
        void Comprelf()
        {
            var y = i.Pop<IFloatable>();
            var x = i.Pop<IFloatable>();
            i.Push(floatCmpOps[op](x, y));
        }

        var validator = new Validator(op).TwoArguments();
        var floatp = validator.TwoFloatsOrIntegers();
        if (floatp.TryValidate(i.Stack, out _))
        {
            Comprelf();
            return;
        }

        validator.TwoOrdinalsOnTop().Validate(i.Stack);
        var y = i.Pop<IOrdinal>();
        var x = i.Pop<IOrdinal>();
        i.Push(ordCmpOps[op](x, y));
    }

    // This doesn't work either since it leaves the stack all messed up.
    private static void FlatMap(Interpreter i)
    {
        new Validator("map")
            .TwoArguments()
            .OneQuote()
            .ListAsSecond()
            .Validate(i.Stack);
        var step = new Node.Symbol("step");
        i.Queue = new Queue<INode>(new[] { step }.Concat(i.Queue));
        i.Queue.Enqueue(new Node.Symbol("stack"));
    }
}
