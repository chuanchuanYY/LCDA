namespace Lib.Stack;
 
public interface  IStack<TValue>
{
   void Push(TValue value);
   TValue Pop();

   TValue Peek();
}