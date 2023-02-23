namespace Xil2;

/// <summary>
/// <p>
/// A stack <see cref="Validator"/> instance is used to inspect the
/// stack during runtime operations and to throw a 
/// <see cref="RuntimeException"/> in case the stack does not meet
/// expectations. 
/// </p>
/// <p>
/// In particular this is used to verify the amount and kinds of nodes that 
/// are on the stack before commencing an operation. If the validation
/// fails the operation will not be executed and a 
/// <see cref="RuntimeException"/> will be thrown instead. This will give
/// some additional feedback in the interactive and also will make it less
/// likely that the current stack will be mutilated by an inproper operation.
/// </p>
/// </summary>
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

    /// <summary>
    /// Verifies that the argument on top of the stack is a
    /// <see cref="IFloatable"/> instance.
    /// </summary>
    public static bool Floatable(C5.IStack<INode> stack) =>
        stack[stack.Count - 1].IsFloatable;

    /// <summary>
    /// Verifies that the two arguments on top of the stack are
    /// <see cref="IFloatable"/> instances.
    /// </summary>
    public static bool Floatable2(C5.IStack<INode> stack) =>
        stack[stack.Count - 1].IsFloatable &&
        stack[stack.Count - 2].IsFloatable;

    /// <summary>
    /// Returns a standard error message informing the user
    /// that a particular kind of argument is needed for the 
    /// named operation.
    /// </summary>
    public static string GetErrorMessage(string name, string message) =>
        $"{message} needed for `{name}`";

    /// <summary>
    /// Throws a <see cref="RuntimeException"/> informing the user
    /// that an argument for the named operation is of an incorrect type.
    /// </summary>
    public static void ThrowBadData(string name) =>
        throw new RuntimeException(
            GetErrorMessage(name, "different type"));

    /// <summary>
    /// Throws a <see cref="RuntimeException"/> informing the user
    /// that an argument for the named operation should be an aggregate.
    /// </summary>
    public static void ThrowBadAggregate(string name) =>
        throw new RuntimeException(
            GetErrorMessage(name, "aggregate"));

    /// <summary>
    /// Verifies that there is at least one argument on the stack.
    /// </summary>
    public Validator OneArgument() =>
        this.AddRule(s => s.Count > 0, "one argument");

    /// <summary>
    /// Verifies that there are at least two arguments on the stack.
    /// </summary>
    public Validator TwoArguments() =>
        this.AddRule(s => s.Count > 1, "two arguments");

    /// <summary>
    /// Verifies that there are at least three arguments on the stack.
    /// </summary>
    public Validator ThreeArguments() =>
        this.AddRule(s => s.Count > 2, "three arguments");

    /// <summary>
    /// Verifies that there are at least four arguments on the stack.
    /// </summary>
    public Validator FourArguments() =>
        this.AddRule(s => s.Count > 3, "four arguments");

    /// <summary>
    /// Verifies that there are at least five arguments on the stack.
    /// </summary>
    public Validator FiveArguments() =>
        this.AddRule(s => s.Count > 4, "five arguments");

    /// <summary>
    /// Verifies that the value on top of the stack qualifies as a quotation.
    /// </summary>
    public Validator OneQuote() =>
        this.AddRule(
            s => s[s.Count - 1].Op == Operator.List,
            "quotation as first argument");

    /// <summary>
    /// Verifies that the top two values on the stack qualify as a quotation.
    /// </summary>
    public Validator TwoQuotes() => this.OneQuote()
        .AddRule(
            s => s[s.Count - 2].Op == Operator.List,
            "quotation as second argument");

    /// <summary>
    /// Verifies that the top three values on the stack qualify as a quotation.
    /// </summary>
    public Validator ThreeQuotes() => this.TwoQuotes()
        .AddRule(
            s => s[s.Count - 3].Op == Operator.List,
            "quotation as third argument");

    /// <summary>
    /// Verifies that the top four values on the stack qualify as a quotation.
    /// </summary>
    public Validator FourQuotes() => this.ThreeQuotes()
        .AddRule(
            s => s[s.Count - 4].Op == Operator.List,
            "quotation as fourth argument");

    /// <summary>
    /// Verifies that the top two arguments on the stack are of the same type.
    /// </summary>
    public Validator SameTwoTypes() =>
        this.AddRule(
            s => s[s.Count - 1].Op == s[s.Count - 2].Op,
            "two arguments of the same type");

    /// <summary>
    /// Verifies that the top argument on the stack is either a
    /// <see cref="Node.Symbol"/> or a <see cref="Node.String"/>.
    /// </summary>
    public Validator SymbolOrStringOnTop() =>
        this.AddRule(
            s => s.Last().Op == Operator.Symbol ||
                 s.Last().Op == Operator.String,
            "string or symbol");

    /// <summary>
    /// Verifies that the top argument on the stack is a 
    /// <see cref="Node.String"/>.
    /// </summary>
    public Validator StringOnTop() =>
        this.AddRule(
            s => s[s.Count - 1].Op == Operator.String,
            "string");

    /// <summary>
    /// Verifies that the second argument on the stack is a
    /// <see cref="Node.String"/>.
    /// </summary>
    public Validator StringAsSecond() =>
        this.AddRule(
            s => s[s.Count - 2].Op == Operator.String,
            "string as second argument");

    /// <summary>
    /// Verifies that the top argument on the stack is a
    /// <see cref="Node.Float"/> or <see cref="Node.Integer"/>.
    /// </summary>
    public Validator FloatOrInteger() =>
        this.AddRule(Floatable, "float or integer");

    /// <summary>
    /// Verifies that the top two arguments on the stack are either
    /// <see cref="Node.Float"/> or <see cref="Node.Integer"/> instances.
    /// </summary>
    public Validator TwoFloatsOrIntegers() =>
        this.AddRule(Floatable2, "two floats or integers");

    /// <summary>
    /// Verifies that the top of the stack contains a non-zero value.
    /// </summary>
    public Validator NonZeroOnTop() =>
        this.AddRule(s => !Node.IsZero(s.Last()), "non-zero divisor");

    /// <summary>
    /// Verifies that there is a <see cref="IAggregate"/> on top of the stack.
    /// </summary>
    public Validator AggregateOnTop() =>
        this.AddRule(
            s => s[s.Count - 1].IsAggregate,
            "aggregate");

    /// <summary>
    /// Verifies that the second argument on the stack is a 
    /// <see cref="IAggregate"/>.
    /// </summary>
    public Validator AggregateAsSecond() =>
        this.AddRule(
            s => s[s.Count - 2].IsAggregate,
            "aggregate as second argument");

    /// <summary>
    /// Verifies that there are two <see cref="IAggregate"/> instances
    /// on top of the stack.
    /// </summary>
    public Validator TwoAggregates() =>
        this.AddRule(
            s => s[s.Count - 1].IsAggregate &&
                 s[s.Count - 2].IsAggregate,
            "two aggregate arguments");

    /// <summary>
    /// Adds a rule to this validator's rule listing.
    /// </summary>
    public Validator AddRule(Func<C5.IStack<INode>, bool> p, string message)
    {
        var clone = new Validator(this.name, this.rules);
        clone.rules.Add(new ValidationRule(p, message));
        return clone;
    }

    /// <summary>
    /// Tries to validate the given stack with the rules currently
    /// associated with this validator. It will return <c>false</c>
    /// and set <c>error</c> with an appropriate message in case 
    /// validation fails. Otherwise it will return true and <c>error</c> 
    /// will be an empty string.
    /// </summary>
    public bool TryValidate(C5.IStack<INode> stack, out string error)
    {
        error = string.Empty;
        foreach (var rule in this.rules)
        {
            if (!rule.Verify(stack, out var type))
            {
                error = GetErrorMessage(type);
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Validates the given stack and throws a <see cref="RuntimeException"/>
    /// if validation fails. If validation succeeds it will return itself.
    /// </summary>
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
