namespace MyTree
{
    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode<T>? parent, lChild, rChild;
        public T item;

        public BinaryTreeNode(T item)
        {
            this.item = item;
            parent = null;
            lChild = null;
            rChild = null;
        }
    }
}