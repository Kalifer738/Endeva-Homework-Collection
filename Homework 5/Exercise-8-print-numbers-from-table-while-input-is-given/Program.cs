namespace Exercise_9_print_prompt_while_input_is_not_n
{
    internal class Program
    {
        //9.	Repeat a prompt until the user enters 'N' using a do-while loop.
        static void Main(string[] args)
        {
            string input = "";
            int promptIterations = 0;
            do
            {
                Console.WriteLine($"Number of prompts displayed: {promptIterations}");
                Console.WriteLine("Do you want to continue getting prompts? (Enter 'N' or 'n' to stop)");
                input = Console.ReadLine() ?? "";
                Console.WriteLine();
            } 
            while (input.ToLower() != "n");

            Console.WriteLine("Thank you for coming by!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
