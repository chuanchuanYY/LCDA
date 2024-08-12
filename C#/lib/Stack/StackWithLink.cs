
namespace Lib.Stack;


// 链表实现
public class StackWithLink<TValue> : IStack<TValue>
{

    #region  Link Node 
    class ValueNode
    {
        public TValue Value {get;set;}
        public ValueNode? Next {get;set;}


        public ValueNode(TValue value)
        {
            Value = value;
        }
    }
    #endregion

    private  ValueNode? _head;
    public int Count { get; private set; }


    public IEnumerable<TValue> AsEnumerable()
    {
        while(_head != null)
        {
            yield return _head.Value;
            _head = _head.Next;
        }
    }
    public TValue Peek()
    {
        if(_head == null)
        {
            // 如果是值类型 返回默认值 比如int为0
            // 引用类型返回 null
            return default!; 
        }
        return _head.Value;
    }

    public TValue Pop()
    {
        if(_head == null)
        {
            return default!;
        }
        var result = _head.Value;
        _head = _head.Next!;
        Count--;
        return result;
    }

    public void Push(TValue value)
    {
        var newNode = new ValueNode(value);
        newNode.Next = _head;
        _head = newNode;
        Count++;
    }
}

