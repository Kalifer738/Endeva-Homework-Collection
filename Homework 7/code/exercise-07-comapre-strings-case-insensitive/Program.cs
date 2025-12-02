namespace exercise_07_comapre_strings_case_insensitive
{
    internal class Program
    {
        //7.	Create a method that compares two strings for equality, ignoring case sensitivity.
        static void Main(string[] args)
        {
            string a = "Test";
            string b = "test";

            bool areStringsEqual = Object.Equals(a.ToLower(), b.ToLower());
            Console.WriteLine($"Are your string equal(case insensitive): {areStringsEqual}");
        }
    }
}
