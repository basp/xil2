namespace Xil2.Old;

using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Represents a symbol to the interpreter. This can either
/// be a built-in (represented by a <see cref="Action"/> instance)
/// or a *user-defined* symbol that is represented by a body
/// of <see cref="INode"/> instances. The <c>IsUserDefined</c> property
/// can be queried to find out whether the <c>Action</c> or <c>Body</c>
/// property is relevant.
/// </summary>
public class Entry
{
    /// <summary>
    /// Creates a new <see cref="Entry"/> instance that points to a built-in
    /// (i.e. something defined at compile time).
    /// </summary>
    public Entry(Action<Interpreter> action)
    {
        this.Action = action;
        this.Effect = string.Empty;
        this.Body = Array.Empty<INode>();
    }

    /// <summary>
    /// Createa new <see cref="Entry"/> instance that points to a user 
    /// definition (i.e. something defined at runtime).
    /// </summary>
    public Entry([NotNull] IEnumerable<INode> body)
    {
        this.Action = i => { };
        this.Effect = string.Empty;
        this.Body = body;
    }

    /// <summary>
    /// Gets the <see cref="Action"/> associated with this entry.
    /// </summary>
    public Action<Interpreter> Action { get; }

    /// <summary>
    /// Gets a string describing the stack effect when this entry is executed.
    /// </summary>
    public string Effect { get; }

    /// <summary>
    /// Gets the <see cref="INode"/> instances that are the body of this entry.
    /// </summary>
    public IEnumerable<INode> Body { get; }

    /// <summary>
    /// Gets a value that indicates whether this entry that is defined
    /// during runtime.
    /// </summary>
    public bool IsRuntime => this.Body.Any();
}