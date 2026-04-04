using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
  private int _count;
  private List<string> _prompts = new List<string>
  {
    "Who are people that you appreciate?",
    "What are personal strengths of yours?",
    "Who are people that you have helped this week?",
    "When have you felt the Holy Ghost this month?",
    "Who are some of your personal heroes?"
  };

    public int Count { get => _count; set => _count = value; }

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good thing in your life by having you list as many things as you can in a certain area.", 0)
  {
    
  }

  public void Run()
  {
    StartingMessage();
    Console.WriteLine("\n List as many responses as you can to the following prompt: ");
    Console.WriteLine($"---{GetRandomPrompt()}---");
    Console.WriteLine("\nYou may Begin in: ");
    ShowCountdown(5);
    Console.WriteLine();

    DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
    List<string> userList = GetListFromUser(endTime);
    Console.WriteLine($"\nYou listed {userList.Count} items!");

    EndingMessage();

  }
  
  private string GetRandomPrompt()
  {
    Random random = new Random();
    return _prompts[random.Next(_prompts.Count)];
  }

  private List<string> GetListFromUser(DateTime endTime)
  {
    List<string> responses = new List<string>();

    while (DateTime.Now < endTime)
    {
        Console.Write("> ");
        string response = Console.ReadLine();
        if (!string.IsNullOrEmpty(response))
        {
            responses.Add(response);
        }
    }

    return responses;
  }
}