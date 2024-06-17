using MyStack;
using MyQueue;

namespace Program
{
    public class Program
    {
        public static void Main()
        {
            StackEX();
            QueueEX();
        }

        public static void StackEX()
        {
            MyStack<int> myStack = new(5);
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.PrintContainer();
        }

        public static void QueueEX()
        {
            MyQueue<int> myQueue = new(5);
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.PrintContainer();
        }
    }
}