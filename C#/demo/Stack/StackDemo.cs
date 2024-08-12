using System.Security.Cryptography.X509Certificates;
using Lib.Stack;
using Lc = Lib.Stack;


public class StackDemo
{
    public void Test()
    {
        // Lc别名为了不跟系统内置数据结构冲突
        var stack  = new Lc.Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        Console.WriteLine(stack.Count); // 3
        for(int i = 0; i<3;i++)
        {
            var result = stack.Pop();
            Console.Write(result +" "); // 3 2 1
        }
      
        
        Console.WriteLine();


        stack.Push(4);
        var peek = stack.Peek();
        Console.WriteLine(peek); // 4
    
        stack.Pop();
        Console.WriteLine(stack.Count); // 0

        // 插入大量数据让数组扩容
        int insertSize = 1_000;
        for(int i = 0; i < insertSize; i++)
        {
            stack.Push(i);
        }
        Console.WriteLine(stack.Peek()); // 999
        Console.WriteLine(stack.Count); // 1000
       
        // foreach 
        Console.WriteLine("foreach:");
        foreach(var item in stack.AsEnumerable())
        {
            Console.WriteLine(item);
        }
    }

    public void TestWithLink()
    {
         var stack  = new Lc.StackWithLink<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        Console.WriteLine(stack.Count); // 3
        for(int i = 0; i<3;i++)
        {
            var result = stack.Pop();
            Console.Write(result +" "); // 3 2 1
        }
      
        
        Console.WriteLine();


        stack.Push(4);
        var peek = stack.Peek();
        Console.WriteLine(peek); // 4
    
        stack.Pop();
        Console.WriteLine(stack.Count); // 0

        // 插入大量数据让数组扩容
        int insertSize = 2_000;
        for(int i = 0; i < insertSize; i++)
        {
            stack.Push(i);
        }
        Console.WriteLine(stack.Peek()); // 999
        Console.WriteLine(stack.Count); // 1000


        // foreach 
        Console.WriteLine("foreach:");
        foreach(var item in stack.AsEnumerable())
        {
            Console.WriteLine(item);
        }
    }

}