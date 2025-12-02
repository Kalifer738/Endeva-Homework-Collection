using System.Text;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace exercise_bonus_11_spy_code_generator
{
    internal class Program
    {
        /*
        Write a method CreateCodeName(string firstName, string lastName).
        
        Rules:
        1.	Take the first 2 letters of the first name.
        2.	Change the position of the 2 letters (the second becomes first and vice versa), example ‘ab’->’ba’
        3.	Take the last 3 letters of the last name.
        4.	Change the positions of the first and third letter, example: “sad” -> “das”.
        5.	Concatenate both results from 2. and 4.
        6.	Convert the result to uppercase.
        7.	Bonus** Shift each letter 3 letters to the right, example:
            “ANI” -> “DQL” 
            if it happens that the letter is X, Y or Z -> start from the beginning of the alphabet
            “ZORO” -> “CRUR”

        */
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine() ?? "";
            string lastName = Console.ReadLine() ?? "";

            Console.WriteLine(CreateCodeName(firstName, lastName));
            Console.WriteLine(CreateCodeNameLessCode(firstName, lastName));
        }

        static string CreateCodeName(string firstName, string lastName)
        {
            /*
            1.	Take the first 2 letters of the first name.
            2.	Change the position of the 2 letters (the second becomes first and vice versa), example ‘ab’->’ba’
            3.	Take the last 3 letters of the last name.
            4.	Change the positions of the first and third letter, example: “sad” -> “das”.
            5.	Concatenate both results from 2. and 4.
            6.	Convert the result to uppercase.
            7.	Bonus** Shift each letter 3 letters to the right, example:
                “ANI” -> “DQL” 
                if it happens that the letter is X, Y or Z -> start from the beginning of the alphabet
                “ZORO” -> “CRUR

            Example:
            #Konstantin @Kostadinov ->
            1.	Ko
            2.  oK
            3.  oKnov
            4.  nKoov
            5.  oKnKoov
            6.  OKNKOOV
            7.  RNQNRRY

            1. #1 #2
            2. #2 #1
            3. #2 #1 @-2 @-1 @-0
            4. @-2 #1 #2 @-1 @-0
            5. #2 #1 @-2 #1 #2 @-1 @-0
            6. Uppercase
            7. Shift the letter
            */

            if (firstName.Length < 2)
            {
                //1.	Take the first 2 letters of the first name
                return "First name is too short";
            }
            if(lastName.Length < 3)
            {
                //3.	Take the last 3 letters of the last name.
                return "Last name is too short";
            }
            StringBuilder codeNameBuilder = new StringBuilder(7);
            char tempSwap = default;

            //1.Take the first 2 letters of the first name.
            codeNameBuilder.Append(firstName[0]);
            codeNameBuilder.Append(firstName[1]);

            //2.	Change the position of the 2 letters (the second becomes first and vice versa), example ‘ab’->’ba’
            tempSwap = codeNameBuilder[0];
            codeNameBuilder[0] = codeNameBuilder[1];
            codeNameBuilder[1] = tempSwap;
            string step5String1 = codeNameBuilder.ToString();

            //3.	Take the last 3 letters of the last name.
            codeNameBuilder.Append(lastName[lastName.Length - 3]);
            codeNameBuilder.Append(lastName[lastName.Length - 2]);
            codeNameBuilder.Append(lastName[lastName.Length - 1]);

            //4.	Change the positions of the first and third letter, example: “sad” -> “das”.
            tempSwap = codeNameBuilder[0];
            codeNameBuilder[0] = codeNameBuilder[2];
            codeNameBuilder[2] = tempSwap;

            //5.	Concatenate both results from 2. and 4.
            //sb.Append(step5String1 + sb.ToString());
            //From this I understand to clear the stringBuilder, and to just save these whats inside of the append in the line above ^
            string step5String2 = codeNameBuilder.ToString();
            codeNameBuilder.Clear();
            codeNameBuilder.Append(step5String1 + step5String2);


            //6.	Convert the result to uppercase.
            for (int i = 0; i < codeNameBuilder.Length; i++)
            {
                codeNameBuilder[i] = Char.ToUpper(codeNameBuilder[i]);
            }

            //7.Bonus * *Shift each letter 3 letters to the right, example:
            //    “ANI” -> “DQL” 
            //    if it happens that the letter is X, Y or Z->start from the beginning of the alphabet
            //    “ZORO” -> “CRUR
            for (int i = 0; i < codeNameBuilder.Length; i++)
            {
                //If the current letter is X, Y or Z:
                if ((int)codeNameBuilder[i] >= (int)'X')
                {
                    //Then increment by 3, and remove the index of A in order to start from the beggining of the alphabet:
                    codeNameBuilder[i] = (char)((int)codeNameBuilder[i] + 3 - (int)'A');
                }
                else //Otherwise
                {
                    //Just increment the current letter by 3:
                    codeNameBuilder[i] = (char)((int)codeNameBuilder[i] + 3);
                }
            }


            return codeNameBuilder.ToString();

        }

        static string CreateCodeNameLessCode(string firstName, string lastName)
        {
            //Technically this is not as optimized as it can be but it skips some redundant steps, but it makes it harder to read.
            /*
            Steps:
                1.	Take the first 2 letters of the first name.
                2.	Change the position of the 2 letters (the second becomes first and vice versa), example ‘ab’->’ba’
                3.	Take the last 3 letters of the last name.
                4.	Change the positions of the first and third letter, example: “sad” -> “das”.
                5.	Concatenate both results from 2. and 4.
                6.	Convert the result to uppercase.
                7.	Bonus** Shift each letter 3 letters to the right, example:
                    “ANI” -> “DQL” 
                    if it happens that the letter is X, Y or Z -> start from the beginning of the alphabet
                    “ZORO” -> “CRUR

            The numbers represet the position of the string, meanwhile '@' is the first name and '#' is the second name.
            Example:
                #Konstantin @Kostadinov ->
                Step 1: #1 #2                    Ko
                Step 2: #2 #1                    oK
                Step 3: #2 #1 @-2 @-1 @-0        oKnov
                Step 4: @-2 #1 #2 @-1 @-0        nKoov
                Step 5: #2 #1 @-2 #1 #2 @-1 @-0  oKnKoov
                Step 6: Uppercase                OKNKOOV
                Step 7: Shift the letter         RNQNRRY

            */

            if (firstName.Length < 2)
            {
                //1.	Take the first 2 letters of the first name
                return "First name is too short";
            }
            if (lastName.Length < 3)
            {
                //3.	Take the last 3 letters of the last name.
                return "Last name is too short";
            }

            /*
            #Konstantin# @Kostadinov@ ->
            1.Ko
            2.oK
            3.oKnov
            4.nKoov
            5.oKnKoov
            ----------------------
            1. #1 #2
            2. #2 #1
            3. #2 #1 @-2 @-1 @-0
            4. @-2 #1 #2 @-1 @-0
            5. #2 #1 @-2 #1 #2 @-1 @-0
            */
            StringBuilder codeNameBuilder = new StringBuilder();
            codeNameBuilder.Append(firstName[1]);
            codeNameBuilder.Append(firstName[0]);
            codeNameBuilder.Append(lastName[lastName.Length - 3]);
            codeNameBuilder.Append(firstName[0]);
            codeNameBuilder.Append(firstName[1]);
            codeNameBuilder.Append(lastName[lastName.Length - 2]);
            codeNameBuilder.Append(lastName[lastName.Length - 1]);

            //6.Uppercase
            //6.OKNKOOV
            for (int i = 0; i < codeNameBuilder.Length; i++)
            {
                codeNameBuilder[i] = Char.ToUpper(codeNameBuilder[i]);
            }

            //7.Shift the letter
            //7.RNQNRRY
            for (int i = 0; i < codeNameBuilder.Length; i++)
            {
                //If the current letter is X, Y or Z:
                if ((int)codeNameBuilder[i] >= (int)'X')
                {
                    //Then increment by 3, and remove the index of A in order to start from the beggining of the alphabet:
                    codeNameBuilder[i] = (char)((int)codeNameBuilder[i] + 3 - (int)'A');
                }
                else //Otherwise
                {
                    //Just increment the current letter by 3:
                    codeNameBuilder[i] = (char)((int)codeNameBuilder[i] + 3);
                }
            }

            return codeNameBuilder.ToString();
        }
    }
}
