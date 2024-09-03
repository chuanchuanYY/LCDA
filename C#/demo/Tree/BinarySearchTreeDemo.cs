
using System.ComponentModel.DataAnnotations;
using Lib.Tree;

public class BinarySearchTreeDemo
{
    public void Test()
    {
        var tree = new BinarySearchTree<int>();
        //              4
        //             /  \
        //            1    5
        //              \   \ 
        //               2   6
        //                \   \
        //                 3   7
        tree.Add(4);
        tree.Add(1);
        tree.Add(2);
        tree.Add(3);
        tree.Add(5);
        tree.Add(6);
        tree.Add(7);
        Console.WriteLine($"Count : {tree.Count}");
        // 4,1,2,3,5,6,7
        tree.Traverasl((v)=>Console.Write($"{v} "));
        
       var result = tree.Search(7);
       Console.WriteLine("search result:"+result!.Value);
       
       tree.Remove(6);
       Console.WriteLine($"Count: {tree.Count}");

       var removeRes = tree.Remove(10);
       Console.WriteLine(removeRes);

       tree.Remove(4);
       tree.Traverasl((v)=>Console.Write($"{v} "));
    }
}