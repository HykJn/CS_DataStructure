using MyQueue;

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

        public static void PreorderTraversal(BinaryTreeNode<T>? root)
        {
            if (root != null)
            {
                Console.Write(root.item + " ");
                PreorderTraversal(root.lChild);
                PreorderTraversal(root.rChild);
            }
        }

        public static void InorderTraversal(BinaryTreeNode<T>? root)
        {
            if (root != null)
            {
                InorderTraversal(root.lChild);
                Console.Write(root.item + " ");
                InorderTraversal(root.rChild);
            }
        }

        public static void PostorderTraversal(BinaryTreeNode<T>? root)
        {
            if (root != null)
            {
                PreorderTraversal(root.lChild);
                PreorderTraversal(root.rChild);
                Console.Write(root.item + " ");
            }
        }

        public static void LevelTraversal(BinaryTreeNode<T>? root)
        {
            MyLinearQueue<BinaryTreeNode<T>> travelQueue = new(50);
            if (root == null) return;
            travelQueue.Enqueue(root);
            while (!travelQueue.IsEmpty)
            {
                BinaryTreeNode<T>? temp = travelQueue.Dequeue();
                Console.Write(temp.item + " ");
                if (temp.lChild != null) travelQueue.Enqueue(temp.lChild);
                if (temp.rChild != null) travelQueue.Enqueue(temp.rChild);
            }
        }

        public static BinaryTreeNode<int> Search(BinaryTreeNode<int>? root, int key)
        {
            if (root == null) return null;
            if (root.item == key) return root;
            else if (root.item > key) return Search(root.lChild, key);
            else return Search(root.rChild, key);
        }

        public static void Insert(BinaryTreeNode<int> root, BinaryTreeNode<int> node)
        {
            if (node.item == root.item) return;
            else if (node.item > root.item)
            {
                if (root.rChild == null)
                {
                    root.rChild = node; 
                    node.parent = root;
                }
                else Insert(root.rChild, node);
            }
            else
            {
                if (root.lChild == null)
                {
                    root.lChild = node;
                    node.parent = root;
                }
                else Insert(root.lChild, node);
            }
        }

        public static void Delete(BinaryTreeNode<int> root, int key)
        {
            BinaryTreeNode<int> temp = Search(root, key);
            if (temp.lChild == null)
            {
                if (key > temp.parent.item) temp.parent.rChild = temp.rChild;
                else if (key < temp.parent.item) temp.parent.lChild = temp.rChild;
                temp.parent = null;
            }
            else if (temp.rChild == null)
            {
                if (key > temp.parent.item) temp.parent.rChild = temp.lChild;
                else if (key < temp.parent.item) temp.parent.lChild = temp.lChild;
                temp.parent = null;
            }
            else
            {
                BinaryTreeNode<int> succ = temp.rChild;
                while (succ.lChild != null)
                {
                    succ = succ.lChild;
                }
                succ.rChild = temp.rChild;
                succ.lChild = temp.lChild;
                if (key > temp.parent.item) temp.parent.rChild = succ;
                else if (key < temp.parent.item) temp.parent.lChild = succ;
                temp.parent = null;
            }
        }
    }
}