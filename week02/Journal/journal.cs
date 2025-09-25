using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private PromptGenerator _promptGenerator = new PromptGenerator();

    public void AddEntry()
    {
        string prompt = _promptGenerator.GetRandomPrompt();
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Response: ");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        _entries.Add(new Entry(prompt, response, date));
        Console.WriteLine("Entry added!\n");
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nNo entries to display.\n");
            return;
        }

        Console.WriteLine("\n--- JOURNAL ENTRIES ---");
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry);
            Console.WriteLine(new string('-', 40));
        }
    }

    public void SaveToFile(string filename)
    {
        // Create backup if file exists
        if (File.Exists(filename))
        {
            File.Copy(filename, filename + ".bak", true);
            Console.WriteLine($"Backup saved as {filename}.bak");
        }

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine("Date,Prompt,Response");
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(ToCsvLine(entry.Date, entry.Prompt, entry.Response));
            }
        }
        Console.WriteLine($"Journal saved to {filename}\n");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File '{filename}' not found.\n");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        
        // Skip header
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = ParseCsvLine(lines[i]);
            if (parts.Length == 3)
            {
                _entries.Add(new Entry(parts[1], parts[2], parts[0]));
            }
        }
        Console.WriteLine($"Loaded { _entries.Count } entries from {filename}\n");
    }

    // Format a line for CSV (handle special characters)
    private string ToCsvLine(string date, string prompt, string response)
    {
        return $"{EscapeCsvField(date)},{EscapeCsvField(prompt)},{EscapeCsvField(response)}";
    }

    private string EscapeCsvField(string field)
    {
        if (string.IsNullOrEmpty(field))
            return "";

        // Escape double quotes by doubling them
        field = field.Replace("\"", "\"\"");

        // Wrap in quotes if it contains commas, quotes, or newlines
        if (field.Contains(",") || field.Contains("\"") || field.Contains("\n") || field.Contains("\r"))
        {
            field = $"\"{field}\"";
        }
        return field;
    }

    // Parse a single CSV line (handles quoted fields)
    private string[] ParseCsvLine(string line)
    {
        var fields = new List<string>();
        bool inQuotes = false;
        string current = "";

        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == '\"')
            {
                // Look ahead for escaped quote ("")
                if (i + 1 < line.Length && line[i + 1] == '\"')
                {
                    current += '\"';
                    i++; // skip next quote
                }
                else
                {
                    inQuotes = !inQuotes;
                }
            }
            else if (line[i] == ',' && !inQuotes)
            {
                fields.Add(current);
                current = "";
            }
            else
            {
                current += line[i];
            }
        }
        fields.Add(current);
        return fields.ToArray();
    }
}