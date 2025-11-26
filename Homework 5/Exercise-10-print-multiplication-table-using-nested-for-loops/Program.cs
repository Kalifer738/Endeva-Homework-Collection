using System;

namespace Exercise_10_print_multiplication_table_using_nested_for_loops
{

    internal class Program
    {
        //10.	Print a multiplication table from 1 to 5 using nested for loops.
        static void Main(string[] args)
        {
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.WriteLine($"{i} * {j} = {i * j}");
                }
                Console.WriteLine();
            }
        }
    }
}
