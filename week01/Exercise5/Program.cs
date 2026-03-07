using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        DisplayMessage();

        string UserName = PromptUserName();
        int UserNumber = PromptUserNumber();
        int SquaredNumber = SquareNumber(UserNumber);
        DisplayResult(UserName, SquaredNumber);

    }
        static void DisplayMessage()
        {
            Console.WriteLine("Welcome to the program!"); 
        }

        static string PromptUserName()
    {
        Console.Write("Please Enter your full name: ");
        string name = Console.ReadLine();
        return name;
    }

        static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int FavoriteNumber = int.Parse(Console.ReadLine());
        
        return FavoriteNumber;
    }

        static int SquareNumber(int FavoriteNumber)
    {
        int Square = FavoriteNumber*FavoriteNumber;

        return Square;
    }
    
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name} the square of your number is {square}");
    }
}
