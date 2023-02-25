namespace Xil2;

/// <summary>
/// Experimental interpreter core.
/// </summary>
public class CoreEx : Interpreter
{
    public CoreEx()
    {
        this["true"] = new Entry(Operations.True);
        this["false"] = new Entry(Operations.False);
        this["+"] = new Entry(Operations.Add);
        this["-"] = new Entry(Operations.Subtract);
        this["*"] = new Entry(Operations.Multiply);
        this["/"] = new Entry(Operations.Divide);
        this["%"] = new Entry(Operations.Modulo);
        this["<"] = new Entry(Operations.Lt);
        this[">"] = new Entry(Operations.Gt);
        this["dup"] = new Entry(Operations.Dup);
        this["swap"] = new Entry(Operations.Swap);
        this["pop"] = new Entry(Operations.Pop);
        this["zap"] = new Entry(Operations.Pop);
        this["i"] = new Entry(Operations.I);
        this["x"] = new Entry(Operations.X);
        this["dip"] = new Entry(Operations.Dip);
        this["cat"] = new Entry(Operations.Cat);
        this["cons"] = new Entry(Operations.Cons);
        this["unit"] = new Entry(Operations.Unit);
        this["map"] = new Entry(Operations.Map);
        this["step"] = new Entry(Operations.Step);
        this["stack"] = new Entry(Operations.Stack);
        this["unstack"] = new Entry(Operations.Unstack);
        this["ifte"] = new Entry(Operations.Ifte);
    }
}
