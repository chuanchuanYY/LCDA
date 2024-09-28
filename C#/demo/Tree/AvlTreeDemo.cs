
using System.Collections.Specialized;
using Lib.Tree;
public class AvlTreeDemo
{
    public void Test()
    {
        var tree  = new AVLTree<int>();
        for(int i = 0; i < 10; i++)
        {
            tree.Add(i);
        }
        tree.PreOrder(v=>Console.WriteLine(v));

        tree.Remove(9);
        string s =  new string('*',10);
        Console.WriteLine(s);
        tree.PreOrder(v=>Console.WriteLine(v));
        
    }
}
