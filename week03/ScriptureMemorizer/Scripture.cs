using System;
using System.Collections.Generic;
public class Scripture
{
    private Reference _reference; 
    private List<Word>_words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>(); 

        string [] wordArray = text.Split('_', StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        } 
    }
    public void HideRandomWords(int numberTodHide)
    {
        int wordCount = 0;
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].isHidden())
            {
                wordCount++;
            }
        }

        int wordsToHide = numberTodHide;
        if (wordsToHide > wordCount)
        {
            wordsToHide = wordCount;
        }
        
        if (wordsToHide > 0)
        {
            Random random = new Random();
            int hidden = 0;

            while (hidden < wordsToHide)
            {
                int randomIndex = random.Next(_words.Count);

                if (!_words[randomIndex].isHidden())
                {   
                    _words[randomIndex].Hide();
                    hidden++;
                }
            }
            
        }
    }
    public string GetDisplayText()
    {
        string scriptureText = "";
        
        for (int i = 0; i < _words.Count; i ++)
        {
            scriptureText += _words[i].GetDisplayText();
            
            if (i < _words.Count - 1)
            {
                scriptureText += "";
            }
        }

        return $"{_reference.GetDisplayText()}\n{scriptureText}";

    }
    public bool IsCompletelyHidden()
    {
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].isHidden())
            {
                return false;
            }
        }
        return true;
    }
}