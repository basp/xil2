namespace Joy;

public interface INode
{
    Operator Op { get; }   

    INode Clone();
}