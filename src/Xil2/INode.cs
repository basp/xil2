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
    /// Gets the type (i.e. list, integer, float, etc.) of this node.
    /// </summary>
    Operand Op { get; }   

    /// <summary>
    /// Creates a deep clone of this <see cref="INode"/> value.
    /// </summary>
    /// <remarks>
    /// Note that this creates a new <see cref="INode"/> that is unique. 
    /// It does not have any references to its origin anymore.
    /// </remarks>
    INode Clone();

    /// <summary>
    /// Returns a <c>bool</c> indicating whether this is a 
    /// <see cref="IFloatable"/>.
    /// </summary>
    bool IsFloatable { get; }

    /// <summary>
    /// Returns a <c>bool</c> indicating whether this is a 
    /// <see cref="IAggregate"/>.
    /// </summary>
    bool IsAggregate { get; }

    /// <summary>
    /// Returns a <c>bool</c> indicating whether this is a 
    /// <see cref="IOrdinal"/>.
    /// </summary>
    bool IsOrdinal { get; }

    /// <summary>
    /// Returns a value indicating whether this node is a quotation (i.e. a 
    /// list that contains symbols).
    /// </summary>
    bool IsQuote { get; }

    /// <summary>
    /// Returns a <see cref="string"/> representation of what this value would 
    /// look like in code.
    /// </summary>
    string ToRepresentation();
}
