using System;

namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till NumberGame - Spelet där du ska gissa vilket nummer jag tänker på");
            Console.WriteLine("Välj en svårighetsnivå:");
            Console.WriteLine("1. Lätt (1-10)");
            Console.WriteLine("2. Medium (1-50)");
            Console.WriteLine("3. Svår (1-100)");
            Console.WriteLine("För att göra det ännu svårare så får du endast 5 försök på dig");

            int maxNumber;                                 //maximal number of what the user can guess
            int maxAttempts = 5;                           //this means that the user only gets 5 guesses
            int attempts = 0;                              //number of gusses the user has made
            bool rightGuess = false;                       //bolean variabel that is true if the user guesses the right number

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    maxNumber = 10;
                    break;
                case 2:
                    maxNumber = 50;                        // The users choices of difficulty levels in a switch statement.
                    break;
                case 3:                                    // And a default choice if the user types somthing else than 1,2 or 3.
                    maxNumber = 100;
                    break;
                default:
                    Console.WriteLine("Ogiltigt val. Jag väljer nu svårighetsgrad medium åt dig");
                    maxNumber = 50;
                    break;
            }

            Random random = new Random();                    //this class randomly choose a number between 1 and maxNumber.
            int number = random.Next(1, maxNumber + 1);

            Console.WriteLine($"Jag tänker på ett nummer mellan 1-{maxNumber}");

            rightGuess = playGame(maxNumber, maxAttempts, number, out attempts);

            if (!rightGuess)
            {
                Console.WriteLine($"Tyvärr så klarade du inte att gissa rätt på {maxAttempts} försök :( Rätt svar var: {number}");
                //If-statement that runs when the user has gusseed wrong more than 5 times. it also says what number it was thinking of.
            }

            Console.WriteLine("Tack för att du spelat NumbersGame!"); //This always runs in the end of the code.


            static bool playGame(int maxNumber, int maxAttempts, int number, out int attempts) // bolean function
            {
                attempts = 0;
                bool rightGuess = false;

                while (!rightGuess && attempts < maxAttempts)
                {
                    Console.WriteLine("Vilket nummer tänker jag på?");   // a while-loop that runs until the user guesses right 
                    string guess = Console.ReadLine();                   // or if the maximum number of gusses has been reached

                    if (int.TryParse(guess, out int userGuess))          //the user is asked to enter their guess. If the user enters an integer (through int.TryParse), numberOfTries is incremented by 1.
                    {
                        attempts++;

                        if (userGuess == number)
                        {
                            Console.WriteLine($"Grattis! Du gissade rätt nummer på {attempts} försök.");
                            rightGuess = true;                            // if-statement that runs if the user guessed right.
                        }

                        else if (userGuess < number)
                        {
                            Console.WriteLine("Du har gissat för lågt");   //else if-statement that runs if the user guessed a too low number
                        }
                        else
                        {
                            Console.WriteLine("Du har gissat för högt");  //else statement that runs if the user guessed a too high number
                        }
                    }

                    else
                    {
                        Console.WriteLine($"Fel! Du måste skriva ett nummer mellan 1-{maxNumber}. Försök igen"); // this runs if the user gusses a number
                    }

                    
                }

                return rightGuess;
                                                                                 

            }

        }       
    }
}
    
