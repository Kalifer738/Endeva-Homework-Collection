using System.Text;
using System.Xml.Linq;

namespace homework_7_fun_greetings
{
    internal class Program
    {
        /*7.	Create a program that uses a method to generate fun greetings.
                Requirements:
                •	Write a method called MagicGreeting that takes one parameter: the user’s name.
                •	It should return a fun, randomized greeting, e.g.:
                •	“Welcome, mighty <name>!”
                •	“Greetings, traveler <name>!”
                •	“Behold, the legendary <name> has arrived!”
                •	In Main(), ask the user for their name.
                •	Call the method and print the greeting. 
        */

        static readonly Random randomGreetingGenerator = new Random();
        static readonly string[] greetings =
        {
            "<name>! <name>! <name>! <name>! <name>! <name>! <name>! <name>! <name>! <name>! <name>! <name>! <name>! <name>!",
            "Welcome, mighty <name>!",
            "Greetings, traveler <name>!",
            "Behold, the legendary <name> has arrived!",
            "It is with great anticipation that we receive the arrival of <name>.",
            "All hail <name>, whose renown precedes them across the domains!",
            "Ready your wits, brave <name>! A new quest lies on the horizon.",
            "The fires of the forge burn brighter in anticipation of the champion <name>.",
            "We are honored by the visit of <name>, whose exploits echo through the ages.",
            "Step into the light, <name>, and tell us of the distant lands you have explored!",
            "<name>! <name>! <name>! <name>!"
        };


        static void Main(string[] args)
        {
            Console.WriteLine("Hello user, please tell us your name: ");
            string userNameInput = Console.ReadLine() ?? "";

            string greetingString = MagicGreeting(userNameInput);

            Console.WriteLine(greetingString);
        }


        static string MagicGreeting(string userName)
        {
            int randomGreeting = randomGreetingGenerator.Next(0, greetings.Length - 1);
            string[] splittedString = greetings[randomGreeting].Split("<name>");

            if(splittedString.Length == 0)
            {
                return greetings[randomGreeting];
            }
            else
            {
                //Create a buffer which has the capacity to hold all of the splited strings + how many times the username appears in the string
                StringBuilder buffer = new StringBuilder(greetings[randomGreeting].Length + (userName.Length * (splittedString.Length - 1)));

                for (global::System.Int32 i = 0; i < splittedString.Length - 1; i++)
                {
                    buffer.Append(splittedString[i]);
                    buffer.Append(userName);
                }
                buffer.Append(splittedString[splittedString.Length - 1]);

                return buffer.ToString();
            }
        }
    }
}
