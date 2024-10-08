using System.Reflection.Metadata;
using  Lib.Tree;
public class HeapDemo
{
    public void Test()
    {
        Heap heap = new Heap();
        for(int i =0 ; i<10 ; i++)
        {
            heap.Push(i);
        }
        Console.WriteLine($"heap count is :{heap.Count()}");
        for(int i =0; i<10; i++)
        {
            Console.Write(heap.Pop()+" ");
        }
        Console.WriteLine($"\nheap count is :{heap.Count()} after pop all!");

        // min heap
        Heap minHeap = new Heap(HeapType.Min);
        for(int i =0 ; i<50 ; i++)
        {
            minHeap.Push(i);
        }
        Console.WriteLine($"heap count is :{minHeap.Count()}");
        for(int i =0; i<50; i++)
        {
            Console.Write(minHeap.Pop()+" ");
        }
        Console.WriteLine($"\nheap count is :{minHeap.Count()} after pop all!");
    }
}