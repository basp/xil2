using System.Diagnostics.CodeAnalysis;

namespace Xil2;

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

    public bool Apply(C5.IStack<INode> stack, out string error)
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