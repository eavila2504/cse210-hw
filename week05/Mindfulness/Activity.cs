using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description, int seconds)
    {
        _name = name;
        _description = description;
        _duration = seconds;

    }

    public string GetName() => _name;

    public string GetDescription() => _description;

    public int GetDuration() => _duration;

    public void SetDuration(int seconds) => _duration = seconds; 



    public void StartingMessage()
    {   
       
        Console.WriteLine($"Starting {_name}");
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.WriteLine($"How Many Seconds Would You Like For Your Session?");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Get Ready to begin...");
        ShowSpinner(3);
    }

    public void EndingMessage()
    {   
        Console.WriteLine();
        Console.WriteLine("Well Done!");
        ShowSpinner(2);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(3);
        

        
    }

    public void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string> { "|", "/", "-", "\\" };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            i = (i + 1) % spinner.Count;
        }
        
    }

    public void ShowCountdown(int seconds)
    {
      for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.WriteLine("\b \b");
        }  
    }
}