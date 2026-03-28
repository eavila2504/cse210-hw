using System;
public class Video
{
    private string _title;

    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video()
    {
        _title = "";

        _author = "";

        _length = 0;

        _comments = new List<Comment>();
    }

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public string displayVideo()
    {
        return $"{_title}\nAuthor: {_author}\nLength: {_length} seconds";
    }

    public int GetNumberOfComments()
    {
        return _comments.Count();

    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public void DisplayAll()
    {
        //display video information 
        Console.WriteLine($"{_title}");
        Console.WriteLine($"{_author}");
        Console.WriteLine($"{_length} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        Console.WriteLine($"\nComments");

        if (_comments.Count > 0)
        {
            foreach (Comment comment in _comments)
            {
                Console.WriteLine(comment.displayComment());
            }
        }

        else
        {
            Console.WriteLine("No comments Yet.");
        }
        Console.WriteLine();
    }
}