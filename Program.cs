using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    internal interface GamePlay
    {
        void StartGame();
    }

    public class RockPaperScissor : GamePlay
    {
        private string Player;
        private string inputCPU;
        private int randomInt;
        private bool playAgain = true;

        public void StartGame()
        {
            while (this.playAgain)
            {
                int scorePlayer = 0;
                int scoreCPU = 0;

                while (scorePlayer < 3 && scoreCPU < 3)
                {
                    Console.Write("Choose between ROCK, PAPER and SCISSORS:  ");
                    Player = Console.ReadLine();
                    Player = Player.ToUpper();

                    Random rnd = new Random();

                    randomInt = rnd.Next(1, 4);

                    switch (randomInt)
                    {
                        case 1:
                            inputCPU = "ROCK";
                            Console.WriteLine("Computer chose ROCK");
                            if (Player == "ROCK")
                            {
                                Console.WriteLine("DRAW!!\n\n");
                            }
                            else if (Player == "PAPER")
                            {
                                Console.WriteLine("PLAYER WINS!!\n\n");
                                scorePlayer++;
                            }
                            else if (Player == "SCISSORS")
                            {
                                Console.WriteLine("CPU WINS!!\n\n");
                                scoreCPU++;
                            }
                            break;

                        case 2:
                            inputCPU = "PAPER";
                            Console.WriteLine("Computer chose PAPER");
                            if (Player == "PAPER")
                            {
                                Console.WriteLine("DRAW!!\n");
                            }
                            else if (Player == "ROCK")
                            {
                                Console.WriteLine("CPU WINS!!\n");
                                scoreCPU++;
                            }
                            else if (Player == "SCISSORS")
                            {
                                Console.WriteLine("PLAYER WINS!!\n");
                                scorePlayer++;
                            }
                            break;

                        case 3:
                            inputCPU = "SCISSORS";
                            Console.WriteLine("Computer chose SCISSORS");
                            if (Player == "SCISSORS")
                            {
                                Console.WriteLine("DRAW!!\n");
                            }
                            else if (Player == "ROCK")
                            {
                                Console.WriteLine("PLAYER WINS!!\n");
                                scorePlayer++;
                            }
                            else if (Player == "PAPER")
                            {
                                Console.WriteLine("CPU WINS!!\n");
                                scoreCPU++;
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid entry!");
                            break;
                    }

                    Console.WriteLine("\nSCORES:\tPLAYER:\t{0}\tCPU:\t{1}", scorePlayer, scoreCPU);
                }

                if (scorePlayer == 3)
                {
                    Console.WriteLine("Player WON!");
                }
                else if (scoreCPU == 3)
                {
                    Console.WriteLine("CPU WON!");
                }

                Console.WriteLine("Do you want to play again?(y/n)");
                string loop = Console.ReadLine();
                if (loop == "y")
                {
                    playAgain = true;
                    Console.Clear();
                }
                else if (loop == "n")
                {
                    playAgain = false;
                }
                else
                {
                    Console.WriteLine("WRONG INPUT");
                }
            }
        }
    }

    public class GuessTheWord : GamePlay
    {
        private int guess = 0;
        private bool guessedRight = false;

        public void StartGame()
        {
            Random r = new Random();

            int val = r.Next(1, 10);

            Console.WriteLine("I'm thinking of a number between 1 and 10.");

            while (!guessedRight)
            {
                Console.Write("Guess: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("That's not a number.");
                    continue;
                }

                if (guess < val)
                {
                    Console.WriteLine("No, the number is higher than that number.");
                }
                else if (guess > val)
                {
                    Console.WriteLine("No, the number lower than that number.");
                }
                else
                {
                    guessedRight = true;
                    Console.WriteLine("You guessed right!");
                }
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            RockPaperScissor game1 = new RockPaperScissor();
            GuessTheWord game2 = new GuessTheWord();

            Console.WriteLine("Enter the game you want to play \n ");
            Console.WriteLine(" PRESS 1 - RockPaperScissor");
            Console.WriteLine(" PRESS 2 - GuessTheWord");

            int ans = Convert.ToInt32(Console.ReadLine());
            if (ans == 1)
            {
                game1.StartGame();
            }
            else if (ans == 2)
            {
                game2.StartGame();
            }
            else
            {
                Console.WriteLine("Wrong Input");
            }
        }
    }
}