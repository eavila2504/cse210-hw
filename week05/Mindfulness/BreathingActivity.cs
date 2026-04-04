using System;
using System.Collections.Generic;
using System.Threading;

public class BreathingActivity : Activity
{
   public BreathingActivity() : base("Breathing Activity", "This activity will help you relax and focus on your breathing." , 0)
    {     
    }

    public void Run()
    {
        StartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("\n Breathe in...");
            ShowCountdown(4);

            if (DateTime.Now >= endTime) break;

            Console.WriteLine("\n Breathe out...");
            ShowCountdown(6);
        }

        EndingMessage();
        
    }
}