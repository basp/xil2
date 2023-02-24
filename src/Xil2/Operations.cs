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

    // Tries to produce a map equivalent by unrolling
    // everything onto the queue but this needs some
    // tweaking since it doesn't handle the empty list
    // case well (i.e. it doesn't leave an empty list
    // on top of the stack).
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
