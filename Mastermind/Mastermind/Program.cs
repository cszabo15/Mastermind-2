using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********Welcome to Mastermind!********");

            string player = GetName();
            int[] correctCombination = GenerateNumberCombination(4);
            
            for(int n = 10; n > 0; n--)
            {
                Console.WriteLine("\nEnter your guess ({0} guesses remaining)", n);
                int[] guessedCombination = getUserNumberCombination(4);
                if(GetResults(correctCombination, guessedCombination))
                {
                    Console.WriteLine("You win, {0}!", player);
                    break;
                }
                else
                {
                    Console.WriteLine("Oh no, {0}! You couldn't guess the right number. Try again.", player);
                }
            }

            Console.Write("Correct Answer was : ");
            for (int j = 0; j < 4; j++)
            {
                Console.Write(correctCombination[j] + " ");
                System.Threading.Thread.Sleep(2000);
            }
            Console.WriteLine();
            Console.Write("Thanks for playing.");
            System.Threading.Thread.Sleep(2000);
        }

        //Method to prompt user to enter their name.
        private static string GetName()
        {
            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Ok, {0}. Let's play.\n", name);

            return name;
        }

        //Method to generate an x-digit random combination of numbers from 1 to 6
        public static int[] GenerateNumberCombination(int Size)
        {
            int randNumber;
            int[] numberCombination = new int[Size];
            Random rngsus = new Random();

            for(int i = 0; i < Size; i++)
            {
                randNumber = rngsus.Next(1, 7);
                numberCombination[i] = randNumber;
            }
            return numberCombination;
        }

        //prompts user for digits, then stores in array
        public static int[] getUserNumberCombination(int Size)
        {
            string input;
            int number;
            int[] playerGuess = new int[Size];

            Console.WriteLine("Enter digits:");
            for (int k = 0; k < Size; k++)
            {
                Console.Write("Digit {0}: ", (k + 1));
                input = Console.ReadLine();
                while (!int.TryParse(input, out number) || number < 1 || number > 6)
                {
                    Console.WriteLine("Invalid. Must be integer between 1 and 6");
                }
                playerGuess[k] = number;
            }

            Console.WriteLine();
            Console.WriteLine("Your Guess is: ");

            for (int l = 0; l < Size; l++)
            {
                Console.Write(playerGuess[l] + " ");
            }
            Console.WriteLine();
            return playerGuess;
        }

        
        //determine if guessed numbers are in correct position - hit
        public static bool GetResults (int[] correct, int[] guessed)
        {
            int numCorrect = 0;
            for (int m = 0; m < correct.Length; m++)
            {
                if (guessed[m] == correct[m])
                {
                    Console.Write("+");
                    numCorrect++;
                }
                else if (correct.Contains(guessed[m]) && guessed[m] != correct[m])
                {
                    Console.Write("-");         
                }
                else
                {
                    Console.Write("_");
                }                       
            }

            if(numCorrect == correct.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

    }
}
