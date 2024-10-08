namespace Lib.Tree;


public enum HeapType
{
    Max,
    Min
}
// 大顶堆
public class Heap
{
    
    private int[] _data;
    private int _index = 0;
    private const int _INITSIZE = 32;
    private HeapType _heapType;
    public Heap()
    {
        _data = new int[_INITSIZE];
        _heapType = HeapType.Max;
    }
    public Heap(HeapType heapType,int initSize = _INITSIZE)
    {
        _data = new int[initSize];
        _heapType = heapType;
    }
    public bool IsEmpty() => _index == 0;
    public int Count() => _index;
    private void Swap(ref int a,ref int b)
    {   
        int temp = a;
        a = b;
        b = temp;
    }

/// <summary>
/// 堆顶出堆
/// </summary>
/// <returns></returns>
/// <exception cref="IndexOutOfRangeException"></exception>
    public int Pop()
    {
        if(Count() == 0)
        throw new IndexOutOfRangeException("heap is empty!");
        int result = _data[0];
        Swap(ref _data[0],ref _data[_index -1]);
        _index--;
        ShiftDown(0);
        return result;
    }

    private void ShiftDown(int i)
    {
       
        while(true)
        {
            if(_heapType == HeapType.Max)
            {
                int left = Left(i),right = Right(i),max = i;
                if(left < _index && _data[left] > _data[max])
                {
                    max = left;
                }

                if(right < _index && _data[right] > _data[max])
                {
                    max = right;
                }
                if(max == i)
                {
                    break;
                }
                Swap(ref _data[i],ref _data[max]);
                i = max;
            }
            else 
            {
                int left = Left(i),right = Right(i),min = i;
                if(left < _index && _data[left] < _data[min])
                {
                    min = left;
                }

                if(right < _index && _data[right] < _data[min])
                {
                    min = right;
                }
                if(min == i)
                {
                    break;
                }
                Swap(ref _data[i],ref _data[min]);
                i = min;
            }
        }
       
    }
    public void Push(int value)
    {
        _data[_index++] = value;
        
        if(_index >= _data.Length)
        {
            int[] newData = new int[_data.Length *2];
            Array.Copy(_data, 0,newData,0,_data.Length);
            _data = newData;
        }
        ShiftUp(_index - 1);
    }

    private void ShiftUp(int index)
    {
        while(true)
        {
            int p = Parent(index);
            if(_heapType == HeapType.Max)
            {
                if(p<0 || _data[p] >= _data[index])
                break;
            }
            else 
            {
                if(p<0 || _data[p] <= _data[index])
                break;
            }
            Swap(ref _data[p],ref _data[index]);
            index = p;
        }
    }   
    
    private int Left(int index)
    {
        return 2*index + 1;
    } 
    private int Right(int index)
    {
        return 2*index + 2;
    }
    private int Parent(int index)
    {
        return (index-1) / 2;
    }

    public int Peek()
    {
        if(!IsEmpty())
        {
            throw new InvalidOperationException("Heap is Empty!");
        }
        return _data[0];
    }
}