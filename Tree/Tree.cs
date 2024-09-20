namespace MyTree
{
    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode<T>? lChild, rChild;
        public T item;

        public BinaryTreeNode(T item)
        {
            this.item = item;
            lChild = null;
            rChild = null;
        }
    }

    public class ParentTreeNode<T>
    {
        public ParentTreeNode<T>? parent;
        public T item;

        public ParentTreeNode(T item)
        {
            this.item = item;
            parent = null;
        }
    }
}