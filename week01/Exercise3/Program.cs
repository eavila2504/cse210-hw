using System;

class Program
{
    static void Main(string[] args)
    {
        string restart = "yes";

        while (restart == "yes")
        {
            Random random = new Random();
            int unknownNumber = random.Next(1, 101);
            int guess = -1;

            while (guess != unknownNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                if (guess < unknownNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > unknownNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            Console.Write("Play again? (yes/no): ");
            restart = Console.ReadLine();
        }
    }
}
