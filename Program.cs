using MyStack;
using MyQueue;
using MyLinkedList;
using MyTree;

namespace Program
{
    public class Program
    {
        public static void Main()
        {
            
        }

        public static void StackEX()
        {
            MyStack<int> myStack = new(5);
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.PrintContainer();
        }

        public static void LinearQueueEX()
        {
            MyLinearQueue<int> myQueue = new(5);
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.PrintContainer();
        }

        public static void CircularQueueEX()
        {
            MyCircularQueue<int> myQueue = new(5);
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.Enqueue(4);
            myQueue.Enqueue(5);
            myQueue.Dequeue();
            myQueue.Dequeue();
            myQueue.Enqueue(6);
            myQueue.PrintContainer();
        }

        public static void DequeEX()
        {
            MyDeque<int> myDeque = new(5);
            myDeque.AddFront(1);
            myDeque.AddRear(2);
            myDeque.AddFront(3);
            myDeque.AddRear(4);
            Console.WriteLine(myDeque.PopFront());
            Console.WriteLine(myDeque.PopFront());
            myDeque.PrintContainer();
        }

        public static void SimpleLinkedListEx()
        {
            SingleNode<int> a = new(5);
            SingleNode<int> b = new(3);
            SingleNode<int> c = new(4);

            SimpleLinkedList<int> myList = new();

            myList.Insert(a);
            myList.Insert(b);
            myList.Insert(c, 1);
            myList.PrintList();
            myList.Pop(0);
            //myList.Insert(new SingleNode<int>(1));
            myList.PrintList();
            Console.WriteLine(myList.GetItem(1));
        }

        public static void CircularLinkedListEX()
        {
            CircularLinkedList<string> turnTable = new();

            SingleNode<string> Adam = new("Adam");
            SingleNode<string> Bob = new("Bob");
            SingleNode<string> Charles = new("Charles");
            SingleNode<string> Dominic = new("Dominic");

            turnTable.Insert(Adam);
            turnTable.Insert(Bob);
            turnTable.Insert(Charles);
            turnTable.Insert(Dominic);

            SingleNode<string> turn = Adam;
            for(int i = 0; i < 8; i++)
            {
                Console.WriteLine(turn.item + "'s turn");
                turn = turn.next;
            }
        }

        public static void DoubleLinkedListEx()
        {
            DoubleLinkedList<string> playList = new();

            DoubleNode<string> m1 = new("케이프 혼");
            DoubleNode<string> m2 = new("태양물고기");
            DoubleNode<string> m3 = new("은하");
            DoubleNode<string> m4 = new("라이프리뷰");

            playList.Insert(m1);
            playList.Insert(m2);
            playList.Insert(m3);
            playList.Insert(m4);

            DoubleNode<string> nowPlaying = m1;

            Console.WriteLine("=======Playlist=======");
            for (int i = 0; i < playList.size; i++)
            {
                Console.WriteLine(nowPlaying.item);
                nowPlaying = nowPlaying.next;
            }
            Console.WriteLine("======================");

            PlaylistControl();

            void PlaylistControl()
            {
                bool flag = true;
                while(flag)
                {
                    Console.WriteLine("Now Playing: " + nowPlaying.item);
                    Console.WriteLine("Next: > / Prev: < / Stop: Stop");
                    Console.Write("Command: ");
                    string command = Console.ReadLine();
                    switch(command)
                    {
                        case ">":
                            nowPlaying = nowPlaying.next;
                            break;
                        case "<":
                            nowPlaying = nowPlaying.prev;
                            break;
                        case "Stop":
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("Wrong Command");
                            break;
                    }
                }
            }
        }

        public static void TreeLinkExpressionEx()
        {
            TreeNode<int> root = new(1);
            TreeNode<int> lNode = new(2);
            TreeNode<int> rNode = new(3);
            TreeNode<int> lLChildNode = new(4);
            TreeNode<int> lRChildNode = new(5);

            root.lChild = lNode;
            root.rChild = rNode;
            lNode.lChild = lLChildNode;
            lNode.rChild = lRChildNode;

            TreeNode<int> temp = root;

            for (int i = 0; i < 5; i++)
            {
                Console.Write(temp.item);
                if (temp.lChild != null)
                {
                    Console.WriteLine();
                    temp = temp.lChild;
                }
                else if (temp.rChild != null)
                {
                    Console.WriteLine();
                    temp = temp.rChild;
                }
                else
                {
                    Console.WriteLine("<--- Leaf Node");
                    break;
                }
            }
        }
    }
}