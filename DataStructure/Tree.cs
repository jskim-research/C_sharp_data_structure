using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    class TreeNode<T>
    {
        public TreeNode(T _data)
        {
            Data = _data;
        }
        public T Data { get; set; }
        public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();
    }

    class Tree<T>
    {
        public TreeNode<T> Root { get; private set; }

        public void Push(TreeNode<T> node, TreeNode<T> parent)
        {
            if (parent == null)
                Root = node;
            else
                parent.Children.Add(node);
        }

        public void Print(TreeNode<T> node)
        {
            Console.WriteLine(node.Data);
            foreach (TreeNode<T> child in node.Children)
                Print(child);
        }

        public int GetHeight(TreeNode<T> node)
        {
            int max_height = 1;
            foreach(TreeNode<T> child in node.Children)
            {
                int height = GetHeight(child) + 1;
                if (height > max_height)
                    max_height = height;
            }
            return max_height;
        }
    }
}
