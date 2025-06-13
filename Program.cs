namespace CS_DataStructure
{
    using Linear;

    public class Program
    {
        public static void Main(string[] args)
        {
            Test_SinglyLinkedList();
        }

        public static void Test_ArrayList()
        {
            ArrayList<int> ints = new ArrayList<int>(4) { 1, 2, 3 };

            Console.WriteLine(ints.IndexOf(3)); //2
            Console.WriteLine(ints.IndexOf(4)); //-1

            ints.Add(4); //1, 2, 3, 4
            ints.Insert(2, 5); //1, 2, 5, 3, 4 -> Capacity 4 -> 8

            ints.RemoveAt(3); //1, 2, 5, 4
            ints.Remove(1); //2, 5, 4

            Console.WriteLine(ints.Contains(2));

            ints.Display();
        }

        public static void Test_SinglyLinkedList()
        {
            SinglyLinkedList<int> list = new();
            list.Insert(0, new(5)); //5
            list.Insert(1, new(10)); //5, 10
            list.AddFirst(new(0)); //0, 5, 10
            list.AddLast(new(20)); //0, 5, 10, 20

            list.Display(); //0, 5, 10, 20

            list.RemoveFirst(); //5, 10, 20
            list.RemoveLast(); //5, 10
            Console.WriteLine(list.Remove(new(3))); //false
            Console.WriteLine(list.IndexOf(new(10))); //1
            list[1] = new(20);
            Console.WriteLine(list[0].Value); //5

            list.Display(); //5, 20
        }
    }
}