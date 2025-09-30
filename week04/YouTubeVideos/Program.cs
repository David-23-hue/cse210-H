using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create list of videos
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video();
        video1.SetTitle("How to Train Your Dog in 10 Minutes");
        video1.SetAuthor("PawsitiveTraining");
        video1.SetLengthSeconds(612); // 10 min 12 sec

        video1.AddComment(new Comment("DogLover42", "My pup learned sit in 2 days!"));
        video1.AddComment(new Comment("TrainerTom", "Great tips on positive reinforcement."));
        video1.AddComment(new Comment("Sarah K.", "Could you do a video on leash pulling?"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video();
        video2.SetTitle("Beginner's Guide to Watercolor Painting");
        video2.SetAuthor("ArtWithAnna");
        video2.SetLengthSeconds(1245); // ~20 min

        video2.AddComment(new Comment("CreativeSoul", "Your color blending is magical!"));
        video2.AddComment(new Comment("Mark R.", "What brand of paper do you recommend?"));
        video2.AddComment(new Comment("Lily", "I painted along and it turned out great!"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video();
        video3.SetTitle("Quick Healthy Breakfast Ideas");
        video3.SetAuthor("FitFoodie");
        video3.SetLengthSeconds(487); // ~8 min

        video3.AddComment(new Comment("HealthyMom", "My kids actually ate the smoothie bowl!"));
        video3.AddComment(new Comment("ChefDave", "Oats + chia is a game-changer."));
        video3.AddComment(new Comment("Nina P.", "Please share your grocery list!"));
        videos.Add(video3);

        // Display all videos and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetCommenterName()}: {comment.GetText()}");
            }

            Console.WriteLine(); // Blank line between videos
        }
    }
}