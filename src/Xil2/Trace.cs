using System.Text;

namespace Xil2;

public class Trace : List<(INode[], INode[])>
{
    public override string ToString() => TraceToString(this);

    public void Record(Interpreter i)
    {
        var stackNodes = i.Stack.ToArray();
        var queueNodes = i.Queue.SelectMany(x => x.Elements).ToArray();
        this.Add((stackNodes, queueNodes));
    }

    private static string TraceToString(List<(INode[], INode[])> history)
    {
        var buf = new StringBuilder();
        var lines = history.Select(x => new
        {
            Stack = string.Join(' ', x.Item1.Select(x => x.ToRepresentation())),
            Queue = string.Join(' ', x.Item2.Select(x => x.ToRepresentation())),
        });

        var padding = lines.Max(x => x.Stack.Length);
        foreach (var t in lines)
        {
            buf.Append(t.Stack.PadLeft(padding));
            buf.Append(" . ");
            buf.Append(t.Queue);
            buf.AppendLine();
        }

        return buf.ToString();
    }
}