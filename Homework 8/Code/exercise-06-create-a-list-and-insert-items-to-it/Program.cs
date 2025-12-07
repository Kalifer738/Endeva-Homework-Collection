namespace exercise_06_create_a_list_and_insert_items_to_it
{
    internal class Program
    {
        /*
         6.	Create a List of strings and add five names to it.
        Example:
            List<string> names = new List<string>();
            names.Add("Ani");
            names.Add("Borislav"); // Add more names

         */
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            names.Add("Georgi");
            names.Add("Atanas");
            names.Add("Nikolay");
            names.Add("John");
            names.Add("Konstantin");

            names.ForEach(x => Console.WriteLine(x));
        }
    }
}
