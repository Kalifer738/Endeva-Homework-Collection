namespace Exercise_8_print_numbers_from_1_until_input_number
{
    internal class Program
    {
        //8.	Ask the user for a number greater than 100 using a while loop,
        //      exit the loop when you print all numbers between 1 and the provided number.
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter a number greater than 100:");
                string input = Console.ReadLine() ?? "";
                int number = default;

                int.TryParse(input, out number);

                if (number > 100)
                {
                    for (int i = 1; i <= number; i++)
                    {
                        Console.WriteLine(i);
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again...");
                }
            }
        }
    }
}
