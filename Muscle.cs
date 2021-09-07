namespace PlanYourHeistII
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public void PerformSkill(Bank bank)
        {
            bank -= SkillLevel;
            Console.WriteLine($"{Name} is confronting the security guards! Decreased guard score security by {SkillLevel} points!");
            if (bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has demolished the security guards! :O");
            }
        }
    }
}