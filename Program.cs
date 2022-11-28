using System;

namespace HW9REVIEW
{
    class Program
    {
        static void Main(string[] args)
        {
            //set up the arrays and pick a random word from wordArray 
            string[] wordArray = new string[10] { "piglet", "wizard", "reality", "shovel", "tickle", "reason", "exotic", "deacon", "easily", "genius" };
            Random myRandomNumber = new Random();
            int wordPicker = myRandomNumber.Next(0, 10);
            string randomWord = wordArray[wordPicker];
            string[] lettersNotFound = new string[20] { " _ ", " _ ", " _ ", " _ ", " _ ",
            " _ ", " _ ", " _ ", " _ ", " _ ",
            " _ ", " _ ", " _ ", " _ ", " _ ",
            " _ ", " _ ", " _ ", " _ ", " _ ",};
            string[] lettersFound = new string[6] { " _ ", " _ ", " _ ", " _ ", " _ ", " _ " };
            //set condition variable for main loop
            bool checkUser = true;
            //set int variables for num of rounds and lettersNotFound
            int count = 0;
            int incorrect = 0; 
            do
            {
                count = count + 1; 
                //Write intro and progress
                Console.WriteLine("Round {0}", count);
                Console.WriteLine("These are the correct letters:");
                Console.WriteLine(string.Join(" ", lettersFound));
                Console.WriteLine("These are the incorrect letters: ");
                Console.WriteLine(string.Join(" ", lettersNotFound));
                //ask user for letter
                Console.WriteLine("Please guess a letter (lowercase please)");
                string userInput = Console.ReadLine();
                //if input matches letter in word (not negative value)
                if (randomWord.IndexOf(userInput) > -1)
                {
                    //write "correct" message
                    Console.WriteLine("Correct! Your letter is in location {0}", randomWord.IndexOf(userInput) + 1);
                    //put the letter in place
                    lettersFound[randomWord.IndexOf(userInput)] = userInput;
                    //write it out
                    Console.WriteLine(string.Join(" ", lettersFound));
                    //ask them to guess word
                    Console.WriteLine("Now, guess the word: ");
                    string userGuess = Console.ReadLine();
                    //if they guess correctly
                    if(randomWord == userGuess)
                    {
                        //write out "congrats"/"closing" message
                        Console.WriteLine("Good job! You guessed the right word! You took {0} tries.", count);
                        Console.WriteLine("Thanks for playing!");
                        //exit loop
                        checkUser = true;
                        Console.ReadLine();//for formatting purposes
                    }
                    //Otherwise
                    else
                    {
                        //have them try again (stay in loop)
                        Console.WriteLine("Sorry, that is not the correct word. Press enter to move on to the next round.");
                        checkUser = false;
                        Console.ReadLine();//format purposes
                    }
                }
                //else:
                else
                {
                    //have them try again (stay in loop)
                    Console.WriteLine("Sorry, this letter is not in this word. Press enter to try again.");
                    //replace a blank with wrong letter
                    lettersNotFound[incorrect] = userInput;
                    incorrect = incorrect + 1;
                    checkUser = false;
                    Console.ReadLine();//format purposes
                }
            } while (checkUser != true);
        }
    }
}
