namespace Xil2;

using System.Globalization;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

/// <summary>
/// Evaluates factors into a <see cref="INode"/> that can be pushed 
/// onto the stack.
/// </summary>
public class FactorVisitor : XilBaseVisitor<INode>
{
    public override Node VisitBooleanConstant(
        [NotNull] XilParser.BooleanConstantContext context)
    {
        var value = bool.Parse(context.GetText());
        return new Node.Boolean(value)
        {
            Position = GetPosition(context),
        };
    }

    public override Node VisitIntegerConstant(
        [NotNull] XilParser.IntegerConstantContext context)
    {
        var value = int.Parse(context.GetText());
        return new Node.Integer(value)
        {
            Position = GetPosition(context),
        };
    }

    public override Node VisitFloatConstant(
        [NotNull] XilParser.FloatConstantContext context)
    {
        var value = double.Parse(context.GetText(), new CultureInfo("en-US"));
        return new Node.Float(value)
        {
            Position = GetPosition(context),
        };
    }

    public override Node VisitStringConstant(
        [NotNull] XilParser.StringConstantContext context)
    {
        var value = context.GetText().Trim('"');
        return new Node.String(value)
        {
            Position = GetPosition(context),
        };
    }

    public override Node VisitAtomicSymbol(
        [NotNull] XilParser.AtomicSymbolContext context)
    {
        var name = context.GetText();
        return new Node.Symbol(name)
        {
            Position = GetPosition(context),
        };
    }

    public override Node VisitQuotationLiteral(
        [NotNull] XilParser.QuotationLiteralContext context)
    {
        var elements = new List<INode>();
        foreach (var factor in context.term().factor())
        {
            var node = factor.Accept(this);
            elements.Add(node);
        }

        return new Node.List(elements)
        {
            Position = GetPosition(context),
        };
    }

    private static Position GetPosition(ParserRuleContext context) =>
        new Position
        {
            Line = context.Start.Line,
            Column = context.Start.Column,
        };
}
