using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyber_protection.Models
{
    internal class Node
    {
        public required Data Value {  get; set; }
        public int Depth { get; set; } = -1;
        public Node? Left { get; set; }
        public Node? Right { get; set; }
    }
}