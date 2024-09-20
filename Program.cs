﻿using MyStack;
using MyQueue;
using MyLinkedList;
using MyTree;

namespace Program
{
    public class Program
    {
        public static void Main()
        {
            /*
             *               1
             *         /           \
             *       2              3
             *    /    \         /     \
             *   4      5       6       7   
             *   /\    /
             *  8  9  10
             */
            BinaryTreeNode<int> root = new(1);
            BinaryTreeNode<int> sub1 = new(2);
            BinaryTreeNode<int> sub2 = new(3);
            BinaryTreeNode<int> sub3 = new(4);
            BinaryTreeNode<int> sub4 = new(5);
            BinaryTreeNode<int> sub5 = new(6);
            BinaryTreeNode<int> sub6 = new(7);
            BinaryTreeNode<int> sub7 = new(8);
            BinaryTreeNode<int> sub8 = new(9);
            BinaryTreeNode<int> sub9 = new(10);

            root.lChild = sub1;
            root.rChild = sub2;
            sub1.lChild = sub3;
            sub1.rChild = sub4;
            sub2.lChild = sub5;
            sub2.rChild = sub6;
            sub3.lChild = sub7;
            sub3.rChild = sub8;
            sub4.lChild = sub9;

            Console.Write("Preorder: ");
            PreorderTraversal<int>(root);
            Console.WriteLine();

            Console.Write("Inorder: ");
            InorderTraversal<int>(root);
            Console.WriteLine();

            Console.Write("Postorder: ");
            PostorderTraversal<int>(root);
            Console.WriteLine();

            Console.Write("Level: ");
            LevelTraversal<int>(root);
            Console.WriteLine();
        }

        public static void StackEX() //Brackets Check
        {
            MyStack<char> brackets = new(20);
            Console.Write("Input math expression: ");
            string expression = Console.ReadLine();

            foreach(char c in expression)
            {
                BracketCheck(c);
            }
            if(!brackets.IsEmpty)
            {
                Console.WriteLine("Wrong Bracket Pair");
                return;
            }

            Console.WriteLine("Success!");

            void BracketCheck(char bracket)
            {
                switch (bracket)
                {
                    case '[': case '{': case '(':
                        brackets.Push(bracket);
                        break;
                    case ']': case '}': case ')':
                        char temp = brackets.Pop();
                        if((temp == ')' && bracket != '(') ||
                            (temp == '}' && bracket != '{') ||
                            (temp == ']' && bracket != '['))
                        {
                            Console.WriteLine("Wrong Bracket Pair");
                            return;
                        }
                        break;
                }
            }
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
            BinaryTreeNode<int> root = new(1);
            BinaryTreeNode<int> lNode = new(2);
            BinaryTreeNode<int> rNode = new(3);
            BinaryTreeNode<int> lLChildNode = new(4);
            BinaryTreeNode<int> lRChildNode = new(5);

            root.lChild = lNode;
            root.rChild = rNode;
            lNode.lChild = lLChildNode;
            lNode.rChild = lRChildNode;

            BinaryTreeNode<int> temp = root;

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

        public static void PreorderTraversal<T>(BinaryTreeNode<T>? root)
        {
            if(root != null)
            {
                Console.Write(root.item + " ");
                PreorderTraversal<T>(root.lChild);
                PreorderTraversal<T>(root.rChild);
            }
        }

        public static void InorderTraversal<T>(BinaryTreeNode<T>? root)
        {
            if(root != null)
            {
                InorderTraversal<T>(root.lChild);
                Console.Write(root.item + " ");
                InorderTraversal<T>(root.rChild);
            }
        }

        public static void PostorderTraversal<T>(BinaryTreeNode<T>? root)
        {
            if(root != null)
            {
                PostorderTraversal<T>(root.lChild);
                PostorderTraversal<T>(root.rChild);
                Console.Write(root.item + " ");
            }
        }

        public static void LevelTraversal<T>(BinaryTreeNode<T>? root)
        {
            MyLinearQueue<BinaryTreeNode<T>> travelQueue = new(50);
            if (root == null) return;
            travelQueue.Enqueue(root);
            while(!travelQueue.IsEmpty)
            {
                BinaryTreeNode<T>? temp = travelQueue.Dequeue();
                Console.Write(temp.item + " ");
                if (temp.lChild != null) travelQueue.Enqueue(temp.lChild);
                if (temp.rChild != null) travelQueue.Enqueue(temp.rChild);
            }
        }
    }
}