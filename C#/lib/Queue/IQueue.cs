namespace Lib.Queue;

public interface IQueue<TValue>
{
    void Push(TValue value);
    TValue? Pop();
    TValue? Peek();

}