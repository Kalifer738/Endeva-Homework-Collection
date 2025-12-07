namespace exercise_09_access_dictionary_by_key
{
    internal class Program
    {
        /*
         9.	Access a value from the Dictionary using a key.
            Example:
	            string capital = capitals["Bulgaria"];
                // Print capital
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

            string bulgariaCapital = countriesAndTheirCapitals["Bulgaria"];
            Console.WriteLine(bulgariaCapital);
        }
    }
}
