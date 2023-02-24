namespace Xil2;

using Antlr4.Runtime.Misc;

/// <summary>
/// Used to interpret cycles in an interactive environment.
/// </summary>
public class CycleVisitor : XilBaseVisitor<C5.IStack<INode>>
{
    protected static readonly FactorVisitor FactorVisitor = new FactorVisitor();

    protected readonly Interpreter interpreter;

    public CycleVisitor([NotNull] Interpreter interpreter)
    {
        this.interpreter = interpreter;
    }

    /// <summary>
    /// Interprets a user cycle which can either be a simple 
    /// definition or a term. Definitions are stored in the
    /// interpreter environment for later evaluation and
    /// terms are evaluated on the stack immediately.
    /// </summary>
    public override C5.IStack<INode> VisitCycle(
        [NotNull] XilParser.CycleContext context)
    {
        if (context.simpleDefinition() != null)
        {
            return context.simpleDefinition().Accept(this);
        }

        if (context.term() != null)
        {
            return context.term().Accept(this);
        }

        // If we are neither a `simpleDefinition` or a `term` then we can 
        // safely regard the input as junk and just return the stack.
        return this.interpreter.Stack;
    }

    /// <summary>
    /// Stores a user-defined defintion in the interpreter environment.
    /// </summary>
    public override C5.IStack<INode> VisitSimpleDefinition(
        [NotNull] XilParser.SimpleDefinitionContext context)
    {
        var name = context
            .atomicSymbol()
            .GetText();
        var factors = context
            .term()
            .factor()
            .Select(x => x.Accept(FactorVisitor))
            .ToList();
        this.interpreter.AddDefinition(name, factors);
        return this.interpreter.Stack;
    }

    /// <summary>
    /// Evaluates a term in the interpreter environment.
    /// </summary>
    public override C5.IStack<INode> VisitTerm(
        [NotNull] XilParser.TermContext context)
    {
        var factors = context
            .factor()
            .Select(x => x.Accept(FactorVisitor))
            .ToArray();
        this.interpreter.Execute(factors);
        return this.interpreter.Stack;
    }
}
