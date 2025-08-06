using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        List<Goal> goals = new List<Goal>();
        int score = 0;

        while (true)
        {
            Console.WriteLine("\nEternal Quest Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Show Score and Level");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("0. Quit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(goals);
                    break;
                case "2":
                    ListGoals(goals);
                    break;
                case "3":
                    RecordEvent(goals, ref score);
                    break;
                case "4":
                    ShowScoreAndLevel(score);
                    break;
                case "5":
                    SaveToFile(goals, score);
                    break;
                case "6":
                    (goals, score) = LoadFromFile();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void CreateGoal(List<Goal> goals)
    {
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        string type = Console.ReadLine();
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid type.");
                break;
        }
    }

    static void ListGoals(List<Goal> goals)
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()} {goals[i].Name} ({goals[i].Description})");
        }
    }

    static void RecordEvent(List<Goal> goals, ref int score)
    {
        ListGoals(goals);
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < goals.Count)
        {
            int earned = goals[index].RecordEvent();
            score += earned;
            Console.WriteLine($"Points earned: {earned}");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    static void ShowScoreAndLevel(int score)
    {
        int level = score / 1000;
        Console.WriteLine($"\nYour score: {score}");
        Console.WriteLine($"Your level: {level} - {GetLevelTitle(level)}");
    }

    static string GetLevelTitle(int level)
    {
        string[] titles = { "Beginner", "Disciple", "Scripture Ninja", "Temple Knight", "Celestial Sage" };
        return level < titles.Length ? titles[level] : "Eternal Champion";
    }

    static void SaveToFile(List<Goal> goals, int score)
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(score);
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    static (List<Goal>, int) LoadFromFile()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        List<Goal> goals = new List<Goal>();
        int score = 0;

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split("|");
                string type = parts[0];
                switch (type)
                {
                    case "SimpleGoal":
                        goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                        break;
                    case "EternalGoal":
                        goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;
                    case "ChecklistGoal":
                        goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[6]), int.Parse(parts[5])));
                        break;
                }
            }

            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }

        return (goals, score);
    }
}

// EXCEEDS REQUIREMENTS:
// - Added a Leveling System: Every 1000 points gives 1 level.
// - Displays level and a custom title (e.g., “Scripture Ninja”, “Celestial Sage”).
