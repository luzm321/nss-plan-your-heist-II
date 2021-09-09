using System;

namespace PlanYourHeistII
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Specialty { get; set; } = "Lock Specialist";

        public void PerformSkill(Bank bank)
        {
            bank.VaultScore -= SkillLevel;
            Console.WriteLine($@"{Name} is cracking the vault! Decreased vault score security by {SkillLevel} points! 
            If heist is successful, {Name}'s cut will be {PercentageCut}%!");

            if (bank.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has deciphered the vault! :D");
            }
        }
    }
}