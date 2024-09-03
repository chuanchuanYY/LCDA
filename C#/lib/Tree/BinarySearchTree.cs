
using System.ComponentModel.Design.Serialization;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace Lib.Tree;

public class BinarySearchTree<TValue> where TValue : IComparable<TValue>
{
    private BinarySearchTreeNode<TValue>? _root;

    public int Count { get; private set; }
    public bool IsEmpty()=> Count == 0;
    private int Compare(TValue a,TValue b)
    {
        if(typeof(TValue).IsValueType)
        {
            return a.CompareTo(b);
        }
        else 
        {
            return a.GetHashCode().CompareTo(b.GetHashCode());
        }
    }
    public void Traverasl(Action<TValue> action)=>_root?.Traversal(action);

    public BinarySearchTreeNode<TValue>? Search(TValue value)
    {
        return _root?.Search(_root,value,Compare);
    }

    public bool Add(TValue value)
    {
        if(_root == null)
        {
            _root = new BinarySearchTreeNode<TValue>{Value = value};
        }
        else 
        {
            var result = _root.Add(_root,value,Compare);
            if(result)
            {
                Count ++;
            }
            return result;
        }
        Count ++;
        return true;
    }
    
    public bool Remove(TValue value)
    {
        if(IsEmpty() || _root == null)
        {
            return false;
        }

        if(Compare(_root.Value,value) == 0)
        {

            if(_root.Left == null || _root.Right == null)
            {
                _root = null;
            }
            else if((_root.Left != null && _root.Right == null) || (_root.Left == null && _root.Right != null))
            {
                if(_root.Left != null)
                {
                    _root = _root.Left;
                }
                else
                {
                    _root = _root.Right;
                }
            }
            else
            {
                var temp = _root.Right;
                while(temp!.Left != null)
                {
                    temp = temp.Left;
                }

                Remove(temp.Value);
                _root.Value = temp.Value;
            }
            Count --;
            return true;
        }
        var result = _root.Remove(_root,value,Compare);
        if(result)
        Count --;
        return result;
    }
   
}

public  class BinarySearchTreeNode<TValue>  
{
    public TValue Value { get; set; } = default(TValue)!;

    public BinarySearchTreeNode<TValue>? Left { get; set; }
    public BinarySearchTreeNode<TValue>? Right { get; set; }

    /// <summary>
    /// 遍历当前节点,前序遍历
    /// </summary>
    public void Traversal(Action<TValue> action)
    {
        Traversal(this,action);
    }
    private void Traversal(BinarySearchTreeNode<TValue>? node,Action<TValue> action)
    {
        if(node == null)
        return;

        action(node.Value);
        Traversal(node.Left,action);
        Traversal(node.Right,action);
    }

    /// <summary>
    /// 从node 开始查找目标值value，找到返回值所在节点，否则返回NULL
    /// </summary>
    /// <param name="node"></param>
    /// <param name="value"></param>
    /// <param name="compare">比较两个值的大小，相等返回0，node.value小于value返回负数，大于返回正数</param>
    /// <returns></returns>
    public BinarySearchTreeNode<TValue>? Search(BinarySearchTreeNode<TValue>? node,TValue value,Func<TValue,TValue,int> compare )
    {
        // 
        if(node == null)
        {
            return null;
        }
       
        // 0 表示相等
        if(compare(node.Value,value) == 0)
        {
            return node;
        }


        // < 0  表示node.value 小于value
        if(compare(node.Value,value) < 0)
        {
            return Search(node.Right,value,compare);
        }
        else 
        {
            // > 0
            return Search(node.Left,value,compare);
        }
    }

    /// <summary>
    /// 在node 节点后插入value
    /// </summary>
    /// <param name="node"></param>
    /// <param name="value">要插入的值</param>
    /// <param name="compare">比较两个值的大小，相等返回0，node.value小于value返回负数，大于返回正数</param>
    /// <returns></returns>
    public bool Add(BinarySearchTreeNode<TValue>? node , TValue value,Func<TValue,TValue,int> compare )
    {
        if(node == null)
        {
            return false;
        }

        var temp = node;
        BinarySearchTreeNode<TValue>? pre = null;
        while(temp != null)
        {
            pre = temp;
            // 如果该值已经存在，不重复插入
            if(compare(temp.Value,value) == 0)
            {
                return true;
            }
            else if(compare(temp.Value,value) < 0)
            {
                temp = temp.Right;
            }
            else 
            {
                temp = temp.Left;
            }
        }
     

        var newNode = new BinarySearchTreeNode<TValue>{Value = value};
        if(compare(pre!.Value,value) < 0)
        {
            pre.Right = newNode;
        }
        else 
        {
            pre.Left = newNode;
        }
        return true;
    }


    /// <summary>
    /// 删除node的子节点
    /// </summary>
    /// <param name="node"></param>
    /// <param name="value"></param>
    /// <param name="compare"></param>
    /// <returns></returns>
    public bool Remove(BinarySearchTreeNode<TValue>? node,TValue value,Func<TValue,TValue,int> compare )
    {
        if(node == null)
        {
            return false;
        }

        var current = node;
        BinarySearchTreeNode<TValue>? pre = null; 
        
        while(current != null)
        {
            if(compare(current.Value,value) == 0)
            {
                break;
            }
            else if(compare(current.Value,value) < 0)
            {
                pre = current;
                current = current.Right;
            }
            else 
            {
                pre = current;
                current = current.Left;
            }
        }

        // 要删除的节点不存在 
        if(current == null)
        {
            return false;
        }
        // 如果该节点是叶子节点 直接删除 度为0
        if(current.Left == null && current.Right == null)
        {
            Remove(pre!,current);
        }
        // 只有一个子节点 度为1
        else if(current.Left != null || current.Right != null)
        {
            if(current.Left != null)
            {
                if(object.ReferenceEquals(pre!.Left,current))
                {
                    pre.Left = current.Left;
                }
                else if(object.ReferenceEquals(pre.Right,current)){
                    pre.Right = current.Left;
                }
            }
            else 
            {
                if(object.ReferenceEquals(pre!.Left,current))
                {
                    pre.Left = current.Right;
                }
                else if(object.ReferenceEquals(pre.Right,current)){
                    pre.Right = current.Right;
                }
            }
        }
        else 
        {
            var temp = current;
            while(temp!.Left != null)
            {
               temp = temp.Left;
            }

            Remove(temp,temp.Value,compare);
            current.Value = temp.Value;
        }
        return true;
    }

    private void Remove(BinarySearchTreeNode<TValue> pre,BinarySearchTreeNode<TValue> node)
    {
        if(object.ReferenceEquals(pre.Left,node))
        {
            pre.Left = null;
        }
        else if(object.ReferenceEquals(pre.Right,node)){
            pre.Right = null;
        }
    }


}