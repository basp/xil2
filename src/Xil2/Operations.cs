namespace Xil2;

/// <summary>
/// This class contains predefined operations that can are used
/// by various interpreter cores.
/// </summary>
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

    // [B] [A] swap == [A] [B]
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

    // [A] dup == [A] [A]
    public static void Dup(Interpreter i)
    {
        new Validator("dup")
            .OneArgument()
            .Validate(i.Stack);
        var x = i.Stack.Last();
        i.Push(x.Clone());
    }

    // [A] zap ==
    public static void Zap(Interpreter i)
    {
        new Validator("zap")
            .OneArgument()
            .Validate(i.Stack);
        i.Pop<INode>();
    }

    // [A] x == [A] A.
    public static void X(Interpreter i)
    {
        new Validator("x")
            .OneArgument()
            .OneQuote()
            .Validate(i.Stack);
        var x = i.Peek<Node.List>();
        i.Queue = new Queue<INode>(x.Elements.Concat(i.Queue));
    }

    // [A] i == A
    public static void I(Interpreter i)
    {
        new Validator("i")
            .OneArgument()
            .OneQuote()
            .Validate(i.Stack);
        var x = i.Pop<Node.List>();
        i.Queue = new Queue<INode>(x.Elements.Concat(i.Queue));
    }

    // [B] [A] dip == A [B]
    public static void Dip(Interpreter i)
    {
        new Validator("dip")
            .TwoArguments()
            .OneQuote()
            .Validate(i.Stack);
        var a = i.Pop<Node.List>();
        var b = i.Pop<INode>();
        i.Queue = new Queue<INode>(a.Elements.Append(b).Concat(i.Queue));
    }

    // [B] [A] cat == [B A]
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

    // [B] [A] cons == [[B] A]
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

    // [A] unit == [[A]]
    public static void Unit(Interpreter i)
    {
        new Validator("unit")
            .OneArgument()
            .Validate(i.Stack);
        var a = i.Pop<INode>();
        var z = new Node.List(a);
        i.Push(z);
    }

    // [A] [P] map == [B]
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

    /*
     *                  . [1 2 3] [dup *] step
     *          [1 2 3] . [dup *] step
     *  [1 2 3] [dup *] . step
     *                  . 1 [dup *] i [2 3] [dup *] step
     *                1 . dup * [2 3] [dup *] step
     *              1 1 . * [2 3] [dup *] step
     *                1 . [2 3] [dup *] step
     *          1 [2 3] . [dup *] step
     *  1 [2 3] [dup *] . step
     *                1 . 2 dup * [3] [dup *] step
     *              1 2 . dup * [3] [dup *] step
     *            1 2 2 . * [3] [dup *] step
     *              1 4 . [3] [dup *] step
     *          1 4 [3] . [dup *] step
     *  1 4 [3] [dup *] . step
     *              1 4 . 3 dup *
     *            1 4 3 . dup *
     *          1 4 3 3 . *
     *            1 4 9 . 
     */
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

    /*
     *             . [1] [dup *] map
     *         [1] . [dup *] map
     * [1] [dup *] . map
     *             . 1 [dup *] i [] [dup *] 
     */
    private static void FlatMap(Interpreter i)
    {
        new Validator("map")
            .TwoArguments()
            .OneQuote()
            .ListAsSecond()
            .Validate(i.Stack);

        var p = i.Pop<Node.List>();
        var a = i.Pop<Node.List>();

        if (!a.Elements.Any())
        {
            return;
        }

        var first = a.Elements.First();
        var rest = a.Elements.Skip(1);

        var q = new List<INode>();
        q.Add(first);
        q.AddRange(p.Elements);
        q.Add(new Node.Symbol("swap"));
        q.Add(new Node.Symbol("cons"));
        q.Add(new Node.List(rest));
        q.Add(p);
        q.Add(new Node.Symbol("map"));

        if (rest.Any())
        {
            q.Add(new Node.Symbol("cat"));
        }

        i.Push(new Node.List());
        i.Queue = new Queue<INode>(q.Concat(i.Queue));
    }
}
