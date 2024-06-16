namespace Program
{
    public class Program
    {
        public static void Main()
        {
            StackEX();
        }

        public static void StackEX()
        {
            Stack<int> myStack = new(5);
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.PrintContainer();
        }
    }
}