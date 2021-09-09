using System;
using System.Collections.Generic;
// using System.Linq;

namespace PlanYourHeistII
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($@"
                           Plan Your Heist!
||====================================================================||
||//$\\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\//$\\||
||(100)==================| FEDERAL RESERVE NOTE |================(100)||
||\\$//        ~         '------========--------'                \\$//||
||<< /        /$\              // ____ \\                         \ >>||
||>>|  12    //L\\            // ///..) \\         L38036133B   12 |<<||
||<<|        \\ //           || <||  >\  ||                        |>>||
||>>|         \$/            ||  $$ --/  ||        One Hundred     |<<||
||<<|      L38036133B        *\\  |\_/  //* series                 |>>||
||>>|  12                     *\\/___\_//*   1989                  |<<||
||<<\      Treasurer     ______/Franklin\________     Secretary 12 />>||
||//$\                 ~|UNITED STATES OF AMERICA|~               /$\\||
||(100)===================  ONE HUNDRED DOLLARS =================(100)||
||\\$//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\\$//||
||====================================================================||
            ");

            // instantiating new bank class:
            Bank chase = new Bank()
            {
                AlarmScore = new Random().Next(101),
                VaultScore = new Random().Next(101),
                SecurityGuardScore = new Random().Next(101),
                CashOnHand = new Random().Next(50000, 1000001)
            };

            // Recon report:
            Bank.runReconReport(chase.AlarmScore, chase.VaultScore, chase.SecurityGuardScore);

            // Creating rolodex list of initial team of robbers:
            List<IRobber> rolodex = new List<IRobber>()
            {
                new Hacker() { Name = "Bonnie", SkillLevel = 65, PercentageCut = 50 },
                new Muscle() { Name = "Clyde", SkillLevel = 60, PercentageCut = 30 },
                new LockSpecialist() { Name = "Penguin", SkillLevel = 70, PercentageCut = 20 },
                new Hacker() { Name = "Joker", SkillLevel = 80, PercentageCut = 50 },
                new Muscle() { Name = "Harley", SkillLevel = 75, PercentageCut = 30 },
                new LockSpecialist() { Name = "Robbie", SkillLevel = 90, PercentageCut = 20 },
            };

            Console.WriteLine($"Number of Current Operatives: {rolodex.Count}");

            string userInput = "";
            string memberName = "";
            int memberSpecialty = 0;
            int memberSkillLevel = 0;
            int memberCut = 0;
            bool addNewMember = true;
            int counter = 0; // counter for displaying index of each operative; could also use IndexOf property while in a foreach loop

            // method that prompts user for input to create a new member and add to rolodex list; while loop will continue prompting user 
            // to input corresponding values until member decides not to add a new member to rolodex:
            void createMember()
            {
                while (memberName == "")
                {
                    Console.WriteLine();
                    Console.Write("Please enter the name of a new possible crew member: ");
                    memberName = Console.ReadLine();
                    // userInput = Console.ReadLine();
                    // memberName = userInput;
                }

                while (memberSpecialty <= 0)
                {

                    Console.WriteLine($@"
                    Please choose the operative's specialty and enter the corresponding number:
                    1.) Hacker (Disables Alarms)
                    2.) Muscle (Disarms Guards)
                    3. Lock Specialist (cracks vault)
                    ");
                    userInput = Console.ReadLine();
                    if (userInput == "")
                    {
                        memberSpecialty = 0;
                    }
                    else
                    {
                        memberSpecialty = int.Parse(userInput);
                    }
                }

                while (memberSkillLevel <= 0)
                {

                    Console.Write("Please enter member's skill level (between 1 and 100): ");
                    userInput = Console.ReadLine();
                    if (userInput == "")
                    {
                        memberSkillLevel = 0;
                    }
                    else
                    {
                        memberSkillLevel = int.Parse(userInput);
                    }
                }

                while (memberCut <= 0)
                {

                    Console.Write("Please enter member's desired percentage cut for the mission: ");
                    userInput = Console.ReadLine();
                    if (userInput == "")
                    {
                        memberCut = 0;
                    }
                    else
                    {
                        memberCut = int.Parse(userInput);
                    }
                }

                if (memberName != "" && memberSkillLevel != 0 && memberSpecialty != 0 && memberCut != 0)
                {
                    if (memberSpecialty == 1)
                    {
                        var newMember = new Hacker() { Name = memberName, SkillLevel = memberSkillLevel, PercentageCut = memberCut };
                        rolodex.Add(newMember);
                    }
                    else if (memberSpecialty == 2)
                    {
                        var newMember = new Muscle() { Name = memberName, SkillLevel = memberSkillLevel, PercentageCut = memberCut };
                        rolodex.Add(newMember);
                    }
                    else if (memberSpecialty == 3)
                    {
                        var newMember = new LockSpecialist() { Name = memberName, SkillLevel = memberSkillLevel, PercentageCut = memberCut };
                        rolodex.Add(newMember);
                    }

                    // reset properties  to initial values:
                    memberName = "";
                    memberSkillLevel = 0;
                    memberSpecialty = 0;
                    memberCut = 0;
                }
            }

            // Will create new member so long as variable is true:
            while (addNewMember)
            {
                // Prompt user to add new member or not:
                Console.WriteLine();
                Console.Write("Would you like to add a new member to the crew? (Y/N): ");
                Console.WriteLine();
                userInput = Console.ReadLine().ToLower();

                if (userInput == "y")
                {
                    createMember();
                }
                else
                {
                    break;
                }
            }

            // Printing updated count and rolodex info:
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Robber Team Info:");
            Console.WriteLine();
            Console.WriteLine($"Number of Current Operatives: {rolodex.Count}");

            // Printing info of each robber in list and updating counter value for index:
            foreach (IRobber robber in rolodex)
            {
                Console.WriteLine($"{counter} {robber.Name}'s skill level is {robber.SkillLevel} with {robber.PercentageCut}% of the cut. Specialty is {robber.Specialty}.");
                counter++;
            }

            List<IRobber> crew = new List<IRobber>() { };

            // Prompting user to add a member to crew:
            while (true)
            {
                Console.WriteLine();
                Console.Write("Please enter the number of the operative to add to your crew: ");
                int input = int.Parse(Console.ReadLine());
                crew.Add(rolodex[input]);

                // Removing operative from rolodex after adding member to crew so user cannot add the same robber to crew list:
                // rolodex.Remove(rolodex[input]);

                Console.Write("Would you like to add another member to your crew? (Y/N): ");
                Console.WriteLine();
                string answer = Console.ReadLine().ToLower();

                if (answer != "y")
                {
                    break;
                }
            }

            // Printing member info in crew list:
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Number of Current Operatives in Crew: {crew.Count}");
            Console.WriteLine();

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Let the heist begin! :O");
            Console.WriteLine();

            foreach (IRobber robber in crew)
            {
                Console.WriteLine($"{robber.Name}'s skill level is {robber.SkillLevel} with {robber.PercentageCut}% of the cut. Specialty is {robber.Specialty}.");
            }

            // Starting the heist to evaluate if mission is successful or not:
            foreach (IRobber member in crew)
            {
                member.PerformSkill(chase);
            }

            if (chase.isSecure)
            {
                Console.WriteLine();
                Console.WriteLine("Oh, no! Your team failed the mission and got caught!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Yay! The crew successfully completed the mission!");
                Console.WriteLine();
                foreach (IRobber member in crew)
                {
                    Console.WriteLine($"{member.Name}'s cut from the heist is {(member.PercentageCut * chase.CashOnHand) / 100}!");
                }
            }
        }
    }
}
