using System;
using System.Collections.Generic;

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

            List<IRobber> rolodex = new List<IRobber>()
            {
                new Hacker() { Name = "Bonnie", SkillLevel = 50, PercentageCut = 20 },
                new Muscle() { Name = "Clyde", SkillLevel = 60, PercentageCut = 15 },
                new LockSpecialist() { Name = "Penguin", SkillLevel = 70, PercentageCut = 25 },
                new Hacker() { Name = "Joker", SkillLevel = 80, PercentageCut = 15 },
                new Muscle() { Name = "Harley", SkillLevel = 45, PercentageCut = 15 },
                new LockSpecialist() { Name = "Robbie", SkillLevel = 30, PercentageCut = 10 },
            };

            Console.WriteLine($"Number of Current Operatives: {rolodex.Count}");

            string userInput = "";
            string memberName = "";
            int memberSpecialty = 0;
            int memberSkillLevel = 0;
            int memberCut = 0;
            bool addNewMember = true;

            // method to create a new member and add to rolodex list; while loop will continue prompting user to input corresponding
            // values until member decides not to add a new member to rolodex:
            void createMember()
            {
                while(memberName == "") {
                    Console.Write("Please enter the name of a new possible crew member: ");
                    memberName = Console.ReadLine();
                }

                while (memberSpecialty == 0)
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

                while (memberSkillLevel == 0)
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

                while (memberCut == 0)
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
                        var newTeamMember = new Hacker() { Name = memberName, SkillLevel = memberSkillLevel, PercentageCut = memberCut};
                        rolodex.Add(newTeamMember);
                        memberName = "";
                        memberSkillLevel = 0;
                        memberSpecialty = 0;
                        memberCut = 0;
                    } 
                    else if (memberSpecialty == 2)
                    {
                        var newTeamMember = new Muscle() { Name = memberName, SkillLevel = memberSkillLevel, PercentageCut = memberCut};
                        rolodex.Add(newTeamMember);
                        memberName = "";
                        memberSkillLevel = 0;
                        memberSpecialty = 0;
                        memberCut = 0;
                    }
                    else if (memberSpecialty == 3)
                    {
                        var newTeamMember = new LockSpecialist() { Name = memberName, SkillLevel = memberSkillLevel, PercentageCut = memberCut};
                        rolodex.Add(newTeamMember);
                        memberName = "";
                        memberSkillLevel = 0;
                        memberSpecialty = 0;
                        memberCut = 0;
                    }
                   
                    Console.WriteLine();
                    Console.Write("Would you like to add a new member to the team? (Y/N): ");
                    Console.WriteLine();
                    userInput = Console.ReadLine().ToLower();
                    if (userInput == "y")
                    {
                        addNewMember = true;
                    }
                    else
                    {
                        addNewMember = false;
                    }
                }
            }
            
            while (addNewMember)
            {
                createMember();
            }

            // Priting updated count and rolodex info:
            Console.WriteLine($"Number of Current Operatives: {rolodex.Count}");
            Console.WriteLine();
            Console.WriteLine("Robber Team Info:");
            Console.WriteLine();
            foreach (IRobber robber in rolodex)
            {
                Console.WriteLine($"{robber.Name}'s skill level is {robber.SkillLevel} with {robber.PercentageCut}% of the cut.");
            }
            
        }
    }
}
