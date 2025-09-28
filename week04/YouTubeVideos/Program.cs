// Program.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create list of videos
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video
        {
            Title = "How to Bake a Perfect Chocolate Cake",
            Author = "BakingWithJoy",
            LengthSeconds = 420 // 7 minutes
        };
        video1.AddComment(new Comment("Alice", "This recipe changed my life!"));
        video1.AddComment(new Comment("Bob", "Could you share the oven temp again?"));
        video1.AddComment(new Comment("Carol", "Made it for my daughter's birthday—huge hit!"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video
        {
            Title = "Top 10 Programming Tips for Beginners",
            Author = "CodeMaster99",
            LengthSeconds = 845 // ~14 minutes
        };
        video2.AddComment(new Comment("DevNewbie", "Tip #3 saved me hours of debugging!"));
        video2.AddComment(new Comment("Sarah", "Please do a follow-up on OOP!"));
        video2.AddComment(new Comment("Mike", "Your explanations are so clear."));
        video2.AddComment(new Comment("Lena", "Subscribed!"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video
        {
            Title = "Morning Yoga Flow for Energy",
            Author = "ZenWithZoe",
            LengthSeconds = 1200 // 20 minutes
        };
        video3.AddComment(new Comment("YogaFan", "I do this every morning now!"));
        video3.AddComment(new Comment("Tom", "My back pain improved in a week."));
        video3.AddComment(new Comment("Nina", "Love your calm voice 🙏"));
        videos.Add(video3);

        // Display all videos and their comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine(); // Blank line between videos
        }
    }
}