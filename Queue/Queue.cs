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

    public struct MyDeque<T>
    {
        public bool IsFull
        {
            get
            {
                return count == size;
            }
        }
        public bool IsEmpty
        {
            get
            {
                return count == 0;
            }
        }
        public int size;

        int front, rear, count;
        T[] container;

        public void AddFront(T item)
        {
            if (IsFull)
            {
                Console.WriteLine("Can't add to front because deque is full");
            }
            else
            {
                front = MoveIndex(front, -1);
                container[front] = item;
                count++;
            }
        }

        public void AddRear(T item)
        {
            if (IsFull)
            {
                Console.WriteLine("Can't add to rear because deque is full");
            }
            else
            {
                container[rear] = item;
                count++;
                rear = MoveIndex(rear, 1);
            }
        }

        public T? PopFront()
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
                front = MoveIndex(front, 1);
                count--;
                return item;
            }
        }

        public T? PopRear()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Empty");
                return default;
            }
            else
            {
                container[rear] = default;
                rear = MoveIndex(rear, -1);
                T item = container[rear];
                count--;
                return item;
            }
        }

        public T? GetFront()
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

        public T? GetRear()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Empty");
                return default;
            }
            else
            {
                return container[MoveIndex(rear, -1)];
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
                if (!IsEmpty && MoveIndex(i, 1) == this.rear) rear += "Rear";
                else rear += "   ";
            }
            Console.WriteLine(front);
            Console.WriteLine(index);
            Console.WriteLine(item);
            Console.WriteLine(rear);
        }

        int MoveIndex(int index, int count)
        {
            if (count > 0) return (index + count) % size;
            else if (count < 0) return (size + index + count) % size;
            else return index;
        }
        public MyDeque(int size)
        {
            this.size = size;
            front = 0;
            rear = 0;
            count = 0;
            container = new T[size];
        }
    }

    public struct PriorityNode<T>
    {
        public int priority;
        public T item;

        public PriorityNode(T item, int priority)
        {
            this.item = item;
            this.priority = priority;
        }
    }

    public struct MyPriorityQueue<T>
    {
        int rear = 1;
        int size;
        bool isMaxHeap;
        PriorityNode<T>[] heap;

        public void Insert(PriorityNode<T> item)
        {
            int idx = rear;
            while (idx != 1 && isMaxHeap ? item.priority >= heap[idx / 2].priority : item.priority <= heap[idx / 2].priority)
            {
                heap[idx] = heap[idx / 2];
                idx /= 2;
            }
            heap[idx] = item;
            rear++;
        }

        public T Delete()
        {
            T item = heap[1].item;
            PriorityNode<T> temp = heap[--rear];

            int parent = 1; int child = 2;
            while (child <= rear)
            {
                if (child < rear && isMaxHeap ? heap[child].priority < heap[child + 1].priority : heap[child].priority > heap[child + 1].priority) child++;

                if (isMaxHeap ? temp.priority >= heap[child].priority : temp.priority <= heap[child].priority) break;

                heap[parent] = heap[child];
                parent = child;
                child *= 2;
            }
            heap[parent] = temp;
            return item;
        }

        public MyPriorityQueue(int size, bool isMaxHeap)
        {
            this.size = size;
            this.isMaxHeap = isMaxHeap;
            heap = new PriorityNode<T>[size];
        }
    }
}