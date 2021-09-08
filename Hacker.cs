using System;

namespace PlanYourHeistII
{
    public class Hacker : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Specialty { get; set; } = "Hacker";

        public void PerformSkill(Bank bank)
        {
            bank.AlarmScore -= SkillLevel;
            Console.WriteLine($@"{Name} is hacking the alarm system! Decreased alarm score security by {SkillLevel} points!
                If heist is successful, {Name}'s percentage cut will be {PercentageCut}!");

            if (bank.AlarmScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the alarm system! :O");
            }
        }
    }
}