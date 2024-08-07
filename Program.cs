﻿using MyStack;
using MyQueue;
using MyLinkedList;

namespace Program
{
    public class Program
    {
        public static void Main()
        {

        }

        public static void StackEX()
        {
            MyStack<int> myStack = new(5);
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.PrintContainer();
        }

        public static void LinearQueueEX()
        {
            MyLinearQueue<int> myQueue = new(5);
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.PrintContainer();
        }

        public static void CircularQueueEX()
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

        public static void DequeEX()
        {
            MyDeque<int> myDeque = new(5);
            myDeque.AddFront(1);
            myDeque.AddRear(2);
            myDeque.AddFront(3);
            myDeque.AddRear(4);
            Console.WriteLine(myDeque.PopFront());
            Console.WriteLine(myDeque.PopFront());
            myDeque.PrintContainer();
        }

        public static void SimpleLinkedListEx()
        {
            SingleNode<int> a = new(5);
            SingleNode<int> b = new(3);
            SingleNode<int> c = new(4);

            SimpleLinkedList<int> myList = new();

            myList.Insert(a);
            myList.Insert(b);
            myList.Insert(c, 1);
            myList.PrintList();
            myList.Pop(1);
            myList.Insert(new SingleNode<int>(1));
            myList.PrintList();
            Console.WriteLine(myList.GetItem(1));
        }
    }
}