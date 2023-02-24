using Antlr4.Runtime.Misc;
using C5;

namespace Xil2;

public class TracingCycleVisitor : CycleVisitor
{
    public TracingCycleVisitor([NotNull] Interpreter interpreter)
        : base(interpreter)
    {
    }

    public override IStack<INode> VisitTerm(
        [NotNull] XilParser.TermContext context)
    {
        var factors = context
            .factor()
            .Select(x => x.Accept(FactorVisitor))
            .ToArray();

        var trace = this.interpreter.Execute(factors, trace: true);
        var strings = trace.Select(t => new
        {
            Stack = string.Join(' ', t.Item1.Select(x => x.ToRepresentation())),
            Queue = string.Join(' ', t.Item2.Select(x => x.ToRepresentation())),
        });

        if (!strings.Any())
        {
            return this.interpreter.Stack;
        }

        Console.WriteLine();

        // Calculate left padding based on the longest stack string in the
        // trace to make sure everything aligns nicely in the output.
        var padding = strings.Max(x => x.Stack.Length);
        foreach (var t in trace)
        {
            var stack = t.Item1.Select(x => x.ToRepresentation());
            var queue = t.Item2.Select(x => x.ToRepresentation());
            Console.WriteLine(
                string.Concat(
                    string.Join(' ', stack.ToArray()).PadLeft(padding),
                    " . ",
                    string.Join(' ', queue.ToArray())));
        }

        return this.interpreter.Stack;
    }
}