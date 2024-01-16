using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabAssignment_03
{
    internal class LabClass
    {
        string[] fruitsArray = { "apple", "mango", "banana", "orange", "grapes", "pineapple", "strawberry", "cherry",
            "watermelon", "kiwi", "blueberry", "peach", "pear", "plum", "raspberry", "avocado","papaya", "canteloupe",
            "guava", "persimmon" };

        /// <summary>
        /// This method generates a random number and uses that random number to generate a random fruit out of the fruitsArray.
        /// </summary>
        /// <returns></returns>
        public string RandomWord()
        {
            try
            {
                // Creating a random index using Random class. The Next method will generate the number upto the specified range.
                Random random = new Random();
                int randomIndex = random.Next(fruitsArray.Length);

                string randomFruitWord = fruitsArray[randomIndex];

                // StringBuilder randomFruitBuilder = new StringBuilder(randomFruit);
                return randomFruitWord;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This method returns a string builder for the random fruit word and it contains underscores instead of letters
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public StringBuilder DisplayHiddenString(string str)
        {
            try
            {
                StringBuilder hiddenString = new StringBuilder();

                for (int i = 0; i < str.Length; i++)
                {
                    hiddenString.Append('_');
                }

                return hiddenString;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This method takes the user input by calling above methods and checks if the random fruit word contains the input
        /// letter. It also calls the validation method to validate the input. This method also contains the game logic for
        /// ending the game.
        /// </summary>
        public void GuessTheLetter()
        {
            try
            {
                string randomFruit = RandomWord();
                StringBuilder hiddenWord = DisplayHiddenString(randomFruit);

                bool isTrue = true;
                int maxCorrectGuesses = 10;

                Console.WriteLine("Welcome to the Fruit Guessing Game!");
                Console.WriteLine();

                while (isTrue)
                {
                    Console.WriteLine(hiddenWord);
                    Console.WriteLine();

                    Console.WriteLine($"Enter a letter to guess the fruit. You have {maxCorrectGuesses} guesses.");
                    string userInput = Console.ReadLine().ToLower();

                    // Validate the user input
                    if (!ValidateUserInput(userInput) && maxCorrectGuesses > 0)
                    {
                        maxCorrectGuesses--;
                        continue;
                    }

                    char userLetter = Convert.ToChar(userInput);

                    Console.WriteLine();

                    bool isIncorrect = true;

                    // Check if the guessed letter is in the random word
                    for (int i = 0; i < randomFruit.Length; i++)
                    {
                        if (userLetter == randomFruit[i])
                        {
                            // Update the random word with the correctly guessed letter
                            hiddenWord[i] = randomFruit[i];
                            isIncorrect = false;
                        }

                    }

                    if (isIncorrect && maxCorrectGuesses > 0) maxCorrectGuesses--;

                    // Implementing game over logic
                    if (hiddenWord.ToString() == randomFruit)
                    {
                        Console.WriteLine("Game Over!");
                        Console.WriteLine("You guessed the correct fruit: {0}", randomFruit);
                        isTrue = false;
                    }

                    if (maxCorrectGuesses == 0)
                    {
                        Console.WriteLine("Game Over!");
                        Console.WriteLine("You reached the maximum number of incorrect guesses. The correct fruit was: {0}", randomFruit);
                        isTrue = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
        }

        /// <summary>
        /// This method checks whether the user input is not char or if the length of the input is not one and prints the
        /// appropriate message for the user.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool ValidateUserInput(string input)
        {
            try
            {
                if (!char.IsLetter(input[0]) || input.Length != 1)
                {
                    Console.WriteLine("Invalid input! Please enter one letter.");
                    return false;
                }

                // If user input is valid, return true
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
