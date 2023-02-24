namespace Xil2;

/// <summary>
/// Experimental interpreter core based on http://tunes.org/~iepos/joy.html
/// </summary>
public class CoreEx : Interpreter
{
    public CoreEx()
    {
        this["+"] = new Entry(Operations.Add);
        this["-"] = new Entry(Operations.Subtract);
        this["*"] = new Entry(Operations.Multiply);
        this["/"] = new Entry(Operations.Divide);
        this["%"] = new Entry(Operations.Modulo);
        this["dup"] = new Entry(Operations.Dup);
        this["swap"] = new Entry(Operations.Swap);
        this["zap"] = new Entry(Operations.Zap);
        this["i"] = new Entry(Operations.I);
        this["x"] = new Entry(Operations.X);
        this["dip"] = new Entry(Operations.Dip);
        this["cat"] = new Entry(Operations.Cat);
        this["cons"] = new Entry(Operations.Cons);
        this["unit"] = new Entry(Operations.Unit);
        this["map"] = new Entry(Operations.Map);
    }
}
