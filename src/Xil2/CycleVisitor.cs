namespace Xil2;

using Antlr4.Runtime.Misc;

public class CycleVisitor : JoyBaseVisitor<C5.IStack<INode>>
{
    private static readonly FactorVisitor FactorVisitor = new FactorVisitor();

    private readonly Interpreter interpreter;

    public CycleVisitor([NotNull] Interpreter interpreter)
    {
        this.interpreter = interpreter;
    }

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

        return this.interpreter.Stack;
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
        this.interpreter.AddDefinition(name, factors);
        return this.interpreter.Stack;
    }

    public override C5.IStack<INode> VisitTerm(
        [NotNull] JoyParser.TermContext context)
    {
        var factors = context
            .factor()
            .Select(x => x.Accept(FactorVisitor))
            .ToArray();
        this.interpreter.Eval(factors);
        return this.interpreter.Stack;
    }
}
