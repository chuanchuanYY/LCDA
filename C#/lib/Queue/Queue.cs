

using Lib.Queue;
namespace Lib.Queue;
public class Queue<TValue> : IQueue<TValue>
{
    private const int INIT_SIZE = 10; 
    private TValue[] _arr;
    private int _font = 0;
    private int _tail = 0;
    public int Count {get; private set;} = 0;

    public Queue()
    {
        _arr = new TValue[INIT_SIZE];
    }
    public bool IsEmpty => Count == 0;
    public IEnumerable<TValue> AsEnumerable()
    {
        for(int i =_font; i<_tail; i++)
        {
            yield return _arr[i % _arr.Length];
        }
    }
    public TValue? Peek()
    {
        if(Count <= 0)
        {
            return default!;
        }
        return _arr[_font % _arr.Length];
    }

    public TValue? Pop()
    {
       if(_font > _tail || Count <= 0)
       {
            return default!;
       }
       Count --;
       return _arr[_font++ % _arr.Length];
    }

    public void Push(TValue value)
    {
        //
        if(Count >= _arr.Length)
        {
            ScalArray();
        }

        _arr[_tail % _arr.Length] = value;
        _tail ++;
        Count ++;
    } 
    private void ScalArray()
    {
        var newArr = new TValue[_arr.Length *2];
        int i = 0;
        foreach(var item in AsEnumerable())
        {
            newArr[i++] = item;
        }
        _font = 0;
        _tail = _arr.Length;
        _arr = newArr;
    }
}