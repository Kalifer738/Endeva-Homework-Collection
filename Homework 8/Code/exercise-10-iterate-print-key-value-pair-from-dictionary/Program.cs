namespace exercise_10_iterate_print_key_value_pair_from_dictionary
{
    internal class Program
    {
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


            foreach (var keyValuePair in countriesAndTheirCapitals)
            {
                Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value}");
            }
        }
    }
}
