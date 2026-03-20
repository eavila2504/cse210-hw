using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Scripture Memorization Program");
        Console.WriteLine("===============================\n");
        
        // Let user choose which scripture to memorize
        Scripture scripture = SelectScripture();
        
        Console.Clear();
        Console.WriteLine("Press ENTER to hide random words");
        Console.WriteLine("Type 'quit' to exit");
        Console.WriteLine();
        
        // Main game loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            
            // Check if all words are hidden
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nCongratulations! You have memorized the scripture!");
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
                break;
            }
            
            Console.WriteLine("\nPress ENTER to hide more words, or type 'quit' to exit:");
            
            // Get user input
            string input = Console.ReadLine();
            
            // Check if user wants to quit
            if (input != null && input.ToLower() == "quit")
            {
                Console.WriteLine("\nGoodbye!");
                break;
            }
            
            // Hide 3 random words
            scripture.HideRandomWords(3);
        }
    }
    
    static Scripture SelectScripture()
    {
        Console.WriteLine("Choose a scripture to memorize:\n");
        Console.WriteLine("1. John 3:16");
        Console.WriteLine("2. Proverbs 3:5-6)");
        Console.Write("\nEnter your choice (1 or 2): ");
        
        string choice = Console.ReadLine();
        
        if (choice == "2")
        {
            // Proverbs 3:5-6 in KJV format to match the output
            Reference reference = new Reference("Proverbs", 3, 5, 6);
            string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths.";
            return new Scripture(reference, text);
        }
        else
        {
            // John 3:16
            Reference reference = new Reference("John", 3, 16);
            string text = "For God so loved the world that he gave his one and only Son that whoever believes in him shall not perish but have eternal life";
            return new Scripture(reference, text);
        }
    }
}