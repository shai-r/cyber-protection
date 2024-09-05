using cyber_protection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyber_protection.Utils
{
    internal static class BalanceTreeUtil
    {
        private static void Sort(List<Node> list)
        {
            int len = list.Count;
            for (int i = 1; i < len; ++i)
            {
                int key = list[i].Value.MinSeverity;
                int j = i - 1;

                while (j >= 0 && list[j].Value.MinSeverity > key)
                {
                    list[j + 1] = list[j];
                    j = j - 1;
                }
                list[j + 1] = list[i];
            }
        }
        private static Node? BuildTree(List<Node> nodes, int start, int end, int depth)
        {
            if (start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;
            Node node = nodes[mid];
            node.Depth = depth;
            node.Left = BuildTree(nodes, start, mid - 1, depth + 1);
            node.Right = BuildTree(nodes, mid + 1, end, depth + 1);

            return node;
        }

        public static Node? BalanceTree(List<Node> nodes)
        {
            Sort(nodes);
            return BuildTree(nodes, 0, nodes.Count - 1, 0);
        }
    }
}
