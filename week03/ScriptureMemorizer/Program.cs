using System;
using System.IO;

// EXCEEDS REQUIREMENTS:
// - Loads the scripture reference and text from an external file ("scripture.txt").
// - This allows users to update or swap scriptures without modifying code.

class Program
{
    static void Main(string[] args)
    {
        // Read scripture from file
        string[] lines = File.ReadAllLines("scripture.txt");

        if (lines.Length < 2)
        {
            Console.WriteLine("Error: scripture.txt must contain at least two lines (reference and text).");
            return;
        }

        // Parse reference
        string referenceLine = lines[0].Trim();
        string textLine = lines[1].Trim();

        Reference reference = ParseReference(referenceLine);
        Scripture scripture = new Scripture(reference, textLine);

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words hidden. Press Enter to exit.");
        Console.ReadLine();
    }

    static Reference ParseReference(string input)
    {
        // Example input: "Proverbs 3:5-6" or "John 3:16"
        string[] parts = input.Split(' ');
        string book = parts[0];
        string[] chapterAndVerse = parts[1].Split(':');

        int chapter = int.Parse(chapterAndVerse[0]);

        if (chapterAndVerse[1].Contains("-"))
        {
            string[] verses = chapterAndVerse[1].Split('-');
            int verse = int.Parse(verses[0]);
            int endVerse = int.Parse(verses[1]);
            return new Reference(book, chapter, verse, endVerse);
        }
        else
        {
            int verse = int.Parse(chapterAndVerse[1]);
            return new Reference(book, chapter, verse);
        }
    }
}
