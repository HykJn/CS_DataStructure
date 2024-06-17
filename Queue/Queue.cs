namespace MyQueue
{
    public struct MyQueue<T>
    {
        public int size;
        public bool IsFull
        {
            get
            {
                return rear - head == size;
            }
        }
        public bool IsEmpty
        {
            get
            {
                return head == rear;
            }
        }

        int head;
        int rear;
        T[] container;

        public void Enqueue(T item)
        {
            if (IsFull)
            {
                Console.WriteLine("Can't enqueue because queue is full");
            }
            else container[rear++] = item;
        }

        public T? Dequeue()
        {
            if(IsEmpty)
            {
                Console.WriteLine("Empty");
                return default;
            }
            else return container[head++];
        }

        public T? Peek()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Empty");
                return default;
            }
            else return container[head];
        }

        public void PrintContainer()
        {
            if (!IsEmpty) Console.WriteLine("Head");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"|{i}|");
            }
            Console.WriteLine();
            for (int i = head; i < head + size; i++)
            {
                Console.Write($" {container[i]} ");
            }
            Console.WriteLine();
            for (int i = head; i< head + size; i++)
            {
                if (i + 1 == rear) Console.WriteLine("Rear");
                else Console.Write("   ");
            }
        }
        public MyQueue(int size) 
        {
            this.size = size;
            this.head = 0;
            this.rear = 0;
            container = new T[100];
        }
    }
}