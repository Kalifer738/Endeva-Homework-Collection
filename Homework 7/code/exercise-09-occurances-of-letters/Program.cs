namespace exercise_09_occurances_of_letters
{
    internal class Program
    {
        //9.	Create a method that returns the count of occurrence of each letter present in a sentence (case insensitive, A == a).
        static void Main(string[] args)
        {
            string sentence = "I’m doing my best to learn C#";
            Dictionary<char, int> charactersAndTheirOccurances = new Dictionary<char, int>();

            for (int i = 0; i < sentence.Length; i++)
            {
                char charToCheck = Char.ToLower(sentence[i]);

                //We're only checking letters not symbols:
                if (!Char.IsAsciiLetter(charToCheck))
                    continue;

                //Add in the new character to the set, if it doesn't exist...
                if (!charactersAndTheirOccurances.TryAdd(charToCheck, 1))
                {
                    //Otherwise, increment the count if we already saw this character.
                    charactersAndTheirOccurances[charToCheck]++;
                }
            }

            foreach (var keyAndValue in charactersAndTheirOccurances)
            {
                Console.WriteLine($"'{keyAndValue.Key}' has occurred {keyAndValue.Value} times");
            }
        }
    }
}
