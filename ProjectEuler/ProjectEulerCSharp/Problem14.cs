using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerCSharp
{
    public class Problem14
    {
        private Dictionary<long, CollatzNode> Nodes { get; } = new Dictionary<long, CollatzNode>();

        public void Run()
        {
            int max = 0;
            int maxLength = 0;
            for (int i = 1; i <= 1000000; i++)
            {
                var x = BuildCollatzSequenceAndReturnLength(i);
                if (x > maxLength)
                {
                    max = i;
                    maxLength = x;
                }
            }

            Console.WriteLine(max);
            Console.WriteLine(maxLength);
        }

        public int BuildCollatzSequenceAndReturnLength(long n)
        {
            CollatzNode node;
            if (Nodes.TryGetValue(n, out node))
            {
                return node.Length;
            }
            else
            {
                var head = BuildCollatzSequence(n);
                return head.Length;
            }
        }
        public CollatzNode BuildCollatzSequence(long n)
        {
            CollatzNode newNode;

            if (!Nodes.TryGetValue(n, out newNode))
            {
                newNode = new CollatzNode
                {
                    N = n
                };
                Nodes[n] = newNode;
            }

            if (n == 1)
            {
                newNode.Length = 1;
                return newNode;
            }

            if (n % 2 == 0)
            {
                newNode.Next = BuildCollatzSequence(n / 2);
            }
            else
            {
                newNode.Next = BuildCollatzSequence(3 * n + 1);
            }
            newNode.Length = newNode.Next.Length + 1;
            return newNode;
        }
    }

    public class CollatzNode
    {
        public long N { get; set; }

        public int Length { get; set; }

        public CollatzNode Next { get; set; }
    }
}
