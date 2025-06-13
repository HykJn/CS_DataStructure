namespace CS_DataStructure.Linear
{
    using Nodes;
    public class SinglyLinkedList<T> where T : notnull
    {
        #region ==========Fields==========
        public int Count { get; private set; }
        public T this[int index]
        {
            get;
            set;
        }

        private LinkedNode<T>? head;
        #endregion

        #region ==========Methods==========
        public void Insert(int index, T item)
        {

        }
        public void AddFirst(T item) => Insert(0, item);
        public void AddLast(T item) => Insert(Count, item);

        public void RemoveAt(int index)
        {

        }
        public void RemoveFirst() => RemoveAt(0);
        public void RemoveLast() => RemoveAt(Count - 1);

        public bool Remove(T item)
        {

        }

        public T Get(int index)
        {

        }

        public int IndexOf(T item)
        {

        }

        public bool Contains(T item)
        {

        }

        public void Clear()
        {

        }
        #endregion

        #region ==========Constructors==========
        public SinglyLinkedList()
        {
            head = null;
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
