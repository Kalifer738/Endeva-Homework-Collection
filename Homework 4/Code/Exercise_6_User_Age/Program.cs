using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace User_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exercise6();
        }

        static void Exercise6()
        {
            Console.WriteLine("Enter your age:");
            string? input = Console.ReadLine();
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
    }
}