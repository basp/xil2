namespace Xil2;

/// <summary>
/// Experimental interpreter core based on http://tunes.org/~iepos/joy.html
/// </summary>
public class CoreEx : Interpreter
{
    public CoreEx()
    {
        this["+"] = Operations.Add;
        this["-"] = Operations.Subtract;
        this["*"] = Operations.Multiply;
        this["/"] = Operations.Divide;
        this["dup"] = Operations.Dup;
        this["swap"] = Operations.Swap;
        this["zap"] = Operations.Zap;
        this["i"] = Operations.I;
        this["dip"] = Operations.Dip;
        this["cat"] = Operations.Cat;
        this["cons"] = Operations.Cons;
        this["unit"] = Operations.Unit;
    }
}
