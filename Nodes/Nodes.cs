namespace CS_DataStructure.Nodes
{
    public abstract class Node<T>(T value) : IEquatable<T> where T : notnull, IEquatable<T>
    {
        public T Value { get; set; } = value;

        public bool Equals(T? other) => Value.Equals(other);
    }

    public class LinkedNode<T>(T value) : Node<T>(value) where T : notnull, IEquatable<T>
    {
        public LinkedNode<T>? Neighbor { get; set; } = null;
    }

    public class LinkedNode2<T>(T value) : LinkedNode<T>(value) where T : notnull, IEquatable<T>
    {
        public LinkedNode<T>? Left => Neighbor;
        public LinkedNode<T>? Right { get; set; } = null;
    }
}