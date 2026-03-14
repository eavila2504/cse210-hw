using System.Collections.Generic;
public class PromptGenerator
{
    public List<String> _prompts = new List<String>()
    {
      "What was the best part of your day?",
      "Who was the most interesting person you talked today?",
      "What will you do better tomorrow?",
      "What did you learn?",
      "What/Who made you smile today?",
    };

    public string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int index = randomGenerator.Next(_prompts.Count);
        return _prompts[index];
    }
}