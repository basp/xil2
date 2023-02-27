namespace Xil2;

public class Interpreter2
{
    public C5.IStack<INode> Stack { get; set; } =
        new C5.ArrayList<INode>();

    public Queue<Node.List> Queue { get; set; } =
        new Queue<Node.List>();

    private IDictionary<string, Entry> Env { get; set;} =
        new Dictionary<string, Entry>();
}