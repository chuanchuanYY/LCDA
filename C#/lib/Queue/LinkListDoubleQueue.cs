
namespace Lib.Queue;

public class LinkListDoubleQueue<TValue> : IDoubleQueue<TValue>
{
    private class Node
    {
        public TValue Value { get; set; } = default!;
        public Node? Next { get; set; }
        public Node? Prev { get; set; }
    }

    private Node? _font;
    private Node? _tail;

    public int Count { get; private set; }

    public IEnumerable<TValue> AsEnumerable()
    {
        var temp = _font;
        while(temp != null)
        {
            yield return temp.Value;
            temp = temp.Next;
        }
    }
    public bool IsEmpty() => Count == 0;
    public TValue? PeekFirst()
    {
        return Peek(true);
    }

    public TValue? PeekLast()
    {
        return Peek(false);
    }

    public TValue? PopFirst()
    {
        return Pop(true);
    }

    public TValue? PopLast()
    {
        return Pop(false);
    }

    public void PushFirst(TValue value)
    {
        Push(value,true);
    }

    public void PushLast(TValue value)
    {
        Push(value,false);
    }

    private TValue? Peek(bool isFont)
    {
        if(IsEmpty())
        {
            return default!;
        }
        return isFont ? _font!.Value : _tail!.Value;
    }
    private TValue? Pop(bool isFont)
    {
        if(IsEmpty())
        {
            return default!;
        }
        if(isFont)
        {
            var temp  = _font;
            _font = _font!.Next;
            temp!.Next = null;
            if(_font != null)
            _font.Prev = null;
            Count --;
            return temp.Value;
        }
        else 
        {
            var temp = _tail;
            _tail = _tail!.Prev;
            temp!.Prev = null;
            if(_tail != null)
            _tail!.Next = null;
            Count --;
            return temp.Value;
        }
        
    }
    private void Push(TValue value, bool isFont)
    {
        var newNode = new Node{Value = value};
        if(IsEmpty())
        {
            _font = newNode;
            _tail = newNode;
        }
        else
        {
            if(isFont)
            {
                _font!.Prev = newNode;
                newNode.Next = _font;
                _font = newNode;
            }
            else 
            {
                _tail!.Next = newNode;
                newNode.Prev = _tail;
                _tail = newNode;
            }
        }
        Count ++;
    }
}