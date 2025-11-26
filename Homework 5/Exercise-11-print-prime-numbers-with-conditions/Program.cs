namespace Exercise_12_print_positive_even_numbers
{
    internal class Program
    {
        //12.	Loop through all numbers between N and 999 from the console,
        //      where N can be between (minus) 1000 and 999,
        //      and prints even numbers,
        //      skip negatives,
        //      and stop at 999.
        static void Main(string[] args)
        {
            //Get a valid user input ( input <= -1000 && input >= 999 && input is a number && input is a whole number)
            int n = 0;
            while (true)
            {
                Console.WriteLine("Please enter a number between -1000 and 999 (inclusive): ");
                string? numberInput = Console.ReadLine();
                n = int.TryParse(numberInput, out n) ? n : -1001;

                //N can be between (minus) 1000 and 999,
                if (n > 999 || n < -1000)
                {
                    Console.WriteLine("Invalid input!");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    break;
                }
            }

            //Loop through all numbers between N and 999 from the console,
            for (int i = n; i <= 999; i++)
            {
                //skip negatives,
                if (i < 0)
                {
                    continue;
                }

                //and prints even numbers,
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
