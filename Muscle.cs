using System;

namespace PlanYourHeistII
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public void PerformSkill(Bank bank)
        {
            bank.SecurityGuardScore -= SkillLevel;
            Console.WriteLine($@"{Name} is confronting the security guards! Decreased guard score security by {SkillLevel} points!
                If heist is successful, {Name}'s percentage cut will be {PercentageCut}!");
            if (bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has demolished the security guards! :O");
            }
        }
    }
}