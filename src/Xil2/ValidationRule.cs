using System.Diagnostics.CodeAnalysis;

namespace Xil2;

/// <summary>
/// <p>
/// A <see cref="ValidationRule"/> instance is a combination of a 
/// predicate that takes one argument (the stack) and a message 
/// that describes the problem in case the predicate fails.
/// </p>
/// <p>
/// These rules are applied to the stack at runtime by the stack 
/// validator. The stack validator is invoked by the operations that 
/// are built into the <see cref="Interpreter"/> instance that is
/// in use at runtime.
/// </p>
/// </summary>
internal class ValidationRule
{
    private readonly Func<C5.IStack<INode>, bool> predicate;

    private readonly string message;

    public ValidationRule(
        [NotNull] Func<C5.IStack<INode>, bool> predicate,
        [NotNull] string message)
    {
        this.predicate = predicate;
        this.message = message;
    }

    /// <summary>
    /// Applies the predicate from this rule to the given stack.
    /// </summary>
    public bool Verify(C5.IStack<INode> stack, out string error)
    {
        error = string.Empty;
        if (!this.predicate(stack))
        {
            error = this.message;
            return false;
        }

        return true;
    }
}
