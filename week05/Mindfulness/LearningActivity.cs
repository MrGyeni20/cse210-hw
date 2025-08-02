using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people you’ve helped this week?",
        "Who are your personal heroes?"
    };

    public ListingActivity() 
        : base("Listing Activity", 
               "This activity helps you reflect on the good things in your life by listing as many as you can in a category.") {}

    public void Run()
    {
        StartActivity();
        Random rand = new Random();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        Console.WriteLine("You may begin in:");
        Countdown(3);

        List<string> responses = new List<string>();
        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            responses.Add(input);
        }

        Console.WriteLine($"You listed {responses.Count} items.");
        EndActivity();
    }

    private void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
