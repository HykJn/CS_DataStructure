namespace MyTree
{
    public class TreeNode<T>
    {
        public TreeNode<T>? lChild, rChild;
        public T item;

        public TreeNode(T item)
        {
            this.item = item;
            lChild = null;
            rChild = null;
        }
    }
}