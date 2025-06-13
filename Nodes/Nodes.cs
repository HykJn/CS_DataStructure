namespace CS_DataStructure.Nodes
{
    public class Node<T>(T value) where T : notnull
    {
        public T Value { get; set; } = value;
    }

    public class LinkedNode<T>(T value) : Node<T>(value) where T : notnull
    {
        public LinkedNode<T>? Neighbor { get; set; } = null;
    }

    public class LinkedNode2<T>(T value) : LinkedNode<T>(value) where T : notnull
    {
        public LinkedNode<T>? Left => Neighbor;
        public LinkedNode<T>? Right { get; set; } = null;
    }
}