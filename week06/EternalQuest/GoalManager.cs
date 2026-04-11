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
        while (choice != 6)
        {
            Console.WriteLine($"\nYou have {_score} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine();

            // Check if input is valid
            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
                continue;
            }

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
                default:
                    Console.WriteLine("Invalid choice. Please select 1-6.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score} points");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        Console.WriteLine("\nGoal Names:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals created yet. Please create a goal first.");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        int type;
        if (!int.TryParse(Console.ReadLine(), out type) || type < 1 || type > 3)
        {
            Console.WriteLine("Invalid goal type. Please select 1, 2, or 3.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is the description of your goal?: ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points;
        if (!int.TryParse(Console.ReadLine(), out points))
        {
            Console.WriteLine("Invalid points value.");
            return;
        }

        switch (type)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, description, points.ToString()));
                break;
            case 2:
                _goals.Add(new EternalGoal(name, description, points.ToString()));
                break;
            case 3:
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target;
                if (!int.TryParse(Console.ReadLine(), out target))
                {
                    Console.WriteLine("Invalid target value.");
                    return;
                }

                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus;
                if (!int.TryParse(Console.ReadLine(), out bonus))
                {
                    Console.WriteLine("Invalid bonus value.");
                    return;
                }

                _goals.Add(new ChecklistGoal(name, description, points.ToString(), target, bonus));
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
        int index;
        if (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > _goals.Count)
        {
            Console.WriteLine("Invalid goal number!");
            return;
        }

        index--; // Convert to zero-based index
        Goal goal = _goals[index];

        if (!goal.IsComplete())
        {
            goal.RecordEvent();
            _score += goal.GetPoints();
            Console.WriteLine($"\nCongratulations! You earned {goal.GetPoints()} points!");

            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                _score += checklistGoal.GetBonus();
                Console.WriteLine($"Bonus! You earned an additional {checklistGoal.GetBonus()} points!");
            }

            DisplayPlayerInfo();
        }
        else
        {
            Console.WriteLine("\nThis goal is already complete!");
        }
    }

    public void SaveGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to save. Create some goals first.");
            return;
        }

        Console.Write("Enter filename to save (e.g., goals.txt): ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine($"Goals saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load (e.g., goals.txt): ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found!");
            return;
        }

        try
        {
            _goals.Clear();

            using (StreamReader reader = new StreamReader(filename))
            {
                string scoreLine = reader.ReadLine();
                if (scoreLine != null)
                {
                    _score = int.Parse(scoreLine);
                }

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length < 2) continue;

                    string type = parts[0];

                    switch (type)
                    {
                        case "SimpleGoal":
                            if (parts.Length >= 5)
                            {
                                SimpleGoal simple = new SimpleGoal(parts[1], parts[2], parts[3]);
                                if (bool.Parse(parts[4]))
                                {
                                    simple.RecordEvent();
                                }
                                _goals.Add(simple);
                            }
                            break;
                        case "EternalGoal":
                            if (parts.Length >= 4)
                            {
                                _goals.Add(new EternalGoal(parts[1], parts[2], parts[3]));
                            }
                            break;
                        case "ChecklistGoal":
                            if (parts.Length >= 7)
                            {
                                ChecklistGoal checklist = new ChecklistGoal(parts[1], parts[2], parts[3], int.Parse(parts[5]), int.Parse(parts[4]));
                                int completed = int.Parse(parts[6]);
                                for (int i = 0; i < completed; i++)
                                {
                                    checklist.RecordEvent();
                                }
                                _goals.Add(checklist);
                            }
                            break;
                    }
                }
            }

            Console.WriteLine($"Goals loaded from {filename}");
            DisplayPlayerInfo();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
            _goals.Clear(); // Clear any partially loaded goals
            _score = 0;
        }
    }
}