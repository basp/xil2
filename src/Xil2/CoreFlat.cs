namespace Xil2;

public class CoreFlat : Interpreter
{
    public CoreFlat()
    {
        this["+"] = new Entry(Operations.Add);
        this["-"] = new Entry(Operations.Subtract);
        this["*"] = new Entry(Operations.Multiply);
        this["/"] = new Entry(Operations.Divide);
        this["%"] = new Entry(Operations.Modulo);
        this["dup"] = new Entry(Operations.Dup);
        this["swap"] = new Entry(Operations.Swap);
        this["zap"] = new Entry(Operations.Zap);
        this["i"] = new Entry(Operations.IFlat);
        this["x"] = new Entry(Operations.XFlat);
        this["dip"] = new Entry(Operations.DipFlat);
        this["cat"] = new Entry(Operations.Cat);
        this["cons"] = new Entry(Operations.Cons);
        this["unit"] = new Entry(Operations.Unit);
        this["map"] = new Entry(Operations.Map);
        this["step"] = new Entry(Operations.FlatStep);
        this["stack"] = new Entry(Operations.Stack);
        this["unstack"] = new Entry(Operations.Unstack);
    }
}