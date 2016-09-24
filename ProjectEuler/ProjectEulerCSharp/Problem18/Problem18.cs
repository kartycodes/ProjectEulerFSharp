using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ProjectEulerCSharp
{
    public class Problem18
    {
        public void Run()
        {
            TreeNode root = BuildTree();
            var watch = Stopwatch.StartNew();
            root.CalculateMaxSubTree();
            watch.Stop();
            Console.WriteLine($"Max total = {root.MaxSubTree}");
            Console.WriteLine($"Solution took {watch.ElapsedTicks / (float)TimeSpan.TicksPerMillisecond} ms");
        }

        string inputFile = "Problem18\\input67.txt";
        public TreeNode BuildTree()
        {
            using (var reader = new StreamReader(new FileStream(inputFile, FileMode.Open)))
            {
                var nodes = new Dictionary<int,TreeNode>();
                TreeNode root = null;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    int[] numbers = line
                        .Split(' ')
                        .Select(s => int.Parse(s))
                        .ToArray();
                    
                    int index = 0;
                    var newNodes = new Dictionary<int, TreeNode>();
                    foreach (var number in numbers)
                    {
                        var node = new TreeNode() { Value = number };

                        int? firstParentIndex = new int?();
                        int? secondParentIndex = new int?();

                        if (index != 0)
                            firstParentIndex = index - 1;
                        if (index != numbers.Length - 1)
                            secondParentIndex = index;
                        TreeNode parent;
                        if (firstParentIndex.HasValue && nodes.TryGetValue(firstParentIndex.Value, out parent))
                        {
                            parent.RightChild = node;
                        }

                        if (secondParentIndex.HasValue && nodes.TryGetValue(secondParentIndex.Value, out parent))
                        {
                            parent.LeftChild = node;
                        }
                        newNodes[index] = node;
                        index++;
                        if (numbers.Length == 1)
                            root = node;
                    }
                    nodes = newNodes;
                }

                return root;
            }
        }
    }



    public class TreeNode
    {
        public int Value { get; set; }

        public int? MaxSubTree { get; set; }

        public TreeNode LeftChild { get; set; }

        public TreeNode RightChild { get; set; }

        public void CalculateMaxSubTree()
        {
            if (LeftChild == null && RightChild == null)
            {
                MaxSubTree = Value;
                return;
            }
            
            if (!LeftChild.MaxSubTree.HasValue)
                LeftChild.CalculateMaxSubTree();
            if (!RightChild.MaxSubTree.HasValue)
                RightChild.CalculateMaxSubTree();

            MaxSubTree = Value + Math.Max(
                LeftChild.MaxSubTree.Value, 
                RightChild.MaxSubTree.Value);
        }
    }
}
