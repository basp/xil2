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
        stack[stack.Count - 1].IsFloatable;

    public static bool Floatable2(C5.IStack<INode> stack) =>
        stack[stack.Count - 1].IsFloatable &&
        stack[stack.Count - 2].IsFloatable;

    public static string GetErrorMessage(string name, string message) =>
        $"{message} needed for `{name}`";

    public static void ThrowBadData(string name) =>
        throw new RuntimeException(
            GetErrorMessage(name, "different type"));

    public static void ThrowBadAggregate(string name) =>
        throw new RuntimeException(
            GetErrorMessage(name, "aggregate"));

    public Validator OneArgument() =>
        this.AddRule(s => s.Count > 0, "one argument");

    public Validator TwoArguments() =>
        this.AddRule(s => s.Count > 1, "two arguments");

    public Validator ThreeArguments() =>
        this.AddRule(s => s.Count > 2, "three arguments");

    public Validator FourArguments() =>
        this.AddRule(s => s.Count > 3, "four arguments");

    public Validator FiveArguments() =>
        this.AddRule(s => s.Count > 4, "five arguments");

    public Validator OneQuote() =>
        this.AddRule(
            s => s[s.Count - 1].Op == Operator.List,
            "quotation as first argument");

    public Validator TwoQuotes() => this.OneQuote()
        .AddRule(
            s => s[s.Count - 2].Op == Operator.List,
            "quotation as second argument");

    public Validator ThreeQuotes() => this.TwoQuotes()
        .AddRule(
            s => s[s.Count - 3].Op == Operator.List,
            "quotation as third argument");

    public Validator FourQuotes() => this.ThreeQuotes()
        .AddRule(
            s => s[s.Count - 4].Op == Operator.List,
            "quotation as fourth argument");

    public Validator SameTwoTypes() =>
        this.AddRule(
            s => s[s.Count - 1].Op == s[s.Count - 2].Op,
            "two arguments of the same type");

    public Validator SymbolOrStringOnTop() =>
        this.AddRule(
            s => s.Last().Op == Operator.Symbol ||
                 s.Last().Op == Operator.String,
            "string or symbol");

    public Validator StringOnTop() =>
        this.AddRule(
            s => s[s.Count - 1].Op == Operator.String,
            "string");

    public Validator StringAsSecond() =>
        this.AddRule(
            s => s[s.Count - 2].Op == Operator.String,
            "string as second argument");

    public Validator FloatOrInteger() =>
        this.AddRule(Floatable, "float or integer");

    public Validator TwoFloatsOrIntegers() =>
        this.AddRule(Floatable2, "two floats or integers");

    public Validator NonZeroOnTop() =>
        this.AddRule(s => !Node.IsZero(s.Last()), "non-zero divisor");

    public Validator AggregateOnTop() =>
        this.AddRule(
            s => s[s.Count - 1].IsAggregate,
            "aggregate");

    public Validator AggregateAsSecond() =>
        this.AddRule(
            s => s[s.Count - 2].IsAggregate,
            "aggregate as second argument");

    public Validator TwoAggregates() =>
        this.AddRule(
            s => s[s.Count - 1].IsAggregate &&
                 s[s.Count - 2].IsAggregate,
            "two aggregate arguments");

    public Validator AddRule(Func<C5.IStack<INode>, bool> p, string message)
    {
        var clone = new Validator(this.name, this.rules);
        clone.rules.Add(new ValidationRule(p, message));
        return clone;
    }

    public bool TryValidate(C5.IStack<INode> stack, out string error)
    {
        error = string.Empty;
        foreach (var rule in this.rules)
        {
            if (!rule.Apply(stack, out var type))
            {
                error = GetErrorMessage(type);
                return false;
            }
        }

        return true;
    }

    public Validator Validate(C5.IStack<INode> stack)
    {
        if (!this.TryValidate(stack, out var error))
        {
            throw new RuntimeException(error);
        }

        return this;
    }

    private string GetErrorMessage(string message) =>
        GetErrorMessage(this.name, message);
}
