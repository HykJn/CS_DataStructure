using System.Collections;

namespace CS_DataStructure.Linear
{
    public class ArrayList<T> : IList<T> where T : notnull, IEquatable<T>
    {
        #region ==========Fields==========  
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.count)
                    throw new IndexOutOfRangeException();
                return array[index];
            }
            set
            {
                if (index < 0 || index >= this.count)
                    throw new IndexOutOfRangeException();
                array[index] = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value);
                capacity = value;
                Resize(value);
            }
        }
        public int Count => count;
        public bool IsReadOnly { get; set; }

        private T[] array;
        private int capacity;
        private int count;
        #endregion

        #region ==========Methods==========  
        public int IndexOf(T item)
        {
            //Use Linear search -> O(n)  
            for (int i = 0; i < count; i++)
            {
                if (array[i].Equals(item)) return i;
            }
            return -1;
        }

        public void Add(T item)
        {
            if (IsReadOnly) throw new NotSupportedException();
            if (count == capacity) Resize();
            array[count] = item;
            count++;
        }

        public void Insert(int index, T item)
        {
            if (IsReadOnly) throw new NotSupportedException();
            if (index < 0 || index > count) throw new IndexOutOfRangeException();
            if (count == capacity) Resize();
            if (index == count)
            {
                Add(item);
                return;
            }

            Array.Copy(array, index, array, index + 1, count - index);
            array[index] = item;
            count++;
        }

        public void RemoveAt(int index)
        {
            if (IsReadOnly) throw new NotSupportedException();
            if (index < 0 || index >= count) throw new IndexOutOfRangeException();
            if (index == count - 1)
            {
                count--;
                return;
            }

            Array.Copy(array, index + 1, array, index, count - index);
            count--;
        }

        public bool Remove(T item)
        {
            if (IsReadOnly) throw new NotSupportedException();
            int index = IndexOf(item);
            if (index == -1) return false;

            try
            {
                RemoveAt(index);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public void Clear()
        {
            if (IsReadOnly) throw new NotSupportedException();
            capacity = 16;
            count = 0;
            array = new T[capacity];
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (array[i].Equals(item)) return true;
            }
            return false;
        }

        public void CopyTo(T[] destination, int destinationIndex)
        {
            if (destinationIndex < 0 || destinationIndex >= destination.Length) throw new IndexOutOfRangeException();
            if (destination.Length - destinationIndex < count) throw new ArgumentOutOfRangeException(nameof(destinationIndex));

            Array.Copy(array, 0, destination, destinationIndex, count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return array[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return array[i];
            }
        }

        public void Display()
        {
            Console.WriteLine("==========Array List==========");
            Console.WriteLine("Capacity: " + capacity);
            Console.WriteLine("Count: " + count);
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"[{i}]: {array[i]}");
            }
        }

        private void Resize(int capacity)
        {
            if (IsReadOnly) throw new NotSupportedException();
            ArgumentOutOfRangeException.ThrowIfLessThan<int>(capacity, 0, nameof(capacity));
            if (capacity == this.capacity) return;

            T[] temp = new T[capacity];
            Array.Copy(array, 0, temp, 0, count);
            array = temp;
            this.capacity = capacity;
        }

        private void Resize() => Resize(capacity * 2);
        #endregion

        #region ==========Constructors==========  
        public ArrayList(int capacity)
        {
            this.capacity = capacity;
            array = new T[capacity];
            IsReadOnly = false;
            count = 0;
        }

        public ArrayList() : this(16) { }
        #endregion
    }
}
