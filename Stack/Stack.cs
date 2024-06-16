namespace Stack
{
    public struct Stack<T>
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
        public void Push(T value)
        {
            if (IsFull)
            {
                Console.WriteLine("Can't Push Because Stack is Full");
            }
            else container[top++] = value;
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
                T? temp = container[--top];
                container[top] = default;
                return temp;
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

        public Stack(int size)
        {
            this.size = size;
            container = new T[this.size];
            top = 0;
        }
    }
}