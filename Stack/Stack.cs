namespace MyStack
{
    public struct MyStack<T>
    {
        public int size;
        public bool IsEmpty
        {
            get
            {
                return top == 0;
            }
        }
        public bool IsFull
        {
            get
            {
                return top == size;
            }
        }

        int top;
        T?[] container;
        public void Push(T item)
        {
            if (IsFull)
            {
                Console.WriteLine("Can't Push Because Stack is Full");
            }
            else container[top++] = item;
        }

        public T? Pop()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Empty");
                return default;
            }
            else
            {
                T? item = container[--top];
                container[top] = default;
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
                return container[top - 1];
            }
        }

        public void PrintContainer()
        {
            for (int i = size - 1; i >= 0; i--)
            {
                if (i + 1 == top) Console.WriteLine($"|{i}|{container[i]}" + " <--Top");
                else Console.WriteLine($"|{i}|{container[i]}");
            }
        }

        public MyStack(int size)
        {
            this.size = size;
            container = new T[this.size];
            top = 0;
        }
    }
}