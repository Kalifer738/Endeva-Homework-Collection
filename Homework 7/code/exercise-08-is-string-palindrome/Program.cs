namespace exercise_08_is_string_palindrome
{
    internal class Program
    {
        //8.	Create a method that checks if a provided string is palindrome or not.
        static void Main(string[] args)
        {   
            string a = "abba";
            string b = "aba";
            string c = "abva";

            OutputIfWordIsPalindrome(a);
            OutputIfWordIsPalindrome(b);
            OutputIfWordIsPalindrome(c);
        }

        static void OutputIfWordIsPalindrome(string input)
        {
            if (IsStringPalindrome(input))
            {
                Console.WriteLine($"{input} is a palindrome");
            }
            else
            {
                Console.WriteLine($"{input} is not a palindrome");
            }
        }

        static bool IsStringPalindrome(string input)
        {
            int iterations = (int)(Math.Ceiling(input.Length / 2f));


            //Check if the string is a palindrome by comparing the first (leftPointe) and last(rightPointer) character of the string, while moving towards the middle until both pointers meet (when input is not of even length) or pass eachother (when the input is of even length):
            for (int leftPointer = 0; leftPointer < iterations; leftPointer++)
            {
                int rightPointer = input.Length - leftPointer - 1;
                if (input[leftPointer] != input[rightPointer])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
