using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyber_protection.Models
{
    internal class Data
    {
        public int MinSeverity { get; set; }
        public int MaxSeverity { get; set; }
        public List<string> Defenses { get; set; } = [];
        public override string ToString()
        {
            return $"[{MinSeverity}-{MaxSeverity}] " +
                $"Defenses: {string.Join(", ", Defenses)}";
        }
        public static bool operator <(Data data1, Data data2)
        {
            return data1.MinSeverity < data2.MinSeverity && data1.MaxSeverity < data2.MaxSeverity;
        }
        public static bool operator >(Data data1, Data data2)
        {
            return data1.MinSeverity > data2.MinSeverity && data1.MaxSeverity > data2.MaxSeverity;
        }
        public static bool operator ==(Data data1, Data data2)
        {
            return data1.MinSeverity == data2.MinSeverity && data1.MaxSeverity == data2.MaxSeverity;
        }
        public static bool operator !=(Data data1, Data data2)
        {
            return data1.MinSeverity != data2.MinSeverity || data1.MaxSeverity != data2.MaxSeverity;
        }
        public static bool operator ==(Data data, int num)
        {
            return data.MinSeverity <= num && data.MaxSeverity >= num;
        }
        public static bool operator !=(Data data, int num)
        {
            return data.MinSeverity > num || data.MaxSeverity < num;
        }
        public static bool operator ==(int num, Data data)
        {
            return data.MinSeverity <= num && data.MaxSeverity >= num;
        }
        public static bool operator !=(int num, Data data)
        {
            return data.MinSeverity > num || data.MaxSeverity < num;
        }
    }
}
