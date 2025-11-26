namespace Exercise_7_for_loop_print_names
{
    internal class Program
    {
        //7.	Print names from an array using a foreach loop.
        static void Main(string[] args)
        {
            string[] names =
            {
                "Hades",
                "Persephone",
                "Zagreus",
                "Melinoe",
                "Hecate",
                "Hephaestus",
                "Ares",
                "Charon",
                "Nyx",
                "Hermes",
                "Demeter",
                "Chronos"
            };

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }
        }
    }
}
