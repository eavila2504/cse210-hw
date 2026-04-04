using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
        
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("====================");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Quit");
            Console.Write("What would you like to do?  ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    break;

                case "2":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    break;
                
                case "3":
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    break;
                
                case "4":
                    Console.WriteLine("Thank you for using. Have a nice day!");
                    return;
                
                default:
                    Console.WriteLine("\nInvalid choice. Please select a valid option.");
                    Console.ReadKey();
                    break;


            }
        }
    }
}