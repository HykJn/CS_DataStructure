namespace CS_DataStructure.Linear
{
    using Nodes;
    public class SinglyLinkedList<T> where T : notnull, IEquatable<T>
    {
        #region ==========Fields==========
        public int Count { get; private set; }
        public LinkedNode<T> this[int index]
        {
            get => Get(index);
            set
            {
                if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

                LinkedNode<T> temp = head;
                for (int i = 0; i < index; i++)
                {
                    temp = temp.Neighbor;
                }

                value.Neighbor = temp.Neighbor.Neighbor;
                temp.Neighbor = value;
            }
        }

        private LinkedNode<T>? head;
        #endregion

        #region ==========Methods==========
        public void Insert(int index, LinkedNode<T> node)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();

            LinkedNode<T>? temp = head;
            for (int i = 0; i < index; i++)
            {
                temp = temp.Neighbor;
            }
            node.Neighbor = temp.Neighbor;
            temp.Neighbor = node;

            Count++;
        }
        public void AddFirst(LinkedNode<T> node) => Insert(0, node);
        public void AddLast(LinkedNode<T> node) => Insert(Count, node);

        public void RemoveAt(int index)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();

            LinkedNode<T>? temp = head;
            for (int i = 0; i < index; i++)
            {
                temp = temp.Neighbor;
            }
            temp.Neighbor = temp.Neighbor.Neighbor;

            Count--;
        }
        public void RemoveFirst() => RemoveAt(0);
        public void RemoveLast() => RemoveAt(Count - 1);

        public bool Remove(LinkedNode<T> node)
        {
            LinkedNode<T> temp = head;

            for (int i = 0; i < Count; i++)
            {
                if (temp.Neighbor.Equals(node))
                {
                    temp.Neighbor = temp.Neighbor.Neighbor;
                    Count--;
                    return true;
                }
            }

            return false;
        }

        public LinkedNode<T> Get(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

            LinkedNode<T> temp = head;
            for (int i = 0; i <= index; i++)
            {
                temp = temp.Neighbor;
            }

            return temp;
        }

        public int IndexOf(LinkedNode<T> node)
        {
            ArgumentNullException.ThrowIfNull(node);

            LinkedNode<T> temp = head;
            for (int i = 0; i < Count; i++)
            {
                temp = temp.Neighbor;

                if (temp.Equals(node)) return i + 1;
            }

            return -1;
        }

        public bool Contains(LinkedNode<T> node) => IndexOf(node) != -1;

        public void Clear() => head.Neighbor = null;

        public void Display()
        {
            Console.WriteLine("==========Singly Linked List==========");
            Console.WriteLine("Count: " + Count);

            LinkedNode<T> temp = head;
            for (int i = 0; i < Count; i++)
            {
                temp = temp.Neighbor;
                Console.WriteLine($"[{i}]: {temp.Value}");
            }
        }
        #endregion

        #region ==========Constructors==========
        public SinglyLinkedList()
        {
            head = new(default(T));
            Count = 0;
        }
        #endregion
    }

    public class DoublyLinkedList<T> where T : notnull
    {

    }

    public class CircularLinkedList<T> where T : notnull
    {

    }
}
