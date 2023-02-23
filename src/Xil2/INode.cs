namespace Xil2;

/// <summary>
/// Provides the main interface for runtime values. These are values that
/// can be pushed onto the stack.
/// </summary>
/// <remarks>
/// A runtime value can either be a primitive or quotation. 
/// The latter is a list which is also a program.
/// Lists of values are pretty much treated like quotations.
/// </remarks>
public interface INode
{
    /// <summary>
    /// Gets the position of this node in the original source code.
    /// </summary>
    Position Position { get; }

    /// <summary>
    /// Gets the type (i.e. list, integer, float, etc.) of this node.
    /// </summary>
    Operator Op { get; }   

    /// <summary>
    /// Creates a deep clone of this <see cref="INode"/> value.
    /// </summary>
    /// <remarks>
    /// Note that this creates a new value that is unique. It does not have
    /// any references to its origin anymore.
    /// </remarks>
    INode Clone();

    /// <summary>
    /// Returns <c>true</c> if this is a <see cref="IFloatable"/>
    /// otherwise <c>false</c>.
    /// </summary>
    bool IsFloatable { get; }

    /// <summary>
    /// Returns <c>true</c> if this is a <see cref="IAggregate"/>
    /// otherwise <c>false</c>.
    /// </summary>
    bool IsAggregate { get; }

    /// <summary>
    /// Returns <c>true</c> if this is a <see cref="IOrdinal"/>
    /// otherwise <c>false</c>.
    /// </summary>
    bool IsOrdinal { get; }

    /// <summary>
    /// Returns a <see cref="string"/> representation of what
    /// this value would look like in code.
    /// </summary>
    string ToRepresentation();
}
