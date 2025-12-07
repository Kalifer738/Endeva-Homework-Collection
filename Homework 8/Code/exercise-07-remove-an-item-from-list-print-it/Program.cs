namespace exercise_07_remove_an_item_from_list_print_it
{
    internal class Program
    {
        /*
         7.	Remove an item from a List and print the updated list.
            Example:
                names.Remove("Ani");
                // Print updated list

        */
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            names.Add("Georgi");
            names.Add("Atanas");
            names.Add("Nikolay");
            names.Add("John");
            names.Add("Konstantin");

            names.Remove("Nikolay");

            names.ForEach(x => Console.WriteLine(x));
        }
    }
}
