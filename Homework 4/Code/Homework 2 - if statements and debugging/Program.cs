using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Homework2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press 0 to exit");
            Console.WriteLine("Press 1 for exercise 6(\"User Age\"");
            Console.WriteLine("Press 2 for exercise 7(\"User Grade\"");
            Console.WriteLine("Press 3 for exercise 8(\"Buggy Code\"");
            Console.WriteLine("Press 4 for optional exercise 1(\"Login System\"");
            Console.WriteLine("Press 5 for optional exercise 2(\"Programmer Vacation\"");

            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "0": Console.WriteLine("Exiting..."); return;
                    case "1": Console.Clear(); Exercise6(); break;
                    case "2": Console.Clear(); Exercise7(); break;
                    case "3": Console.Clear(); Exercise8(); break;
                    case "4": Console.Clear(); OptionalExercise1(); break;
                    case "5": Console.Clear(); OptionalExercise2(); break;
                    default: Console.WriteLine("Invalid option! Press any key to try again..."); Console.ReadKey(); break;
                }
            }
        }

        private static void Exercise8()
        {
            Console.WriteLine("Provide program arguments seperated by a comma:");

            string[] args = (Console.ReadLine() ?? "").Split(", ");

            DebuggingPractice.Program.Main(args);
        }

        static void Exercise6()
        {
            Console.WriteLine("Enter your age:");
            string ?input = Console.ReadLine();
            int age = int.TryParse(input, out age) ? age : -1;

            
            if (age < 0)
            {
                Console.WriteLine("Invalid age.");
            }
            else if (age < 18)
            {
                Console.WriteLine("You are a minor.");
            }
            else if (age < 60)
            {
                Console.WriteLine("You are an adult.");
            }
            else if (age < 110)
            {
                Console.WriteLine("You are a senior.");
            }
            else if (age < 60000000)
            {
                Console.WriteLine("You are a fossil.");
            }
        }

        static void Exercise7()
        {
            Console.WriteLine("Enter your student grade from 2 to 6 (Bulgarian System) or F to A (American System):");

            string? input = Console.ReadLine();
            if(input == null || input.Length != 1)
            {
                Console.WriteLine("Invalid input.");
                return;
            }
            else
            {
                input = input.ToLower();
            }

            float grade = 0;
            // f == 2
            // e == 3
            // d == 3.5
            // c == 4
            // b == 5
            // a == 6

            switch (input)
            {
                case "A": grade = 6; break;
                case "B": grade = 5; break;
                case "C": grade = 4; break;
                case "D": grade = 3.5f; break;
                case "E": grade = 3; break;
                case "F": grade = 2; break;
                case "6": grade = 6; break;
                case "5": grade = 5; break;
                case "4": grade = 4; break;
                case "3": grade = 3; break;
                case "2": grade = 2; break;
                default: break;
            }

            if(grade > 1)
            {
                if (grade > 2)
                {
                    if (grade > 3)
                    {
                        if (grade > 4)
                        {
                            if (grade > 5)
                            {
                                Console.WriteLine("You have an excellent grade!");
                                return;
                            }
                            Console.WriteLine("You have a very good grade!");
                            return;
                        }
                        Console.WriteLine("You have a good grade.");
                        return;
                    }
                    Console.WriteLine("You have a passable grade.");
                    return;
                }
                Console.WriteLine("You have a failing grade.");
                return;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
        
        static void OptionalExercise1()
        {
            //A program that checks if the given username is in a dictionary.
            //Next it asks for the password while displaying it as "*" symbols instead of letters
            //  if the user presses backspace, it removes one symbol from the displayed password symbols.
            //  if the user presses enter, it continues to check the password against a username.
            Dictionary<string, string> registeredUsersAndPasswords = new Dictionary<string, string>
            {
                // Key (Username) - Value (Password)
                { "Kalifer", "parola" },
                { "Georgi", "myParola" },
                { "Kalin", "Chushkopek7000" },
                { "Konstantin", "hotDog1" }
            };

            Console.WriteLine("Please input your username: ");
            string userName = Console.ReadLine() ?? "";
            
            if (registeredUsersAndPasswords.ContainsKey(userName))
            {
                Console.Clear();
                Console.Write($"Please input your password: ");

                ConsoleKeyInfo userPressedKey;
                StringBuilder passwordInput = new StringBuilder();

                //Display "*" for each letter, or remove letters with backspace while the user is inputing their password
                do
                {
                    userPressedKey = Console.ReadKey(true);
                   
                    //Check if the keychar is English letter(a, b, c, ...), number (1, 2, 3, ...) or symbol (!, #, *, ...) 
                    if (userPressedKey.KeyChar >= 33 && userPressedKey.KeyChar <= 126)
                    {
                        Console.Write('*');
                        passwordInput.Append(userPressedKey.KeyChar);
                    }
                    else if (userPressedKey.Key == ConsoleKey.Backspace)
                    {
                        passwordInput.Remove(passwordInput.Length - 1, 1);
                        
                        Console.Clear();
                        Console.Write($"Please input your password: ");
                        for (int i = 0; i < passwordInput.Length; i++)
                        {
                            Console.Write('*');
                        }
                    }
                    else if(userPressedKey.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
                while (true);

                //We know that the username already exists in the dictionary, no need to use a method
                if (registeredUsersAndPasswords[userName] == passwordInput.ToString())
                {
                    Console.WriteLine("Logged in! Press any key to exit...");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid password. Press any key to exit...");
                    Console.ReadKey();
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid username. Press any key to exit...");
                Console.ReadKey();
                return;
            }
        }
    
        static void OptionalExercise2()
        {
            // Budget [10.00 - 5000.00]
            string budgetInput = Console.ReadLine() ?? "";

            float budget = 0;
            float.TryParse(budgetInput, out budget);

            if(budget < 10 || budget > 5000)
            {
                throw new Exception("Invalid input! Budget must be between 10.00 and 5000.00");
            } 
            else
            {
                budget = (float)Math.Round(budget, 2);
            }

            // Season ["summer", "winter"]
            string season = Console.ReadLine() ?? "";
            float budgetPercent = 0;
            string destination = "";
            string accommodationType = "";

            //  Winter: Hotel
            //      Budget <= 100: Bulgaria
            //      Percent To Spend: 70%
            //      ------------------------
            //      Budget <= 1000: Balkans
            //      Percent To Spend: 80%
            //      ------------------------
            //      Budget > 1000: Europe
            //      Percent To Spend: 90%
            //
            //  Summer: Camp
            //      Budget <= 100: Bulgaria
            //      Percent To Spend: 30%
            //      ------------------------
            //      Budget <= 1000: Balkans
            //      Percent To Spend: 40%
            //      ------------------------
            //      Budget > 1000: Europe
            //      Percent To Spend: 90%
            //
            if (season == "winter")
            {
                accommodationType = "Hotel";
                if (budget <= 100)
                {
                    budgetPercent = 0.70f;
                    destination = "Bulgaria";
                }
                else if(budget <= 1000)
                {
                    budgetPercent = 0.80f;
                    destination = "Balkans";
                }
                else
                {
                    budgetPercent = 0.90f;
                    destination = "Europe";
                }
            }
            else if(season == "summer")
            {
                accommodationType = "Camp";
                if (budget <= 100)
                {
                    budgetPercent = 0.30f;
                    destination = "Bulgaria";
                }
                else if (budget <= 1000)
                {
                    budgetPercent = 0.40f;
                    destination = "Balkans";
                }
                else
                {
                    budgetPercent = 0.90f;
                    destination = "Europe";

                    //Programmers always go to a hotel when they have money:
                    accommodationType = "Hotel";
                }
            }
            else
            {
                throw new Exception("Invalid input! Season must be winter or summer! Programmers don't rest during other periods!");
            }
           
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{accommodationType} - {(budget * budgetPercent):F2}");
        }
    }
}

//using System;
//It i not okay to define multiple namespaces in one file... especially with an entry point... buuut since this is an exercise... I used a "hack" fix to justs specify the namespace+startup class in csproj:
//    <StartupObject>Homework2.Program</StartupObject>
namespace DebuggingPractice
{
    class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0 || args == null)
            {
                Console.WriteLine("Invalid arguments. Please try again and input a number.");   
                return;
            }

            int score = default;
            int.TryParse(args[0], out score);

            if (score > 90)
                Console.WriteLine("Great job!");
            else
                Console.WriteLine("Bad job ;(");
        }
    }
}