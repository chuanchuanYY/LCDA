
using Lib.Tree;

public class BinaryTreeDemo
{

    public void Test()
    {
        var tree = new BinaryTree<int>();
        tree.Add(1);
        tree.Add(2);
        tree.Add(3);
        tree.Add(4);
        tree.Add(5);
        tree.Add(6);
        tree.Add(7);
        Console.WriteLine($"Count: {tree.Count}");
        /*
                 1
                / \
               2   3
              / \  / \ 
             4  5  6  7
        */ 
        
        // 1,2,3,4,5,6,7
        tree.LevelOrder((value)=>Console.Write($"{value} "));
        Console.WriteLine();
        
        // 1,2,4,5,3,6,7
        tree.PreOrder((value)=>Console.Write($"{value} "));
        Console.WriteLine();
        
        // 4,2,5,1,6,3,7
        tree.InOrder((value)=>Console.Write($"{value} "));
        Console.WriteLine();

        // 4,5,2,6,7,3,1
        tree.PostOrder((value)=>Console.Write($"{value} "));
        Console.WriteLine();


        // search value 
        var result = tree.Search(2,(src,target)=>{
                        return src == target;
                    });
        Console.WriteLine(result != null);
        Console.WriteLine(result?.Value);


        tree.Remove(result!);
        // 会删除节点2 以及其子节点4，5
        Console.WriteLine($"Removed Count: {tree.Count}");
        tree.LevelOrder((value)=>Console.Write($"{value} "));
        Console.WriteLine();

        var root = tree.Search(1,(src,target)=>{
                        return src == target;
                    });
        tree.Remove(root!);
        Console.WriteLine($"root Removed Count: {tree.Count}");

    }
}