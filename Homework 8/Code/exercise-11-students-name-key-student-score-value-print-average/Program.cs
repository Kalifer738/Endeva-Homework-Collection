namespace exercise_11_students_name_key_student_score_value_print_average
{
    internal class Program
    {
        /*
        11.	Create a program that stores student names and their scores using a Dictionary, then calculates and prints the average score.
        Example:
	        Dictionary<string, int> studentScores = new Dictionary<string, int>();
            // Add student names and scores
            // Calculate average score from the dictionary

        */
        static void Main(string[] args)
        {
            Dictionary<string, int> studentScores = new Dictionary<string, int>
            {
                {"Georgi", 85},
                {"Atanas", 92},
                {"Nikolay", 78},
                {"John", 95},
                {"Konstantin", 88}
            };

            double averageScore = studentScores.Values.Average(); //I didn't know that there was an average function directly built into the values/keys... until I accidentally discored it today...
            
            //Otherwise I would iterated over it with foreach:
            //averageScore = 0;
            //foreach (var studentScore in studentScores.Values)
            //{
            //    averageScore += studentScore;
            //}
            //averageScore = averageScore / studentScores.Count;

            Console.WriteLine("Student Name: Student Score");
            studentScores.ToList().ForEach(x => Console.WriteLine($"{x.Key}: {x.Value}"));

            Console.WriteLine();
            Console.WriteLine($"Average class score: {averageScore:F2}");
        }
    }
}
