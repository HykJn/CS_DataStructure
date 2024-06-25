using MyStack;
using MyQueue;

namespace Program
{
    public class Program
    {
        public static void Main()
        {
            MyCircularQueue<int> myQueue = new(5);
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.Enqueue(4);
            myQueue.Enqueue(5);
            myQueue.Dequeue();
            myQueue.Dequeue();
            myQueue.Enqueue(6);
            myQueue.PrintContainer();
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
            MyLinearQueue<int> myQueue = new(5);
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.PrintContainer();
        }
    }
}