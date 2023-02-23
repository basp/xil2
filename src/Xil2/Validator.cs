namespace Xil2;

public class Validator
{
    private readonly string name;

    private readonly List<ValidationRule> rules = new List<ValidationRule>();

    public Validator(string name)
    {
        this.name = name;
    }

    private Validator(string name, List<ValidationRule> rules)
        : this(name)
    {
        this.rules = rules;
    }

    public static bool Floatable(C5.IStack<INode> stack) =>
        stack[stack.Count - 1].Op == Operator.Integer ||
        stack[stack.Count - 1].Op == Operator.Float;

    public static string GetErrorMessage(string name, string message) =>
        $"{message} needed for `{name}`";
}