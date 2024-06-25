namespace MyQueue
{
    public struct MyLinearQueue<T>
    {
        public int size;
        public bool IsFull
        {
            get
            {
                return rear - front == size;
            }
        }
        public bool IsEmpty
        {
            get
            {
                return front == rear;
            }
        }

        int front;
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
            else return container[front++];
        }

        public T? Peek()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Empty");
                return default;
            }
            else return container[front];
        }

        public void PrintContainer()
        {
            if (!IsEmpty) Console.WriteLine("Front");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"|{i}|");
            }
            Console.WriteLine();
            for (int i = front; i < front + size; i++)
            {
                Console.Write($" {container[i]} ");
            }
            Console.WriteLine();
            for (int i = front; i< front + size; i++)
            {
                if (i + 1 == rear) Console.WriteLine("Rear");
                else Console.Write("   ");
            }
        }
        public MyLinearQueue(int size) 
        {
            this.size = size;
            this.front = 0;
            this.rear = 0;
            container = new T[100];
        }
    }

    public struct MyCircularQueue<T>
    {
        public int size;
        public bool IsEmpty
        {
            get
            {
                return count == 0;
            }
        }

        public bool IsFull
        {
            get
            {
                return count == size;
            }
        }

        int count;
        int front;
        int rear;
        T[] container;

        public void Enqueue(T item)
        {
            if (IsFull)
            {
                Console.WriteLine("Can't enqueue because queue is full");
            }
            else
            {
                container[rear] = item;
                rear = MoveIndex(rear);
                count++;
            }
        }

        public T? Dequeue()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Empty");
                return default;
            }
            else
            {
                T item = container[front];
                container[front] = default;
                front = MoveIndex(front);
                count--;
                return item;
            }
        }

        public T? Peek()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Empty");
                return default;
            }
            else
            {
                return container[front];
            }
        }

        public void PrintContainer()
        {
            string front = "", index = "", item = "", rear = "";
            for (int i = 0; i < size; i++)
            {
                if (!IsEmpty && i == this.front) front += "Front";
                else front += "   ";
                index += $"|{i}|";
                item += $" {container[i]} ";
                if (!IsEmpty && MoveIndex(i) == this.rear) rear += "Rear";
                else rear += "   ";
            }
            Console.WriteLine(front);
            Console.WriteLine(index);
            Console.WriteLine(item);
            Console.WriteLine(rear);
        }

        int MoveIndex(int index)
        {
            return (index + 1) % size; //Circulate index in size
        }

        public MyCircularQueue(int size)
        {
            this.size = size;
            this.front = 0;
            this.rear = 0;
            this.container = new T[size];
            this.count = 0;
        }
    }
}