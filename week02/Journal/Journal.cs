using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }

    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }
        Console.WriteLine("Journal Save succesfully.\n");
    }

    public void LoadFromFile(string file)
    {
        if (File.Exists(file))
        {
            string[] lines = File.ReadAllLines(file);

            _entries.Clear();

            foreach (string line in lines)
            {
                string[] parts = line.Split("|");

                Entry entry = new Entry();
                entry._date = parts[0];
                entry._entryText = parts[1];
                entry._promptText = parts[2];

                _entries.Add(entry);
            }
        }
        else
        {
            Console.WriteLine("File not found please save the Journal first.\n");
        }
    }
}