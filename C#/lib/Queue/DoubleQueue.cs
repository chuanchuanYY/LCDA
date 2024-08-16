using System.Collections;

namespace Lib.Queue;

/// <summary>
/// 使用数组实现的双向队列
/// </summary>
/// <typeparam name="TValue"></typeparam>
public class DoubleQueue<TValue> : IDoubleQueue<TValue>
{
    private const int INIT_SIZE = 10;
    private TValue[] _arr ;
    public int Count {get;private set;} = 0;

    private int _font;
    private int _tail;

    public DoubleQueue()
    {
        _arr = new TValue[INIT_SIZE];
    }

    /// <summary>
    /// 从队首开始迭代元素
    /// </summary>
    /// <returns></returns>
    public IEnumerable<TValue> AsEnumerable()
    {
        if(IsEmpty())
        {
            yield break;
        }
        else 
        {
            int i = _font + 1;
            int count = 0;
            while(count++ < Count)
            {
                yield return _arr[CalculateIndex(i++)];
            }
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
    /// <summary>
    /// 查看队首或队尾的元素,但不弹出元素
    /// </summary>
    /// <param name="isFont">是否为队首</param>
    /// <returns></returns>
    private TValue? Peek(bool isFont)
    {
        if(IsEmpty())
        {
            return default!;
        }
        if(isFont)
        {
            return _arr[CalculateIndex(_font + 1)];
        }
        else
        {
            return _arr[CalculateIndex(_tail -1)];
        }
    }
    /// <summary>
    /// 弹出一个元素,在队首或队尾
    /// </summary>
    /// <param name="isFont">是否为队首</param>
    /// <returns></returns>
    private TValue? Pop(bool isFont)
    {
        if(IsEmpty())
        {
            return default!;
        }
        TValue? result;
        if(isFont) 
        {
            result = _arr[CalculateIndex(_font + 1)];
            _font ++;
        }
        else
        {
            result = _arr[CalculateIndex(_tail - 1)];
            _tail --;
        }
        Count --;
        return result;

    }
    /// <summary>
    /// 插入一个元素
    /// </summary>
    /// <param name="value">要插入的值</param>
    /// <param name="isFont">是否为队首插入</param>
    private void Push(TValue value,bool isFont)
    {
        if(Count >= _arr.Length)
        {
            // 扩容
            ScalArray();
        }
        if(isFont)
        {
            if(CalculateIndex(_font) == CalculateIndex(_tail) && IsEmpty()) 
            {
                _tail ++;
            }
            _arr[CalculateIndex(_font)] = value;
            _font --;
            Count ++;
        }
        else 
        {   if(CalculateIndex(_font) == CalculateIndex(_tail) && IsEmpty())
            {
                _font --;
            }
            _arr[CalculateIndex(_tail)] = value;
            _tail ++;
            Count ++;
        }
    }

    private void ScalArray()
    {
        // 简单的翻倍容量
        var newArr = new TValue[_arr.Length * 2];
        
        int i = 0;
        foreach(var val in AsEnumerable())
        {
            newArr[i++] = val;
        }
        _font = -1;
        _tail = _arr.Length;   
        _arr = newArr;

    }

    private int CalculateIndex(int index)
    {
        if(index < 0)
        {
            return (index % _arr.Length) + _arr.Length;
        }
        return index % _arr.Length;
    }
}