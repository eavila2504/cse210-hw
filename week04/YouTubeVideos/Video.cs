using System;
public class Video
{
    private string _title;

    private string _author;
    private int _length;
    private List<string> _comments;

    public Video()
    {
        _title = "";

        _author = "";

        _length = 0;

        _comments = new List<string>();
    }

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<string>();
    }

    public string displayVideo()
    {
        return $"{_title}\nAuthor: {_author}\nLength: {_length} seconds";
    }

    public int GetNumberOfComments()
    {
        return _comments.Count();

    }
}