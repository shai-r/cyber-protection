using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyber_protection.Models
{
    internal class Threat
    {
        public required string ThreatType {  get; set; }
        public int Volume {  get; set; }
        public int Sophistication {  get; set; }
        public required string Target { get; set; }
    }
}