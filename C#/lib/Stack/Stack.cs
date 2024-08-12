using System.Drawing;

namespace Lib.Stack;

// 数组实现
public class Stack<TValue> : IStack<TValue>
{
    // default size of _arr 
    private const int SIZE = 10; 
    private TValue[] _arr;
    // index point to stack top 
    private int _top = 0;
    public int Count {get;private set;} = 0;
    public Stack()
    {
        _arr = new TValue[SIZE];
    }

    public IEnumerable<TValue> AsEnumerable()
    {
        for(int i=_top -1 ; i>=0;i--)
        {
            yield return _arr[i];
        }
    }
    public TValue Peek()
    {
        if(_top < 0)
        {
            return default!;
        }
        return _arr[_top -1];
    }

    public TValue Pop()
    {
        if(_top < 0 )
        {
            return default!;
        }
        var result = _arr[_top -1];
        _top--;
        Count--;
        return result;
    }

    public void Push(TValue value)
    {
        // 检查数组容量
        if(_top > _arr.Length - 1)
        {
            // 扩容数组
            ScalArr();
        }
        _arr[_top++] = value;
        Count++;
    }

    // scaling arrays
    private void ScalArr()
    {
        // 这里扩容简单的乘2倍
        var newArr = new TValue[_arr.Length * 2];
        _arr.CopyTo(newArr, 0);
        _arr = newArr;
    }
}