using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanYourHeist2
{
    class Program
    {
        static void Main(string[] args)
        {
            Hacker olivia = new Hacker()
            {
                Name = "Olivia",
                SkillLevel = 25,
                PercentageCut = 25
            };
            Hacker renee = new Hacker()
            {
                Name = "Renee",
                SkillLevel = 61,
                PercentageCut = 25
            };
            LockSpecialist jessica = new LockSpecialist()
            {
                Name = "Jessica",
                SkillLevel = 18,
                PercentageCut = 15
            };
            LockSpecialist erica = new LockSpecialist()
            {
                Name = "Erica",
                SkillLevel = 49,
                PercentageCut = 24
            };
            Muscle elizabeth = new Muscle()
            {
                Name = "Elizabeth",
                SkillLevel = 9,
                PercentageCut = 12
            };
            Muscle leslie = new Muscle()
            {
                Name = "Leslie",
                SkillLevel = 29,
                PercentageCut = 15
            };

            List<IRobber> rolodex = new List<IRobber>(){
                olivia, renee, jessica, erica, elizabeth, leslie
            };

            // When the program starts, print out the number of current operatives in the roladex. Then prompt the user to enter the name of a new possible crew member. Once the user has entered a name, print out a list of possible specialties and have the user select which specialty this operative has. The list should contain the following options
            Console.WriteLine($"You have {rolodex.Count()} current operatives in your rolodex.");
            Console.WriteLine();
            Console.Write("Enter the Name of a possible crew member> ");
            string robberName = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Possible Specialties:");
            Console.WriteLine($"1) Hacker (Disables Alarms");
            Console.WriteLine($"2) Muscle (Disarms guards)");
            Console.WriteLine($"3) Lock Specialist (Cracks vault)");
            Console.WriteLine();
            Console.Write("Enter the number of your new associate's specialty> ");
            // Declare variable that will hold user's selection and set it equal to an integer that isn't represented in the menu options.
            // int selection = -1;
            int selection = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write($"Enter {robberName}'s Skill Level (1 - 100)> ");
            int skillLevel = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.Write($"Enter {robberName}'s desired percentage cut of the loot (0 - 100)> ");
            int percentageCut = int.Parse(Console.ReadLine());

            // Maybe use a switch statement
            if (selection == 1)
            {
                Hacker newCrewMember = new Hacker()
                {
                    Name = robberName,
                    SkillLevel = skillLevel,
                    PercentageCut = percentageCut
                };
            }
            else if (selection == 2)
            {
                Muscle newCrewMember = new Muscle()
                {
                    Name = robberName,
                    SkillLevel = skillLevel,
                    PercentageCut = percentageCut
                };
            }
            else if (selection == 3)
            {
                LockSpecialist newCrewMember = new LockSpecialist()
                {
                    Name = robberName,
                    SkillLevel = skillLevel,
                    PercentageCut = percentageCut
                };
            }

            Random generator = new Random();
            int alarmScore = generator.Next(0, 101);
            int vaultScore = generator.Next(0, 101);
            int securityGuardScore = generator.Next(0, 101);
            int cashOnHand = generator.Next(50_000, 1_000_001);

            Bank targetBank = new Bank()
            {
                AlarmScore = alarmScore,
                VaultScore = vaultScore,
                SecurityGuardScore = securityGuardScore,
                CashOnHand = cashOnHand
            };

            // Let's do a little recon next. Print out a Recon Report to the user. This should tell the user what the bank's most secure system is, and what its least secure system is (don't print the actual integer scores--just the name, i.e. Most Secure: Alarm Least Secure: Vault)

            Dictionary<string, int> bankScores = new Dictionary<string, int>()
            {
                {"Alarm", targetBank.AlarmScore},
                {"Vault", targetBank.VaultScore},
                {"Security Guards", targetBank.SecurityGuardScore}
            };

            var maxScore = bankScores.Aggregate((last, current) => last.Value > current.Value ? last : current).Key;
            
            var lowestScore = bankScores.Aggregate((last, current) => last.Value < current.Value ? last : current).Key;

            Console.WriteLine();
            Console.WriteLine("-------------------");
            Console.WriteLine("   Recon Report");
            Console.WriteLine("-------------------");
            Console.WriteLine($"The {maxScore} will be the toughest aspect of this heist.");
            Console.WriteLine($"The {lowestScore} will be the least difficult aspect of this heist.");
            Console.WriteLine();

            
            

        }
    }
}
