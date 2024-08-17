
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
        
        // when empty
        foreach(var item in queue.AsEnumerable())
        {
            Console.WriteLine(item);
        }
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

    public void TestDoubleQueue()
    {
        var dqueue = new Lc.DoubleQueue<int>();
        dqueue.PushFirst(1);
        dqueue.PushFirst(2);
        dqueue.PushFirst(3);
        Console.WriteLine($"Count: {dqueue.Count}");
        Console.WriteLine($"Peek: {dqueue.PeekFirst()}");
        var fpop1 = dqueue.PopFirst();
        var fpop2 = dqueue.PopFirst();
        var fpop3 = dqueue.PopFirst(); 
        
        
        // 3,2,1
        Console.WriteLine($"pop first: {fpop1},{fpop2},{fpop3}");
        Console.WriteLine($"Count: {dqueue.Count}");

        dqueue.PushFirst(1);
        dqueue.PushFirst(2);
        dqueue.PushFirst(3);

        Console.WriteLine($"Count: {dqueue.Count}");
        Console.WriteLine($"Peek: {dqueue.PeekLast()}");
        // 1,2,3
        Console.WriteLine($"pop last: {dqueue.PopLast()},{dqueue.PopLast()},{dqueue.PopLast()}");
        Console.WriteLine($"Count: {dqueue.Count}");



        // pushlast
        dqueue.PushLast(1);
        dqueue.PushLast(2);
        dqueue.PushLast(3);

        Console.WriteLine($"Count: {dqueue.Count}");
        Console.WriteLine($"Peek: {dqueue.PeekLast()}");
        // 1,2,3
        Console.WriteLine($"pop last: {dqueue.PopFirst()},{dqueue.PopFirst()},{dqueue.PopFirst()}");
        Console.WriteLine($"Count: {dqueue.Count}");

        // when empty 

        foreach(var item in dqueue.AsEnumerable()) 
        {
            Console.WriteLine(item.ToString());
        }
        // insert a lot of number
        int insertCount = 50;
        for(int i=0; i<insertCount; i++)
        {
            dqueue.PushLast(i);
        }
        Console.WriteLine($"Count: {dqueue.Count}"); // 50
        Console.WriteLine($"Peek: {dqueue.PeekLast()}");

        Console.WriteLine("foreach: ");
        foreach(var item in dqueue.AsEnumerable()) // 0 ~ 49
        {
            Console.WriteLine(item.ToString());
        }
    }

      public void TestLinkListDoubleQueue()
    {
        var dqueue = new Lc.LinkListDoubleQueue<int>();
        dqueue.PushFirst(1);
        dqueue.PushFirst(2);
        dqueue.PushFirst(3);
        Console.WriteLine($"Count: {dqueue.Count}");
        Console.WriteLine($"Peek: {dqueue.PeekFirst()}");
        var fpop1 = dqueue.PopFirst();
        var fpop2 = dqueue.PopFirst();
        var fpop3 = dqueue.PopFirst(); 
        
        
        // 3,2,1
        Console.WriteLine($"pop first: {fpop1},{fpop2},{fpop3}");
        Console.WriteLine($"Count: {dqueue.Count}");

        dqueue.PushFirst(1);
        dqueue.PushFirst(2);
        dqueue.PushFirst(3);

        Console.WriteLine($"Count: {dqueue.Count}");
        Console.WriteLine($"Peek: {dqueue.PeekLast()}"); // 1
        // 1,2,3
        Console.WriteLine($"pop last: {dqueue.PopLast()},{dqueue.PopLast()},{dqueue.PopLast()}");
        Console.WriteLine($"Count: {dqueue.Count}");



        // pushlast
        dqueue.PushLast(1);
        dqueue.PushLast(2);
        dqueue.PushLast(3);

        Console.WriteLine($"Count: {dqueue.Count}");
        Console.WriteLine($"Peek: {dqueue.PeekLast()}");
        // 1,2,3
        Console.WriteLine($"pop last: {dqueue.PopFirst()},{dqueue.PopFirst()},{dqueue.PopFirst()}");
        Console.WriteLine($"Count: {dqueue.Count}");

        // when empty 

        foreach(var item in dqueue.AsEnumerable()) 
        {
            Console.WriteLine(item.ToString());
        }
        // insert a lot of number
        int insertCount = 50;
        for(int i=0; i<insertCount; i++)
        {
            dqueue.PushLast(i);
        }
        Console.WriteLine($"Count: {dqueue.Count}"); // 50
        Console.WriteLine($"Peek: {dqueue.PeekLast()}");

        Console.WriteLine("foreach: ");
        foreach(var item in dqueue.AsEnumerable()) // 0 ~ 49
        {
            Console.WriteLine(item.ToString());
        }
    }
}