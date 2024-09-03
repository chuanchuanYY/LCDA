using Lc = Lib.Queue;

namespace Lib.Tree;

public class BinaryTree<TValue>
{
    private BinaryTreeNode<TValue>? _root = null;
    
    public int Count { get; private set; }

    /// <summary>
    /// 删除节点及其子节点
    /// </summary>
    /// <param name="node"></param>
    public void Remove(BinaryTreeNode<TValue> node)
    {
        if(object.ReferenceEquals(node,_root))
        {
            _root = null;
            Count = 0;
            return;
        }
        RemoveNode(_root,node);
    }
    
 
    private void RemoveNode(BinaryTreeNode<TValue>? node,BinaryTreeNode<TValue> target)
    {
        if (node == null)
        {
            return;
        }

        if(object.ReferenceEquals(node.Left, target))
        {
            // node.Left = node.Left.Left;
            node.Left = null;
            PreOrder(target,(v)=>{
                Count --;
            });
            return;
        }
        else if(object.ReferenceEquals(node.Right, target))
        {
           // node.Right = node.Right.Right;
           node.Right = null;
            PreOrder(target,(v)=>{
                Count --;
            });
           return;
        }


        RemoveNode(node.Left,target);
        RemoveNode(node.Right,target);
        

    }
    

  
   /// <summary>
   /// 层序遍历
   /// </summary>
   /// <param name="action"></param>
    public void LevelOrder(Action<TValue> action)
    {
        if(_root == null)
        {
            return;
        }
        Lc.Queue<BinaryTreeNode<TValue>> queue = new Lc.Queue<BinaryTreeNode<TValue>>();
        queue.Push(_root);
        while(queue.Count > 0)
        {
            var node = queue.Pop();
            if(node == null)
            {
                continue;
            }
            action(node!.Value);
            queue.Push(node.Left!);
            queue.Push(node.Right!);
        }
    }

    /// <summary>
    /// 前序遍历
    /// </summary>
    /// <param name="action"></param>
    public void PreOrder(Action<TValue> action)
    {
        PreOrder(_root,action);
    }

    private void PreOrder(BinaryTreeNode<TValue>? node, Action<TValue> action)
    {
        if(node == null)
        {
            return;
        }

        action(node.Value);
        PreOrder(node.Left!,action);
        PreOrder(node.Right!,action);
    }
    
    /// <summary>
    /// 中序遍历
    /// </summary>
    /// <param name="action"></param>
    public void InOrder(Action<TValue> action)
    {
        InOrder(_root,action);
    }

    private void InOrder(BinaryTreeNode<TValue>? node, Action<TValue> action)
    {
        if(node == null)
        {
            return;
        }

        InOrder(node.Left!,action);
        action(node.Value);
        InOrder(node.Right!,action);
    }

    /// <summary>
    /// 后序遍历
    /// </summary>
    /// <param name="action"></param>
    public void PostOrder(Action<TValue> action)
    {
        PostOrder(_root,action);
    }

    private void PostOrder(BinaryTreeNode<TValue>? node, Action<TValue> action)
    {
        if(node == null)
        {
            return;
        }

        PostOrder(node.Left!,action);
        PostOrder(node.Right!,action);
        action(node.Value);
    }
    public BinaryTreeNode<TValue>? Search(TValue target,Func<TValue,TValue,bool>? compare = null)
    {
        return Search(_root,target,compare);
    }
    private BinaryTreeNode<TValue>? Search(BinaryTreeNode<TValue>? node,TValue target,Func<TValue,TValue,bool>? compare = null)
    {
        if(node == null)
        {
            return null;
        }
        if(compare == null)
        {
            if(node.Value!.Equals(target))
            {
                return node;
            }
        }
        else 
        {
            if(compare(node.Value!,target))
            {
                return node;
            }
        }
        
        var result = Search(node.Left!,target,compare!);
        if(result != null)
        {
            return result;
        }
        return Search(node.Right!,target,compare!);
    }
    public void Add(TValue value)
    {
        var newNode = new BinaryTreeNode<TValue>{Value = value};
        if (_root == null)
        {
            _root = newNode;
            Count ++;
        }
        else 
        {
            Lc.Queue<BinaryTreeNode<TValue>> queue = new Lc.Queue<BinaryTreeNode<TValue>>();
            queue.Push(_root);
            while(queue.Peek() != null)
            {
                var node = queue.Pop();
                if(node!.Left == null)
                {
                    node.Left = newNode;
                    break;
                }
                else if(node!.Right == null)
                {
                    node.Right = newNode;
                    break;
                }

                queue.Push(node.Left!);
                queue.Push(node.Right!);
            }
            Count ++;
        }
    }
 
}

public class BinaryTreeNode<TValue>
{
    public TValue Value { get; set; } = default!;
    public BinaryTreeNode<TValue>? Left { get; set; } = null;
    public BinaryTreeNode<TValue>? Right { get;set;} = null;

}
