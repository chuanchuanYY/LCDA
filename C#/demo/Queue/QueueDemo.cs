
using Lib.Queue;
using Lc = Lib.Queue;

public class QueueDemo
{
    public void TestLinkListQueue()
    {
        var queue = new LinkListQueue<int>();
        queue.Push(1);
        queue.Push(2);
        queue.Push(3);

        Console.WriteLine(queue.Count);
        Console.WriteLine(queue.Peek());
        var pop1 = queue.Pop();
        var pop2 = queue.Pop();
        var pop3 = queue.Pop();
        Console.WriteLine($"{pop1},{pop2},{pop3}");

        Console.WriteLine($"after pop Count : {queue.Count}");
        
        int insertSize = 10;
        for(int i=0; i<insertSize; i++)
        {
            queue.Push(i);
        }
        Console.WriteLine("foreach: ");
        foreach(var item in queue.AsEnumerable())
        {
            Console.WriteLine(item);
        }
    }


    public void TestQueue()
    {
        var queue = new Lc.Queue<int>();
        queue.Push(1);
        queue.Push(2);
        queue.Push(3);

        Console.WriteLine(queue.Count);
        Console.WriteLine(queue.Peek());
        var pop1 = queue.Pop();
        var pop2 = queue.Pop();
        var pop3 = queue.Pop();
        Console.WriteLine($"{pop1},{pop2},{pop3}");

        Console.WriteLine($"after pop Count : {queue.Count}");
        
        int insertSize = 25;
        for(int i=0; i<insertSize; i++)
        {
           queue.Push(i);
        }
        Console.WriteLine("foreach: ");
        foreach(var item in queue.AsEnumerable())
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("count : " +queue.Count);
    }
}