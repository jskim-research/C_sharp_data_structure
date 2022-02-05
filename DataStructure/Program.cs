using System;

namespace DataStructure
{
    class Program
    {
        public static void MakeTree()
        {
            Tree<string> tree = new Tree<string>();

            TreeNode<string> root = new TreeNode<string>("총괄팀");

            {
                TreeNode<string> design = new TreeNode<string>("디자인팀");
                design.Children.Add(new TreeNode<string>("디자이너1"));
                design.Children.Add(new TreeNode<string>("디자이너2"));
                design.Children.Add(new TreeNode<string>("디자이너3"));
                root.Children.Add(design);

            }

            {
                TreeNode<string> develop = new TreeNode<string>("개발팀");
                develop.Children.Add(new TreeNode<string>("개발자1"));
                develop.Children.Add(new TreeNode<string>("개발자2"));
                develop.Children.Add(new TreeNode<string>("개발자3"));
                root.Children.Add(develop);
            }

            {
                TreeNode<string> plan = new TreeNode<string>("기획팀");
                plan.Children.Add(new TreeNode<string>("기획자1"));
                plan.Children.Add(new TreeNode<string>("기획자2"));
                plan.Children.Add(new TreeNode<string>("기획자3"));
                root.Children.Add(plan);
            }

            tree.Push(root, null);
            tree.Print(tree.Root);
            //Console.WriteLine(tree.GetHeight(tree.Root));
        }
        static void Main(string[] args)
        {
            Graph g = new Graph();
            g.Initialize();

            MakeTree();

            Heap<HeapNode<string>> heap = new Heap<HeapNode<string>>();

            heap.Push(new HeapNode<string>() { Weight = 1, Data = "a" });
            heap.Push(new HeapNode<string>() { Weight = 2, Data = "b" });
            heap.Push(new HeapNode<string>() { Weight = 3, Data = "c" });
            heap.Push(new HeapNode<string>() { Weight = 2, Data = "d" });
            heap.Push(new HeapNode<string>() { Weight = 1, Data = "e" });
            heap.Push(new HeapNode<string>() { Weight = 3, Data = "f" });
            heap.Push(new HeapNode<string>() { Weight = 4, Data = "g" });

            Heap<string> heap2 = new Heap<string>();
            heap2.Push("abc");
            heap2.Push("bc");
            heap2.Push("banna");
            heap2.Push("computer");
            heap2.Push("alphabet");

            while (heap.Size > 0)
            {
                HeapNode<string> h = heap.Pop();
                Console.WriteLine(h.Data);
                Console.WriteLine(h.Weight);
            }

            while(heap2.Size > 0)
            {
                Console.WriteLine(heap2.Pop());
            }
        }
    }
}
