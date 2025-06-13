namespace CS_DataStructure
{
    using Linear;

    public class Program
    {
        public static void Main(string[] args)
        {
            
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
    }
}