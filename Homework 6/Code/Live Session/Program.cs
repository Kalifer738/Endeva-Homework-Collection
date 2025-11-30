namespace Live_Session_4_digit_guesser_with_hints
{
    internal class Program
    {
        //  A lock guessing game where the user guesses a lock combination.
        //  You are able to change the parameters of the game by editing the constants inside of the function.
        static void Main(string[] args)
        {
            const int minInputDigit = 0;
            const int maxInputDigit = 9;
            const int combinationLockLength = 4;
            const int numberOfAllowedHints = 1;

            Random randomGenerator = new Random();
            int[] lockDigits = new int[combinationLockLength];
            int[] guessedDigitsBuffer = new int[combinationLockLength];
            int[] hintedNumbersPositions = new int[numberOfAllowedHints];

            for (int i = 0; i < combinationLockLength; i++)
            {
                //digits[i] = 1; //Testing
                lockDigits[i] = randomGenerator.Next(minInputDigit, maxInputDigit);
            }


            int currentDigitToGuess = 0;
            int usedNumberOfHints = 0;
            while(true)
            {
                // Check if the given digits are correct, close or wrong
                if (currentDigitToGuess >= combinationLockLength)
                {
                    bool correctlyGuessTheNumber = true;
                    for (int i = 0; i <= combinationLockLength; i++)
                    {
                        if (Math.Abs(guessedDigitsBuffer[i] - lockDigits[i]) == 1)
                        {
                            Console.WriteLine("Close");
                            correctlyGuessTheNumber = false;
                            break;
                        }
                        else if (guessedDigitsBuffer[i] != lockDigits[i])
                        {
                            Console.WriteLine("Wrong");
                            correctlyGuessTheNumber = false;
                            break;
                        }
                    }
                    if(correctlyGuessTheNumber)
                    {
                        Console.WriteLine("Correct");
                        return;
                    }
                    currentDigitToGuess = 0;
                }

                //Read the user input
                string userInput = Console.ReadLine() ?? "";

                // Hint system handling
                if (userInput.ToLower() == "hint")
                {
                    if (usedNumberOfHints >= numberOfAllowedHints)
                    {
                        Console.WriteLine($"You ran out of hints :( Here are the already given hints:");

                        //Display the already hinted numbers:
                        for (int i = 0; i < usedNumberOfHints; i++)
                        {
                            Console.WriteLine($"Position({hintedNumbersPositions[i]}) number({lockDigits[hintedNumbersPositions[i]]}) ");
                        }
                    }
                    else
                    {
                        hintedNumbersPositions[usedNumberOfHints] = randomGenerator.Next(0, combinationLockLength);
                        usedNumberOfHints++;
                        Console.WriteLine($"Hint used! You have {numberOfAllowedHints - usedNumberOfHints} left to use!");
                        Console.WriteLine($"Here is your hint, position({hintedNumbersPositions[usedNumberOfHints - 1]}) number({lockDigits[hintedNumbersPositions[usedNumberOfHints - 1]]}) ");
                    }
                }
                // Digit input handling
                else
                {
                    int numberInput;
                    if (int.TryParse(userInput, out numberInput))
                    {
                        guessedDigitsBuffer[currentDigitToGuess] = numberInput;
                        currentDigitToGuess++;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input! Valid inptus are numbers from 0 to 9 and 'hint'!");
                    }
                }
            }
        }
    }
}
