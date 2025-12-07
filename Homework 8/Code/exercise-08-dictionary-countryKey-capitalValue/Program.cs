namespace exercise_08_dictionary_countryKey_capitalValue
{
    internal class Program
    {
        /*
         8.	Create a Dictionary with country names as keys and capitals as values.
            Example:
                Dictionary<string, string> capitals = new Dictionary<string, string>();
                capitals["Bulgaria"] = "Sofia"; // Add more entries
         */
        static void Main(string[] args)
        {
            Dictionary<string, string> countriesAndTheirCapitals = new Dictionary<string, string>
            {
                {"Germany", "Berlin"}
            };

            countriesAndTheirCapitals["Bulgaria"] = "Sofia";
            countriesAndTheirCapitals.Add("Romania", "Bucharest");
            countriesAndTheirCapitals.Add("Spain", "Madrid");
            countriesAndTheirCapitals.Add("Austria", "Vienna");
            countriesAndTheirCapitals.Add("United Kingdom", "London");

            countriesAndTheirCapitals.ToList().ForEach(x => Console.WriteLine($"{x.Key}: {x.Value}"));
        }
    }
}
