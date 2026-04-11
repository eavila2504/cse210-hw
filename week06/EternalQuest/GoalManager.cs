using System;
using System.Collections.Generic;
using System.IO;  
using System.Linq;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        int choice = 0;
        if (choice != 6)
        {
            Console.WriteLine($"\nYou Have {_score} points.\n");
            Console.WriteLine("Menu Options: ");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: 
                    CreateGoal();
                    break;
                case 2:
                    ListGoalDetails();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    Console.WriteLine("Goodbye!");
                    break; 
        
            }

        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou Have {_score} points.\n");
    }   

    public void ListGoalNames()
    {
        Console.WriteLine("\nThe Gaols are:\n");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }

        
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe Gaols are:\n");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        };
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        int type = int.Parse(Console.ReadLine());
        Console.Write("What is the name of your goal? ");

        string name = Console.ReadLine();

        Console.Write("What is the description of your goal?: ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        string points = Console.ReadLine();

        switch (type)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            
            case 2: 
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case 3:
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");

                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
        }
        Console.WriteLine($"Goal '{name}' created successfully!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet. Please create a goal first.");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }

        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];
            
            if (!goal.IsComplete())
            {
                goal.RecordEvent();
                _score += goal.GetPoints();
                Console.WriteLine($"Congratulations! You've earned {goal.GetPoints()} points.");
                
                if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
                {
                    _score += checklistGoal.GetBonus();
                    Console.WriteLine($"Bonus! You earned an additional {checklistGoal.GetBonus()} points");

                }
                DisplayPlayerInfo();
            }
            else
            {
                Console.WriteLine("This goal is already complete. Please select another goal.");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal number. Please try again.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter the filename to save your goals: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine($"Goals saved to {filename}!");
    }

    public void LoadGoals()
    {
        Console.Write("Enter the filename to load your goals: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            _goals.Clear();

            using (StreamReader reader = new StreamReader(filename))
            {
                _score = int.Parse(reader.ReadLine());

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string type = parts[0];
                
                switch (type)
                {
                    case "SimpleGoal":
                        SimpleGoal simple = new SimpleGoal(parts[1], parts[2], parts[3]);
                        if (bool.Parse(parts[4]))
                        {
                            simple.RecordEvent();
                        }
                        _goals.Add(simple);
                        break;

                        case "EternalGoal":
                        _goals.Add(new EternalGoal(parts[1], parts[2], parts[3]));
                        break;

                        case "ChecklistGoal":
                        ChecklistGoal checklist = new ChecklistGoal(parts[1], parts[2], parts[3], int.Parse(parts[5]), int.Parse(parts[4]));
                        for (int i = 0; i < int.Parse(parts[6]); i++)
                            {
                                checklist.RecordEvent();
                            }

                            _goals.Add(checklist);
                            break;
                    }
                }
            }
            Console.WriteLine($"Goals loaded from {filename}!");
        }
        else
        {
            Console.WriteLine("File not found!");
        }
    }
}       
            




