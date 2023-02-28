namespace Xil2;

using System.Globalization;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

/// <summary>
/// Evaluates factors from the parser into a <see cref="INode"/> that can be 
/// pushed onto the stack.
/// </summary>
public class FactorVisitor : XilBaseVisitor<INode>
{
    public override Node VisitBooleanConstant(
        [NotNull] XilParser.BooleanConstantContext context)
    {
        var value = bool.Parse(context.GetText());
        return Node.Boolean.Get(value);
    }

    public override Node VisitIntegerConstant(
        [NotNull] XilParser.IntegerConstantContext context)
    {
        var value = int.Parse(context.GetText());
        return Node.Integer.Get(value);
    }

    public override Node VisitFloatConstant(
        [NotNull] XilParser.FloatConstantContext context)
    {
        var value = double.Parse(context.GetText(), new CultureInfo("en-US"));
        return new Node.Float(value);
    }

    public override Node VisitStringConstant(
        [NotNull] XilParser.StringConstantContext context)
    {
        var value = context.GetText().Trim('"');
        return new Node.String(value);
    }

    public override Node VisitAtomicSymbol(
        [NotNull] XilParser.AtomicSymbolContext context)
    {
        var name = context.GetText();
        return Node.Symbol.Get(name);
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

        return new Node.List(elements);
    }
}
