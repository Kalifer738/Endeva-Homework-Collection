namespace Exercise_11_print_primary_numbers_from_1_until_n
{
    internal class Program
    {
        //11.	Print all primary numbers between 1 and n where n is provided via the console.
        static void Main(string[] args)
        {
            //Get a valid user input ( input > 0 && input is a number && input is a whole number)
            int n = 0;
            while(true)
            {
                Console.WriteLine("Please enter a positive whole number (n) to find primes from 0 up to n:");
                string? numberInput = Console.ReadLine();
                n = int.TryParse(numberInput, out n) ? n : -1;

                if (n < 0)
                {
                    Console.WriteLine("Invalid input! Please enter a positive whole number next time.");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("--------------------");

            if(n < 2)
            {
                Console.WriteLine("No primes found.");
                return;
            }

            //Iterate over all numbers from 1 until N and print all prime numbers in that range.
            for (int currentNumber = 2; currentNumber <= n; currentNumber++)
            {
                bool isCurrentNumberPrime = true;


                //Check if the current number we are at, is a prime number and limit the range of divisionNumbers from 2 to sqrt(N):
                //https://www.geeksforgeeks.org/maths/how-to-find-prime-numbers/
                //This is algorithm #3
                for (int divisionNumber = 2; divisionNumber <= Math.Sqrt(currentNumber); divisionNumber++)
                {
                    if (currentNumber % divisionNumber == 0)
                    {
                        isCurrentNumberPrime = false;
                        break;  
                    }
                }

                if (isCurrentNumberPrime)
                {
                    Console.WriteLine(currentNumber);
                }
            }
        }
    }
}
