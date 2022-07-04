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
            
            List<String> correctGuesses = new List<String>();
            List<String> wrongGuesses = new List<String>();
            int maxChances = 10;
            for (int guessAttempt = 1; guessAttempt <= maxChances; guessAttempt++) 
            {
                Console.Write("\r\nChance "+ guessAttempt + "/"+ maxChances + ", Guess a letter: ");
                String input = Console.ReadLine();

                if (input == null || "".Equals(input.Trim())) {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }

                if (correctGuesses.Contains(input) || wrongGuesses.Contains(input))
                {
                    Console.WriteLine("You guessed this letter before. Try another one!");
                    guessAttempt--; // don't count this duplicate letter
                    continue; // don't do anything and just loop again
                }

                // if user guessed the whole word in one go, set the falg to true and skip the loop
                if (secretWord.Equals(input))
                {
                    userWon = true;
                    break;
                }

                
                if (secretWord.Contains(input)) 
                {
                    // count the guess as correct only if it's one character
                    if (input.Length == 1)
                    {
                        correctGuesses.Add(input);
                    }
                    else
                    {
                        // if it's multiple characters, then it's not a correct guess even if it's part of the secret word
                        wrongGuesses.Add(input);
                    }
                }
                else
                {
                    wrongGuesses.Add(input);
                }

                // show incorrect guessed letters so far
                Console.WriteLine("Wrong guesses so far: " + string.Join(',', wrongGuesses.ToArray()));

                // Solution #2
                // process the guesses and keep the results as a word. 
                foreach (String guess in correctGuesses)
                {
                    char guessedChar = guess.ElementAt(0);
                    int i = 0;
                    foreach (char secretLetter in secretWord)
                    {
                        
                        if (secretLetter == guessedChar)
                        {
                            
                            secretWordArray[i] = secretLetter;
                        }
                        
                        i++;
                    }
                }

                // present the word 
                Console.Write("Word: ");
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
                Console.WriteLine("\r\nSorry! You did not win. The correct word is: \r\n"+secretWord);
            }

        }
    }
}
      

                       
    


