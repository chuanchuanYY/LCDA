


namespace Lib.Tree;

public class AVLTree<TValue> where TValue : IComparable<TValue> 
{
    private AvlNode<TValue>? _root;


    public void PreOrder(Action<TValue> action)
    {
        PreOrder(_root,action);
    }
    private void PreOrder(AvlNode<TValue>? node,Action<TValue>? action)
    {
        if(node == null)
        {
            return;
        }

        action?.Invoke(node.Value);
        PreOrder(node.Left,action);
        PreOrder(node.Right,action);
    }

    
    public AvlNode<TValue>? Search(TValue value)
    {
        return Search(_root,value);
    }
    public void TrySearch(TValue value,ref TValue val,ref bool isSuccess)
    {
        var result = Search(_root,value);
        if(result == null)
        {
            val = default!;
            isSuccess = false;
        }
        else 
        {
            val = result.Value;
            isSuccess = true;
        }
    }
    private AvlNode<TValue>? Search(AvlNode<TValue>? node, TValue value)
    {
        if(node == null)
        {
            return null;
        }
        if(value.CompareTo(node.Value) < 0)
        {
            return Search(node.Left,value);
        }
        else if(value.CompareTo(node.Value) > 0)
        {
            return Search(node.Right,value);
        }
        else 
        {
            return node;
        }
    }
    
    public void Remove(TValue value)
    {   
        Delete(_root,value);
    }

    private AvlNode<TValue>? Delete(AvlNode<TValue>? node, TValue value)
    {
        if(node == null)
        {
            return null;
        }

        if(value.CompareTo(node.Value) < 0)
        {
            node.Left = Delete(node.Left,value);
        }
        else if(value.CompareTo(node.Value) > 0)
        {
            node.Right = Delete(node.Right,value);
        }
        else 
        {
            if(node.Left == null || node.Right == null)
            {
                var child = node.Left != null ? node.Left : node.Right;

                if(child == null)
                {
                    return null;
                }
                node = child;
            }
            else 
            {
                var temp = node.Right;
                while(temp.Left != null)
                {
                    temp = temp.Left;
                }

                TValue tempValue = temp.Value;
                node.Right = Delete(node.Right, temp.Value);
                node.Value = tempValue;
            }
        }
        node.UpdateHeight();
        node.Rotate();
        return node;

    }   
    public void Add(TValue value)
    {
        _root = Insert(_root,value);
    }
    private AvlNode<TValue> Insert(AvlNode<TValue>? node , TValue value)
    {
        if(node == null)
        {
            return new AvlNode<TValue>{ Value = value };
        }

        if(value.CompareTo(node.Value) < 0)
        {
            node.Left = Insert(node.Left,value);
        }
        else if(value.CompareTo(node.Value) > 0)
        {
            node.Right = Insert(node.Right,value);
        }
        else 
        {
            return node;
        }

        node.UpdateHeight();
        node = node.Rotate();
        return node;
    }
}

public class AvlNode<TValue> 
{
    public TValue Value { get; set; } = default(TValue)!;
    public int Height { get; set; } = -1;
    public AvlNode<TValue>? Left { get; set; }
    public AvlNode<TValue>? Right { get; set; }


   public AvlNode<TValue> Rotate()
   {
        int balanceFactor = BalanceFactor(this);

        if(balanceFactor > 1)
        {
            if(BalanceFactor(Left) >= 0 )
            {
                return RightRotate();
            }
            else 
            {
                Left!.LeftRotate();
                return RightRotate();
            }
        }
        else if (balanceFactor < -1)
        {
            if(BalanceFactor(Right) <= 0 )
            {
                return LeftRotate();
            }
            else 
            {
                Right!.RightRotate();
                return LeftRotate();
            }
        }

        return this;
   }


    //设平衡因子为 f 则一棵 AVL 树的任意节点的平衡因子皆满足 -1<=f<=1
    public int BalanceFactor(AvlNode<TValue>? node)
    {
        return (Left == null ? -1: Left.Height) - (Right == null ? -1 :Right.Height);
    }
    
    public void UpdateHeight()
    {
        Height = Math.Max(Left == null ? -1 : Left.Height,Right == null ? -1 : Right.Height) + 1;
    }    public AvlNode<TValue> RightRotate()
    {
        var node = this;
        var childe = node.Left;
        
        node.Left = childe!.Right;
        childe.Right = node;
        
        childe.UpdateHeight();
        node.UpdateHeight();

        return childe;
    }

    public AvlNode<TValue> LeftRotate()
    {
        var node = this;
        var childe = node.Right;
        
        node.Right = childe!.Left;
        childe.Left = node;
        
        childe.UpdateHeight();
        node.UpdateHeight();

        return childe;
    }

   
}