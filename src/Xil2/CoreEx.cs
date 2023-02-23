namespace Xil2;

/// <summary>
/// Experimental interpreter core based on http://tunes.org/~iepos/joy.html
/// </summary>
public class CoreEx : Interpreter
{
    public CoreEx()
    {
        this["+"] = this.Add;
        this["-"] = this.Subtract;
        this["*"] = this.Multiply;
        this["/"] = this.Divide;        
        this["dup"] = this.Dup;
        this["swap"] = this.Swap;
        this["zap"] = this.Pop;
        this["i"] = this.I;
        this["dip"] = this.Dip;
        this["cat"] = this.Cat;
        this["cons"] = this.Cons;
        this["unit"] = this.Unit;
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
        var x = this.Stack.Last();
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
            .Validate(this.Stack);
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
            .Validate(this.Stack);
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
            .Validate(this.Stack);
        var a = this.Pop<INode>();
        var z = new Node.List(a);
        this.Push(z);
    }
}
