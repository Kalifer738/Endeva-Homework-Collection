namespace homework_6_find_biggest_element_in_array_implement_sort_with_it
{
    internal class Program
    {
        //6.	Write a method that finds the biggest element of an array.
        //      Use that method to implement sorting in descending order.
        static void Main(string[] args)
        {
            int[] myArray =
            {
                1,
                10,
                -10,
                -321,
                521,
                7,
                0
            };

            foreach (var number in myArray)
            {
                Console.Write($"{number} ");
            }

            int[] mySortedArray = new int[myArray.Length];
            for (int i = 0; i < myArray.Length; i++)
            {
                //Get the biggest number position from the array
                int biggestIntPos = FindPositionOfBiggestNumberInArray(myArray);

                //Add it into the sorted array
                mySortedArray[i] = myArray[biggestIntPos];
                
                //On the old array, set the found number to the minimum integer value so it can be ignored
                myArray[biggestIntPos] = int.MinValue;
            }

            Console.WriteLine();
            foreach (var number in mySortedArray)
            {
                Console.Write($"{number} ");
            }
        }


        //Method that returns the biggest number in an array,
        //  I could use this method to solve the exercise but then I would have to create a blacklist array, which holds the positions of numbers to ignore in the array.
        static int FindBiggestNumberInArray(int[] array)
        {
            if (array.Length == 0)
            {
                return 0;
            }
            int biggestInt = array[0];

            foreach (var number in array)
            {
                if(biggestInt < number)
                {
                    biggestInt = number;
                }
            }

            return biggestInt;
        }

        //Method that returns the position of the biggest number in an array.
        static int FindPositionOfBiggestNumberInArray(int[] array)
        {
            if (array.Length == 0)
            {
                return -1;
            }

            int biggestIntPos = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if(array[biggestIntPos] < array[i])
                {
                    biggestIntPos = i;
                }
            }

            return biggestIntPos;
        }
    }
}
