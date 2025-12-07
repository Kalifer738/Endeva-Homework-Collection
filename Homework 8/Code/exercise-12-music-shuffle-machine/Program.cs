using System.Collections.Generic;

namespace exercise_12_music_shuffle_machine
{
    internal class Program
    {
        /*
        12.	Music Shuffle Machine (List + Algorithms)
        Given a list of songs and lengths for each song name:
        •	Write a method to shuffle the collection (optional use: Fisher-Yates algorithm)
                You can also randomize the list if you don’t use the optional algorithm
        o	The collection contains 2 things, key – name of the song and length in the following format “4:15” - corresponding to 4 minutes and 15 seconds
            •	Write a method to create a playlist of fixed length without repeating songs (argument should be the desired length of the playlist)
        o	The person can ask for a playlist with a length of 40 minutes for instance.
                public List<(string, int)> GetCustomPlaylistByDesiredLenght(int length)
                {
 
                }
        •	Write a method that groups songs by first letter, hint: Dictionary<char, List<string>>

         */

        static Random _randomGenerator = new Random();
        static List<(string, string)> songs = new List<(string, string)>()
        {
            ("Dandelione", "3:22"),
            ("Big Brown Eyes", "3:38"),
            ("Where'd It Go Wrong?", "4:11"),
            ("Feel It (From \"invincible\")", "2:38"),
            ("Oxytocin", "3:30"),
            ("Good Luck, Babe!", "3:38"),
            ("Bad Habits", "3:52"),
            ("its alright :)", "3:22"),
            ("Black Hole Sun", "5:18"),
            ("Bling-Bang-Bang-Born", "2:48"),
            ("Light Switch", "3:08")
        };

        static void Main(string[] args)
        {
            //Print the list of songs and their play time:
            Console.WriteLine("Currently avaialble songs:");
            songs.ForEach(x => Console.WriteLine($"{x.Item1, -27} : {x.Item2}"));
            Console.WriteLine();
            Console.WriteLine();


            //Shuffle the songs and print them:
            Console.WriteLine("A shuffled playlist:");
            var shuffledSongs = ShuffleEnumerable(songs);
            foreach (var song in shuffledSongs)
            {
                Console.WriteLine($"{song.Item1, -27} : {song.Item2}");
            }
            Console.WriteLine();
            Console.WriteLine();


            //Print a list of songs that is of desired play time:
            var tenMinutePlaylist = GetCustomPlaylistByDesiredLenght(10);
            Console.WriteLine("A 10 minute shuffled playlist:");
            tenMinutePlaylist.ForEach(x => Console.WriteLine($"{x.Item1, -27} : {x.Item2}"));
            Console.WriteLine();
            Console.WriteLine();


            //Print all songs, grouped by letter:
            Console.WriteLine("A playlist of all songs grouped by letter:");
            var groupedSongsByLetter = GroupSongsByLetter();
            foreach (var groupOfSongs in groupedSongsByLetter)
            {
                Console.WriteLine($"{groupOfSongs.Key}:");
                groupOfSongs.Value.ForEach(x => Console.WriteLine($"{x.Item1, -27} : {x.Item2}"));
            }


            Console.ReadKey();
        }

        public static SortedDictionary<char, List<(string, string)>> GroupSongsByLetter()
        {
            var groupedSongsByLetter = new SortedDictionary<char, List<(string, string)>>();

            //Checkout every song and group them by letter, adding them to the dictionary above:
            for (int i = 0; i < songs.Count(); i++)
            {
                char currentSongLetter = Char.ToUpper(songs[i].Item1[0]);
                List<(string, string)> ?currentGroupOfSongsByLetter;
                

                //If the current letter is already in the dictionary...
                if (groupedSongsByLetter.TryGetValue(currentSongLetter, out currentGroupOfSongsByLetter))
                {
                    //Add the song to the list
                    currentGroupOfSongsByLetter.Add(songs[i]);
                }
                else
                {
                    //Otherwise create a new list with the song...
                    var newListOfSongsByLetter = new List<(string, string)>
                    {
                        songs[i]
                    };
                    
                    //  and add it to the dictionary...
                    groupedSongsByLetter.Add(currentSongLetter, newListOfSongsByLetter);
                }
            }

            return groupedSongsByLetter;
        }

        public static List<(string, string)> GetCustomPlaylistByDesiredLenght(int lengthMinutes)
        {
            var shuffledCollection = ShuffleEnumerable(songs).ToList();
            float currentPlaylistLengthMinutes = 0;

            for (int i = 0; i < shuffledCollection.Count; i++)
            {
                float currentSongLengthMinutes = SongLengthToSeconds(shuffledCollection[i].Item2) / 60f;
                //Remove songs that will make the playlist length longer than the desired one:
                if (currentPlaylistLengthMinutes + currentSongLengthMinutes > lengthMinutes)
                {
                    shuffledCollection.RemoveAt(i);
                    i--;
                    continue;
                }

                currentPlaylistLengthMinutes += currentSongLengthMinutes;
            }

            return shuffledCollection;
        }

        public static int SongLengthToSeconds(string songLengthString)
        {
            string[] songLengthStrings = songLengthString.Split(':');
            int songLength = 0;
            int parseOutResult;

            //Parsing hours
            if (songLengthStrings.Length > 2 && int.TryParse(songLengthStrings[0], out parseOutResult))
            {
                songLength += parseOutResult * 60 * 60;
            }

            //Parsing minutes
            if (songLengthStrings.Length > 1 && int.TryParse(songLengthStrings[songLengthStrings.Length - 2], out parseOutResult))
            {
                songLength += parseOutResult * 60;
            }

            //Parsing seconds
            if (songLengthStrings.Length > 0 && int.TryParse(songLengthStrings[songLengthStrings.Length - 1], out parseOutResult))
            {
                songLength += parseOutResult;
            }

            return songLength;
        }

        /// <summary>
        /// A shuffle algorithum using the modern version of Fisher and Yates shuffle algorithum: https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
        /// </summary>
        /// <param name="enumerable">A set of objects to shuffle</param>
        /// <returns>Returns a shuffled enumerable object</returns>
        public static IEnumerable<T> ShuffleEnumerable<T>(IEnumerable<T> enumerable)
        {
            var shuffledCollection = enumerable.ToArray();

            /*
             -- To shuffle an array a of n elements (indices 0..n − 1):
            for i from n − 1 down to 1 do
                    j ← random integer such that 0 ≤ j ≤ i
                    exchange a[j] and a[i]
            */

            //Iterate over the whole enumerable from the back, (with each step) generating a random int 'j' that is smaller than 'i' && bigger than -1
            //  Then just swap 'i' and 'j'
            //      This leaves the randomly generated items at the end of the array while we are enumerating it
            for (int i = shuffledCollection.Length - 1; i > 0; i--)
            {
                int j = _randomGenerator.Next(i);

                //Swap i and j
                var tempBucket = shuffledCollection[i];
                shuffledCollection[i] = shuffledCollection[j];
                shuffledCollection[j] = tempBucket;
            }

            return shuffledCollection;
        }

    }
}
