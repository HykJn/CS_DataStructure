using System;

namespace MyLinkedList
{
    public class SingleNode<T>
    {
        public SingleNode<T>? next;
        public T? item;

        public SingleNode(T? item)
        {
            this.item = item;
        }
    }

    public class DoubleNode<T>
    {
        public DoubleNode<T>? prev;
        public DoubleNode<T>? next;
        public T? item;

        public DoubleNode(T? item)
        {
            this.item = item;
        }
    }

    public class SimpleLinkedList<T>
    {
        SingleNode<T> head = new(default);
        public int size = 0;

        public void Insert(SingleNode<T> item, int? index = null)
        {
            if (index == null) index = size;
            else if (index >= size || index < 0)
            {
                throw new Exception("Out of Range");
            }

            SingleNode<T> temp = head;
            for(int i = 0; i < index; i++)
            {
                temp = temp.next;
            }

            if (temp.next == null) temp.next = item;
            else
            {
                item.next = temp.next;
                temp.next = item;
            }
            size++;
        }

        public T Pop(int? index = null)
        {
            if (index == null) index = size;
            else if (index >= size || index < 0)
            {
                throw new Exception("Out of Range");
            }

            if(head.next == null)
            {
                throw new Exception("Out of Range(Empty List)");
            }

            SingleNode<T> temp = head;

            for(int i = 0; i < index; i++)
            {
                temp = temp.next;
            }

            SingleNode<T> item = temp.next;
            temp.next = item.next;
            size--;
            return item.item;
        }

        public T GetItem(int index)
        {
            if(index >= size || index < 0)
            {
                throw new Exception("Out of Range");
            }

            SingleNode<T> temp = head.next;

            for(int i = 0; i < index; i++)
            {
                temp = temp.next;
            }
            return temp.item;
        }

        public void PrintList()
        {
            if(size == 0)
            {
                Console.WriteLine("EMPTY");
                return;
            }

            SingleNode<T> temp = head.next;
            string index = "";
            string item = "";

            for(int i = 0; i < size; i++)
            {
                index += $"|{i}|";
                item += $" {temp.item.ToString()} ";
                temp = temp.next;
            }

            Console.WriteLine(index);
            Console.WriteLine(item);
        }
    }

    public class CircularLinkedList<T>
    {
        SingleNode<T> head = new(default);
        public int size = 0;

        public void Insert(SingleNode<T> item, int? index = null)
        {
            if (index == null) index = size;
            else if (index >= size || index < 0)
            {
                throw new Exception("Out of Range");
            }

            SingleNode<T> temp = head;
            for (int i = 0; i < index; i++)
            {
                temp = temp.next;
            }
            item.next = temp.next;
            temp.next = item;
            size++;
            SetHead();
        }

        public T Pop(int? index = null)
        {
            if (index == null) index = size;
            else if (index >= size || index < 0)
            {
                throw new Exception("Out of Range");
            }

            if (head.next == null)
            {
                throw new Exception("Out of Range(Empty List)");
            }

            SingleNode<T> temp = head;
            for (int i = 0; i < index; i++)
            {
                temp = temp.next;
            }
            SingleNode<T> item = temp.next;
            temp.next = item.next;
            size--;
            SetHead();
            return item.item;
        }

        public T GetItem(int? index = null)
        {
            if (index == null) index = size;
            else if (index >= size || index < 0)
            {
                throw new Exception("Out of Range");
            }

            SingleNode<T> temp = head;
            for(int i = 0; i < index; i++)
            {
                temp = temp.next;
            }
            T item = temp.next.item;
            return item;
        }

        public void PrintList()
        {
            if (size == 0)
            {
                Console.WriteLine("EMPTY");
                return;
            }

            SingleNode<T> temp = head.next;
            string index = "";
            string item = "";

            for (int i = 0; i < size; i++)
            {
                index += $"|{i}|";
                item += $" {temp.item.ToString()} ";
                temp = temp.next;
            }

            Console.WriteLine(index);
            Console.WriteLine(item);
        }

        void SetHead()
        {
            SingleNode<T> temp = head;
            for(int i = 0; i < size; i++)
            {
                temp = temp.next;
            }
            temp.next = head.next;
        }
    }

    public class DoubleLinkedList<T>
    {
        DoubleNode<T> head;
    }
}