namespace Xil2;

using System.Globalization;
using Antlr4.Runtime.Misc;

public class FactorVisitor : JoyBaseVisitor<Node>
{
    public override Node VisitBooleanConstant(
        [NotNull] JoyParser.BooleanConstantContext context)
    {
        var value = bool.Parse(context.GetText());
        return new Node.Boolean(value)
        {
            Position = new Position
            {
                Line = context.Start.Line,
                Column = context.Start.Column,
            },
        };
    }

    public override Node VisitIntegerConstant(
        [NotNull] JoyParser.IntegerConstantContext context)
    {
        var value = int.Parse(context.GetText());
        return new Node.Integer(value);
    }

    public override Node VisitFloatConstant(
        [NotNull] JoyParser.FloatConstantContext context)
    {
        var value = double.Parse(context.GetText(), new CultureInfo("en-US"));
        return new Node.Float(value);
    }

    public override Node VisitStringConstant(
        [NotNull] JoyParser.StringConstantContext context)
    {
        var value = context.GetText().Trim('"');
        return new Node.String(value);
    }

    public override Node VisitAtomicSymbol(
        [NotNull] JoyParser.AtomicSymbolContext context)
    {
        var name = context.GetText();
        return new Node.Symbol(name);
    }

    public override Node VisitQuotationLiteral(
        [NotNull] JoyParser.QuotationLiteralContext context)
    {
        var elements = new List<Node>();
        foreach (var factor in context.term().factor())
        {
            var node = factor.Accept(this);
            elements.Add(node);
        }

        return new Node.List(elements);
    }
}