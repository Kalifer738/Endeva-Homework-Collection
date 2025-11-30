namespace ConsoleApp1
{
    internal class Program
    {
        /*
            #8 Bonus exercise: Create a mini battle game using methods to organize the logic.
            Create three methods:
            1.	RollDice()
                a.	Returns a random number from 1 to 6.
            
            2.	BattleRound(playerRoll, enemyRoll)
                a.	Takes two numbers.
                b.	Prints who wins the round: 
                i.	Higher roll → winner
                ii.	Same roll → “It's a tie!”
            
            3.	AnnounceWinner(playerScore, enemyScore)
                a.	At the end of the game, announce who won overall.

            Game Flow:
            •	The player and the enemy each roll dice 5 times. If a total number of even results are present – declare a tie.
            •	Use your methods to handle rolls, rounds, and winner announcement.

            Add BDD tests for the last task
        */

        static readonly Random diceGenerator = new Random();

        static void Main(string[] args)
        {
            int playerScore = 0;
            int enemyScore = 0;

            //Game loops consists of 5 rounds:
            for (int i = 0; i < 5; i++)
            {
                int playerRoll;
                int enemyRoll;

                //Player rolling dice:
                {
                    Console.WriteLine("Its your turn! Press any key to roll the dice.");
                    Console.ReadKey(true);

                    playerRoll = RollDice();
                    playerScore += playerRoll;
                    Console.Write("Rolling dice");
                    Thread.Sleep(9 * playerRoll * 10);
                    Console.Write(".");
                    Thread.Sleep(11 * playerRoll * 10);
                    Console.Write(".");
                    Thread.Sleep(12 * playerRoll * 10);
                    Console.WriteLine(".");

                    Console.WriteLine($"You rolled {playerRoll}");
                }

                //Enemy rolling dice:
                {
                    Console.WriteLine("Enemy is rolling the Dice: ");
                    Console.ReadKey(true);

                    enemyRoll = RollDice();
                    enemyScore += enemyRoll;
                    Console.WriteLine("Rolling dice");
                    Thread.Sleep(5 * enemyRoll * 10);
                    Console.Write(".");
                    Thread.Sleep(12 * enemyRoll * 10);
                    Console.Write(".");
                    Thread.Sleep(9 * enemyRoll * 10);
                    Console.WriteLine(".");

                    Console.WriteLine($"Enemy rolled {enemyRoll}");
                }

                Console.WriteLine();
                Console.WriteLine();

                Thread.Sleep(3 * (enemyRoll / playerRoll) * 10);
                BattleRound(playerRoll, enemyRoll);

                if(i == 3)
                {
                    Console.WriteLine($"Press any key to advance to your last round!");
                }
                else
                {
                    Console.WriteLine($"Press any key to advance to round {i + 1}");
                }
                Console.ReadKey(true);

                Console.WriteLine();
                Console.WriteLine();
            }

            AnnounceWinner(playerScore, enemyScore);
        }

        static int RollDice()
        {
            return diceGenerator.Next(1, 6);
        }

        static void BattleRound(int playerRoll, int enemyRoll)
        {
            if(playerRoll > enemyRoll)
            {
                Console.WriteLine("Player wins round.");
            }
            else if (playerRoll < enemyRoll)
            {
                Console.WriteLine("Enemy wins round.");
            }
            else
            {
                Console.WriteLine("Its a tie!");
            }
        }

        static void AnnounceWinner(int playerScore, int enemyScore)
        {
            if (playerScore > enemyScore)
            {
                Console.WriteLine("Player wins game.");
            }
            else if (playerScore < enemyScore)
            {
                Console.WriteLine("Enemy wins game.");
            }
            else
            {
                Console.WriteLine("Game is a draw.");
            }
        }
    }
}
