using cyber_protection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyber_protection.Utils
{
    internal static class SeverityUtil
    {
        public static int TargetValue(string target) => target switch
        {
            "Web Server" => 10,
            "Database" => 15,
            "User Credentials" => 20,
            _ => 5
        };

        public static int SeverityLevel(this Threat threat) =>
            (threat.Volume * threat.Sophistication) + TargetValue(threat.Target);
    }
}
