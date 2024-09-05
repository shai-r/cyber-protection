using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static cyber_protection.Utils.StringExtensionsUtil;
using static cyber_protection.Utils.BalanceTreeUtil;

namespace cyber_protection.Models
{
    internal class BSTree
    {
        Node? Root { get; set; }
        private int FindMinSeverity(Node root)
        {
            var current = root;
            while (current.Left != null)
                current = current.Left;
            return current.Value.MinSeverity;
        }
        public void Insert(Data value) { Root = InsertRecursive(value, Root, 0); }
        public Node? InsertRecursive(Data value, Node? root, int depth)
        {
            if (root == null) { return new Node() { Value = value, Depth = depth }; }
            if (value < root.Value) { root.Left = InsertRecursive(value, root.Left, root.Depth + 1); }
            if (value > root!.Value) { root.Right = InsertRecursive(value, root.Right, root.Depth + 1); }
            return root;
        }
        public override string ToString()
        {
            if (Root == null){ return "Tree is null."; }
            return ToStringPreOrderRecursive(Root, "", "Root");
        }
        private string ToStringPreOrderRecursive(Node? root, string toString, string type)
        {
            if (root == null) { return string.Empty; }

            string introduction = (type == "Root")
            ? introduction = $"Tree structure with left/right child distinctions\n"
            : introduction = $"{"     ".Repeat(root.Depth)}|___";

            return $"{introduction}{type}: {root.Value}\n" +
                $"{ToStringPreOrderRecursive(root.Left, toString, "Left Child")}" +
                $"{ToStringPreOrderRecursive(root.Right, toString, "Right Child")}";
        }
       
        public List<string> PreOrderSearch(int TargetValue)
        {
            if(Root == null)
            {
                return [];
            }
            if (TargetValue < FindMinSeverity(Root))
            {
                return ["Attack severity is below the threshold. Attack is ignored"];
            }
            return PreOrderSearchRecursive(TargetValue, Root)
                ?? ["No suitable defence was !found. Brace for impact"];
        }
        private List<string>? PreOrderSearchRecursive(int TargetValue, Node? root)
        {
            if (root == null) return null;

            if (root.Value == TargetValue)
                return root.Value.Defenses;
            return PreOrderSearchRecursive(TargetValue, root.Left)
                ?? PreOrderSearchRecursive(TargetValue, root.Right);
        }
        public bool IsBalanced() => IsBalancedRecursive(Root) > 0;
        public int IsBalancedRecursive(Node? root)
        {
            if (root == null)
                return 0;
            int lh = IsBalancedRecursive(root.Left);
            if (lh == -1)
                return -1;
            int rh = IsBalancedRecursive(root.Right);
            if (rh == -1)
                return -1;

            if (lh > rh + 1 || rh > lh + 1)
                return -1;
            else
                return Math.Max(lh, rh) + 1;
        }
        public BSTree BildBalanceTree() =>
            new() { Root = BalanceTree(GetAllNodesInOrder()) };

        public List<Node> GetAllNodesInOrder()
        {
            List<Node> list = new();
            GetAllNodesInOrderRecursive(Root, list);
            return list;
        }
        private void GetAllNodesInOrderRecursive(Node? root, List<Node> list)
        {
            if (root == null) return;
            GetAllNodesInOrderRecursive(root.Left, list);
            list.Add(root);
            GetAllNodesInOrderRecursive(root.Right, list);
        }
        public List<Node> GetAllNodesPreOrder()
        {
            List<Node> list = new();
            GetAllNodesPreOrderRecursive(Root, list);
            return list;
        }
        private void GetAllNodesPreOrderRecursive(Node? root, List<Node> list)
        {
            if (root == null) return;
            list.Add(root);
            GetAllNodesPreOrderRecursive(root.Left, list);
            GetAllNodesPreOrderRecursive(root.Right, list);
        }
    }
}
