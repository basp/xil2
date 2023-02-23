namespace Xil2;

using Antlr4.Runtime.Misc;

public class CycleVisitor : JoyBaseVisitor<C5.IStack<INode>>
{
    private static readonly FactorVisitor FactorVisitor =
        new FactorVisitor();

    private readonly IDictionary<string, Action> definitions;

    private readonly C5.IStack<INode> stack = new C5.ArrayList<INode>();

    public CycleVisitor()
    {
        this.definitions = new Dictionary<string, Action>
        {
            ["+"] = this.Add,
            ["-"] = this.Subtract,
            ["*"] = this.Multiply,
            ["/"] = this.Divide,
            ["dup"] = this.Dup,
            ["swap"] = this.Swap,
            ["zap"] = this.Pop,
            ["pop"] = this.Pop,
            ["i"] = this.I,
            ["dip"] = this.Dip,
            ["cat"] = this.Cat,
            ["cons"] = this.Cons,
            ["unit"] = this.Unit,
        };
    }

    public C5.IStack<INode> Stack => this.stack;

    public IDictionary<string, Action> Definitions => this.definitions;

    public override C5.IStack<INode> VisitCycle(
        [NotNull] JoyParser.CycleContext context)
    {
        if (context.simpleDefinition() != null)
        {
            return context.simpleDefinition().Accept(this);
        }

        if (context.term() != null)
        {
            return context.term().Accept(this);
        }

        return this.stack;
    }

    public override C5.IStack<INode> VisitSimpleDefinition(
        [NotNull] JoyParser.SimpleDefinitionContext context)
    {
        var name = context
            .atomicSymbol()
            .GetText();
        var factors = context
            .term()
            .factor()
            .Select(x => x.Accept(FactorVisitor))
            .ToList();
        this.definitions.Add(name, () => Eval(factors));
        return this.stack;
    }

    public override C5.IStack<INode> VisitTerm(
        [NotNull] JoyParser.TermContext context)
    {
        var factors = context
            .factor()
            .Select(x => x.Accept(FactorVisitor))
            .ToArray();
        this.Eval(factors);
        return this.stack;
    }

    private void Add()
    {
        var y = this.Pop<IFloatable>();
        var x = this.Pop<IFloatable>();
        this.Push(x.Add(y));
    }

    private void Subtract()
    {
        var y = this.Pop<IFloatable>();
        var x = this.Pop<IFloatable>();
        this.Push(x.Subtract(y));
    }

    private void Multiply()
    {
        var y = this.Pop<IFloatable>();
        var x = this.Pop<IFloatable>();
        this.Push(x.Multiply(y));
    }

    private void Divide()
    {
        var y = this.Pop<IFloatable>();
        var x = this.Pop<IFloatable>();
        this.Push(x.Divide(y));
    }

    // [B] [A] swap == [A] [B]
    private void Swap()
    {
        var y = this.Pop<INode>();
        var x = this.Pop<INode>();
        this.Push(y);
        this.Push(x);
    }

    // [A] dup == [A] [A]
    private void Dup()
    {
        var x = this.stack.Last();
        this.Push(x.Clone());
    }

    // [A] zap ==
    private void Pop()
    {
        this.Pop<INode>();
    }

    // [A] i == A
    private void I()
    {
        var x = this.Pop<Node.List>();
        this.Eval(x.Elements);
    }

    // [B] [A] dip == A [B]
    private void Dip()
    {
        var y = this.Pop<Node.List>();
        var x = this.Pop<INode>();
        this.Eval(y.Elements);
        this.Push(x);
    }

    // [B] [A] cat == [B A]
    private void Cat()
    {
        new Validator("cat")
            .TwoArguments()
            .TwoAggregates()
            .Validate(this.stack);
        var b = this.Pop<Node.List>();
        var a = this.Pop<Node.List>();
        var z = a.Concat(b);
        this.Push(z);
    }

    // [B] [A] cons == [[B] A]
    private void Cons()
    {
        new Validator("cons")
            .TwoArguments()
            .AggregateOnTop()
            .Validate(this.stack);
        var a = this.Pop<IAggregate>();
        var b = this.Pop<INode>();
        var z = a.Cons(b);
        this.Push(z);
    }

    // [A] unit == [[A]]
    private void Unit()
    {
        new Validator("unit")
            .OneArgument()
            .Validate(this.stack);
        var a = this.Pop<INode>();
        var z = new Node.List(a);
        this.Push(z);
    }

    private T Pop<T>() where T : INode => (T)this.stack.Pop();

    private void Push(INode value) => this.stack.Push(value);

    private void Eval(IEnumerable<INode> factors)
    {
        foreach (var node in factors)
        {
            switch (node.Op)
            {
                case Operator.None:
                    break;
                case Operator.Boolean:
                case Operator.Integer:
                case Operator.Char:
                case Operator.Float:
                case Operator.String:
                case Operator.Set:
                case Operator.List:
                    this.stack.Push(node);
                    break;
                default:
                    var symbol = (Node.Symbol)node;
                    if (this.definitions.TryGetValue(
                        symbol.Name,
                        out var action))
                    {
                        action();
                    }
                    break;
            }
        }
    }
}
