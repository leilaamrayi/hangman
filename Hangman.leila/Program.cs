using System;
using System.Text;
using static System.Random;
using System.Collections.Generic;
namespace hangManGame
{
    public class Program
    {

        public static void Main(String[] args)
        {
            bool userWon = false;
            char dash = '-';
            Console.WriteLine("Welcome to game!");
            List<string> secretWordList = new List<string> { "sun", "goal", "weather", "health", "happiness", "hi" };
            
            Random random = new Random();
            int index = random.Next(secretWordList.Count - 1);
            String secretWord = secretWordList[index];
            Char[] secretWordArray = new Char[secretWord.Length];
            for (int i = 0; i < secretWord.Length; i++) 
            { 
                secretWordArray[i] = dash;
            }
            //Console.WriteLine("secretWord is " + secretWord);
            foreach (char letter in secretWord)
            {
                Console.Write(dash+" ");
            }
            
            List<char> correctGuessedLetters = new List<char>();
            List<char> wrongGuessedLetters = new List<char>();
            int maxChances = 10;
            for (int guessAttempt = 1; guessAttempt <= maxChances; guessAttempt++) 
            {
                Console.Write("\r\nChance "+ guessAttempt + "/"+ maxChances + ", Guess a letter: ");
                Char input = Console.ReadLine().ElementAt(0);

                if (correctGuessedLetters.Contains(input) || wrongGuessedLetters.Contains(input))
                {
                    Console.WriteLine("You guessed this letter before. Try another one!");
                    guessAttempt--; // don't count this duplicate letter
                    continue; // don't do anything and just loop again
                }

                if (secretWord.Contains(input)) 
                {
                    correctGuessedLetters.Add(input);
                }
                else
                {
                    wrongGuessedLetters.Add(input);
                }

                // show incorrect guessed letters so far
                Console.WriteLine("Wrong guesses so far: " + string.Join(',', wrongGuessedLetters.ToArray()));

                // Solution #1
                // process the guesses and keep the results as a word. 
                /*foreach (char guessedLetter in correctGuessedLetters)
                {
                    int idx = 0;
                    while (true) {
                        idx = secretWord.IndexOf(guessedLetter, idx);
                        if (idx == -1) {
                            break;
                        }
                        secretWordArray[idx] = guessedLetter;
                        idx++;
                    }
                }*/

                // Solution #2
                // process the guesses and keep the results as a word. 
                foreach (char guessedLetter in correctGuessedLetters)
                {
                    int i = 0;
                    foreach (char secretLetter in secretWord)
                    {
                        
                        if (secretLetter == guessedLetter)
                        {
                            
                            secretWordArray[i] = secretLetter;
                        }
                        
                        i++;
                    }
                }

                // present the word 
                Console.Write("Secret word: ");
                foreach (char ch in secretWordArray)
                {
                    Console.Write(ch + " ");
                }
                Console.WriteLine("");

                // if no dash is left in the word, it mean all letters are revealed and user wins
                if (!secretWordArray.Contains(dash)) 
                {
                    userWon = true;
                    break;
                }

            }

            if (userWon)
            {
                Console.WriteLine("\r\nCongrats! You Won!");
            }
            else
            {
                Console.WriteLine("\r\nSorry! Game over!");
            }

        }
    }
}
      

                       
    


