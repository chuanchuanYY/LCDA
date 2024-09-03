
using Lib.Tree;
public class AvlTreeDemo
{
    public void Test()
    {
        var tree  = new AVLTree<int>();
        // 在4的时候发生错误
        for(int i = 0; i < 4; i++)
        {
            tree.Add(i);
        }

        tree.PreOrder(v=>Console.WriteLine(v));
    }
}
