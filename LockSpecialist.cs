namespace PlanYourHeistII
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public void PerformSkill(Bank bank)
        {
            bank -= SkillLevel;
            Console.WriteLine($"{Name} is cracking the vault! Decreased vault score security by {SkillLevel} points!");
            if (bank.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has deciphered the vault! :O");
            }
        }
    }
}