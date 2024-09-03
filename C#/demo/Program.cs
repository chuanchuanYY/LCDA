// See https://aka.ms/new-console-template for more information

#region  Stack 

using System.Runtime.InteropServices;

var stackDemo = new StackDemo();
// stackDemo.Test();
// stackDemo.TestWithLink();
#endregion

#region  Queue 
QueueDemo queueDemo = new QueueDemo();
// queueDemo.TestLinkListQueue();
// queueDemo.TestQueue();
// queueDemo.TestDoubleQueue();
// queueDemo.TestLinkListDoubleQueue();

#endregion

#region Tree
// BinaryTreeDemo binaryTreeDemo= new BinaryTreeDemo();
// binaryTreeDemo.Test();
// BinarySearchTreeDemo binarySearchTreeDemo = new BinarySearchTreeDemo();
// binarySearchTreeDemo.Test();
AvlTreeDemo avlTreeDemo = new();
avlTreeDemo.Test();
#endregion


