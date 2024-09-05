using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyber_protection.Utils
{
    internal static class StringExtensionsUtil
    {
        public static string Repeat(this string value, int amount) =>
         string.Concat(Enumerable.Repeat(value, amount));
    }
}
