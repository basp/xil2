using System.Diagnostics.CodeAnalysis;

namespace Xil2;

/// <summary>
/// Provides a stack based interpreter environment for Xil code.
/// </summary>
/// <remarks>
/// <p>
/// This class provides a stack based environment for implementing 
/// an interpreter. It supports evaluating a list of factors and 
/// pushing and popping values onto the stack. It can also be used
/// to store user defined symbols (i.e. definitions).
/// </p>
/// <p>
/// Additionally this class also offers some facilities for creating
/// so called *scoped* actions which restore the stack after the action
/// has completed. These are generally useful for sequential and mapping
/// operations. You can either use the <c>ExecuteScoped</c> or the 
/// <c>CreateSnapshot</c> methods to ensure the stack of the interpreter is
/// restored after the scope ends. 
/// </p>
/// <p>
/// In any case, you can always manipulate the interpreter directly by 
/// mutilating the stack and queue or just setting them to some value.
/// </p>
/// </remarks>
public abstract class Interpreter : Dictionary<string, Entry>
{
    private C5.IStack<INode> stack = new C5.ArrayList<INode>();

    private Queue<INode> queue = new Queue<INode>();

    /// <summary>
    /// Gets or sets the current stack.
    /// </summary>
    public C5.IStack<INode> Stack
    {
        get => this.stack;
        set => this.stack = value;
    }

    /// <summary>
    /// Gets or sets the current queue.
    /// </summary>
    public Queue<INode> Queue
    {
        get => this.queue;
        set => this.queue = value;
    }

    /// <summary>
    /// Creates a snapshot of the current stack and returns
    /// an <see cref="IDisposable"/>. The stack is restored when 
    /// the <see cref="IDisposable"/> is disposed.
    /// </summary>
    public IDisposable CreateSnapshot() => new Snapshot(this);

    /// <summary>
    /// Saves the current stack before executing the given action.
    /// Afterwards the stack is restored to the saved state.
    /// </summary>
    public void ExecuteScoped(Action action)
    {
        using (CreateSnapshot())
        {
            action();
        }
    }

    /// <summary>
    /// Adds a new definition to the interpreter environment.
    /// </summary>
    public virtual void AddDefinition(string name, IEnumerable<INode> body)
    {
        var entry = new Entry(body);
        this.Add(name, entry);
    }

    /// <summary>
    /// Executes a term (i.e. a list of factors).
    /// </summary>
    public virtual List<(INode[], INode[])> Execute(IEnumerable<INode> factors, bool trace = false)
    {
        this.queue = new Queue<INode>(factors);
        var history = new List<(INode[], INode[])>();
        while (this.queue.Any())
        {
            if (trace)
            {
                history.Add((this.stack.ToArray(), this.queue.ToArray()));
            }

            var node = this.queue.Dequeue();
            switch (node.Op)
            {
                case Operand.None:
                    break;
                case Operand.Boolean:
                case Operand.Integer:
                case Operand.Char:
                case Operand.Float:
                case Operand.String:
                case Operand.Set:
                case Operand.List:
                    this.stack.Push(node);
                    break;
                default:
                    var symbol = (Node.Symbol)node;
                    if (this.TryGetValue(symbol.Name, out var entry))
                    {
                        if (entry.IsRuntime)
                        {
                            // If we have a runtime definition we can just
                            // prepend the factors to the queue. This will
                            // enable any tracer to record the step properly.
                            this.queue = new Queue<INode>(entry.Body.Concat(this.queue));
                        }
                        else
                        {
                            // This is apparently a built-in action that we can
                            // only execute in an opaque fashion. This means we
                            // cannot really look what is happening "inside" so
                            // we will not be able to reflect this in the trace.
                            entry.Action(this);
                        }
                    }
                    else
                    {
                        var msg = $"Unknown symbol: {symbol.Name}";
                        throw new RuntimeException(msg);
                    }
                    break;
            }
        }

        // Add final trace to the history if there's something to display.
        if (this.stack.Any() || this.queue.Any())
        {
            history.Add((this.stack.ToArray(), this.queue.ToArray()));
        }

        return history;
    }

    /// <summary>
    /// Peek at the value on top of the stack.
    /// </summary>
    public T Peek<T>() where T : INode => (T)this.stack.Last();

    /// <summary>
    /// Pops a node from the stack.
    /// </summary>
    public T Pop<T>() where T : INode => (T)this.stack.Pop();

    /// <summary>
    /// Pushes a node onto the stack.
    /// </summary>
    public void Push(INode node) => this.stack.Push(node);

    /// <summary>
    /// This represents a snapshot of the interpreter at a particular moment
    /// in time. It will create a a new scope and restores the original
    /// stack when the <see cref="Snapshot"/> is disposed.
    /// </summary>
    private class Snapshot : IDisposable
    {
        private readonly Interpreter i;

        private readonly C5.ArrayList<INode> saved;

        private bool disposed;

        public Snapshot([NotNull] Interpreter i)
        {
            this.i = i;
            this.saved = new C5.ArrayList<INode>();
            this.saved.AddAll(i.Stack);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Restore the original stack.
                    this.i.stack = this.saved;
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
