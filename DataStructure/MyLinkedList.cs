using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    class MyLinkedListNode<T>
    {
        public T Data { get; set; }
        public MyLinkedListNode<T> Prev { get; set; }
        public MyLinkedListNode<T> Next { get; set; }
    }

    class MyLinkedList<T>
    {
        public MyLinkedListNode<T> head { get; private set; }
        public MyLinkedListNode<T> tail { get; private set; }
        public int Size { get; private set; }

        public MyLinkedList()
        {
            head = null;
            tail = null;
            Size = 0;
        }

        public void Add(T data)
        {
            MyLinkedListNode<T> new_node = new MyLinkedListNode<T>();
            new_node.Data = data;
            new_node.Prev = null;
            new_node.Next = null;

            if (head == null && tail == null)
            {
                head = tail = new_node;
            }
            else
            {
                new_node.Prev = tail;
                tail.Next = new_node;
                tail = new_node;
            }

            Size++;
        }

        public void Remove(MyLinkedListNode<T> node)
        {

            if (node == head)
            {
                head = head.Next;
                head.Prev = null;
            }
            else if (node == tail)
            {
                tail = tail.Prev;
                tail.Next = null;
            }
            else
            {
                MyLinkedListNode<T> prev = null, cur = head;

                while (cur != null)
                {
                    if (cur == node)
                    {
                        prev.Next = cur.Next;
                        if (cur.Next != null)
                            cur.Prev = prev;
                        break;
                    }

                    prev = cur;
                    cur = cur.Next;
                }
            }

            Size--;
        }

        public void Print()
        {
            MyLinkedListNode<T> p = head;

            while (p != null)
            {
                Console.WriteLine(p.Data.ToString());
                p = p.Next;
            }
        }
    }
}
