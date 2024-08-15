
namespace Lib.Queue;

public class LinkListQueue<Tvalue> : IQueue<Tvalue>
{
    private class ValueNode
    {
        public Tvalue? Value {get;set;}
        public ValueNode? Next {get;set;} = default;
    }
    private ValueNode? _font = null;
    private ValueNode? _tail = null;

    public int Count {get;private set;} = 0;

    public IEnumerable<Tvalue> AsEnumerable()
    {
        var temp = _font;
        while(temp != null)
        {
            yield return temp.Value!;
            temp = temp.Next;
        }
    }
    public bool IsEmpty() => Count == 0;
    public Tvalue? Peek()
    {
        if(_font == null)
        {
            return default!;
        }
        return _font.Value;
    }

    public Tvalue? Pop()
    {
        if(_font == null)
        {
            return default!;
        }
        var result = _font;
        _font = _font!.Next;
        Count--;
        return result.Value;
    }

    public void Push(Tvalue value)
    {
        var newNode = new ValueNode { Value = value};

        if(_font == null)
        {
            _font = newNode;
            _tail = newNode;
            Count++;
        }
        else 
        {
            _tail!.Next = newNode;
            _tail = _tail.Next;
            Count++;
        }
    }
}