namespace exercise_10_return_middle_character_or_both_middle_characters
{
    internal class Program
    {
        //10. Write a C# Sharp program to find the central character(s) in a given string.
        //  Return the middle character if the string length is odd and return two middle characters if the string length is even.
        static void Main(string[] args)
        {
            string input = Console.ReadLine() ?? "";


            if(input.Length % 2 == 0)
            {
                Console.Write(input[input.Length / 2 - 1]);
                Console.Write(input[input.Length / 2 ]);
            }
            else
            {
                Console.WriteLine(input[input.Length / 2]);
            }
        }
    }
}
