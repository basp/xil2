namespace Xil2;

/// <summary>
/// This is thrown when there are not enough arguments
/// on the stack, the arguments on the stack do not
/// match up with the parameters of the operation or when
/// some other runtime invariant is violated.
/// </summary>
/// <remarks>
/// This should generally be used to indicate that some
/// stack expectation failed. In other words, the stack is
/// not in the state that we expect it to be. This is usually
/// caused by user errors (i.e. bad code) and we don't really
/// want to combat this. However, we do what these kinds of
/// errors to be distinct from bugs/missing operations in the
/// runtime itself.
/// </remarks>
public class RuntimeException : Exception
{
    public RuntimeException()
    {
    }

    public RuntimeException(string message)
        : base(message)
    {
    }

    public RuntimeException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
