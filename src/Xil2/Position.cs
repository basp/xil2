namespace Xil2;

/// <summary>
/// This associates a <see cref="INode"/> with
/// a position in the original source file in case we
/// need to report any errors.
/// </summary>
public struct Position
{
    public int Line;

    public int Column;
}
