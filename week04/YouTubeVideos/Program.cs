using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();
        
        Video video1 = new Video("C# Programming of Beginners!", "I Teacher", 900);
        video1.AddComment(new Comment("Great tutorial, I love it", "Josh345"));
        video1.AddComment(new Comment("The explanation was incredible!", "Alma3738"));
        video1.AddComment(new Comment("This video was bored", "The_bestenginner1"));
        videos.Add(video1);
        //Create video 2

        Video video2 = new Video("The most common mistakes into programming", "John Developer", 700);
        video2.AddComment(new Comment("It wil help me to improve my skills", "jonah123"));
        video2.AddComment(new Comment("I never realized, I have done all of this" ,"pandagamer_1"));
        video2.AddComment(new Comment("Thankyou for the video" , "nephi231"));
        videos.Add(video2);

        Video video3 = new Video("Top 3 biggest animal in the world", "Animal Planet", 600);
        video3.AddComment(new Comment("I never expected!", "mickey"));
        video3.AddComment(new Comment("My favorite animal is the top 1" , "expeditionfree"));
        video3.AddComment(new Comment("My favorite channel!" , "eavila2504"));
        videos.Add(video3);



        //Display videos 
        Console.WriteLine("Youtube Video Tracker!");

        foreach (Video video in videos)
        {
            video.DisplayAll();
        }

        Console.WriteLine("\n\nSUMMARY STATISTICS");
        Console.WriteLine($"Total Videos: {videos.Count}");

        int totalComments = 0;
        foreach (Video video in videos)
        {
            totalComments += video.GetNumberOfComments();
        }
        Console.WriteLine($"Total Comments: {totalComments}");
    }
}