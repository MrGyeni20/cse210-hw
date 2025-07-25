using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("How to Cook Pasta", "Chef Amy", 420);
        video1.AddComment(new Comment("Tom", "This recipe is awesome!"));
        video1.AddComment(new Comment("Sarah", "Tried it and loved it."));
        video1.AddComment(new Comment("Luke", "Can you do a gluten-free version?"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Top 5 Budget Laptops", "TechWorld", 510);
        video2.AddComment(new Comment("Anna", "Great recommendations!"));
        video2.AddComment(new Comment("Mark", "What about MacBooks?"));
        video2.AddComment(new Comment("Jane", "Thanks for this list."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Python Basics Tutorial", "Code Academy", 890);
        video3.AddComment(new Comment("Charlie", "Very clear explanation."));
        video3.AddComment(new Comment("Laura", "This helped me a lot."));
        video3.AddComment(new Comment("Simon", "Can you do a video on loops?"));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("Morning Yoga Routine", "ZenWithJen", 600);
        video4.AddComment(new Comment("Emily", "I feel so refreshed!"));
        video4.AddComment(new Comment("Ben", "This is my daily go-to."));
        video4.AddComment(new Comment("Rita", "Loved the pace and flow."));
        videos.Add(video4);

        // Display all videos
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
