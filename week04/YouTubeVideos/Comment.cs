using System;

public class Comment
{
    private string _commentText;

    private string _commentName;

    public Comment()
    {
        _commentText = "";
        _commentName = "";
    }

    public Comment(string commentText, string commentName)
    {
        _commentText = commentText;
        _commentName = commentName;
    }

    public string displayComment()
    {
        return $"Comment by {_commentName}: \"{_commentText}\"";
    }

}


