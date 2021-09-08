using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanYourHeistII
{
    public class Bank
    {
        public int CashOnHand { get; set; }
        public int AlarmScore { get; set; }
        public int VaultScore { get; set; }
        public int SecurityGuardScore { get; set; }
        public bool isSecure
        {
            get
            {
                if (AlarmScore <= 0 && VaultScore <= 0 && SecurityGuardScore <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static void runReconReport(int AlarmScore, int VaultScore, int SecurityGuardScore)
        {
            var securityScore = new List<int> { AlarmScore, VaultScore, SecurityGuardScore };
            // conditional for determining which property is most secure:
            if (securityScore.Max() == AlarmScore)
            {
                Console.WriteLine($"Most secure: Alarm");
            }
            else if (securityScore.Max() == VaultScore)
            {
                Console.WriteLine($"Most secure: Vault");
            }
            else
            {
                Console.WriteLine($"Most secure: Security Guard");
            }

            // conditional for determining which property is least secure:
            if (securityScore.Min() == AlarmScore)
            {
                Console.WriteLine($"Least secure: Alarm");
            }
            else if (securityScore.Min() == VaultScore)
            {
                Console.WriteLine($"Least secure: Vault");
            }
            else
            {
                Console.WriteLine($"Least secure: Security Guard");
            }
        }
    }
}