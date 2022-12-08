//4- Write a program that picks a random number between 1 and 10.
//Give the user 4 chances to guess the number. If the user guesses the number,
//display “You won"; otherwise, display “You lost".
//(To make sure the program is behaving correctly,
//you can display the secret number on the console first.)


Random random = new Random();
int winningNumber = random.Next(1, 10);
int chancesToGuess = 4;
while (chancesToGuess != 0)
{
    Console.WriteLine("Enter your Guess Between 1 to 10");
    int userGuess = Convert.ToInt32(Console.ReadLine());
    if (userGuess == winningNumber)
    {
        Console.WriteLine("Congratulations You Won...");
        break;
    }
    else
    {
        chancesToGuess--;
    }
}
if (chancesToGuess == 0)
{
    Console.WriteLine("Sorry you Lost...");
    Console.WriteLine($"Winning number is {winningNumber}");
}