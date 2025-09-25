// Scripture.cs
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents a scripture with its reference and text, managing the hiding of words
/// </summary>
public class Scripture
{
    private ScriptureReference _reference;
    private List<Word> _words;
    private Random _random;

    /// <summary>
    /// Creates a new scripture with the given reference and text
    /// </summary>
    public Scripture(ScriptureReference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(word => new Word(word))
                    .ToList();
        _random = new Random();
    }

    /// <summary>
    /// Displays the scripture reference and text with appropriate words hidden
    /// </summary>
    public void Display()
    {
        Console.WriteLine(_reference.ToString());
        Console.WriteLine();
        Console.WriteLine(string.Join(" ", _words.Select(w => w.GetDisplayText())));
    }

    /// <summary>
    /// Shows a hint version of the scripture with first letters of hidden words visible
    /// </summary>
    public void ShowHint()
    {
        Console.Clear();
        Console.WriteLine(_reference.ToString());
        Console.WriteLine();
        Console.WriteLine(string.Join(" ", _words.Select(w => w.GetHintText())));
    }

    /// <summary>
    /// Hides the specified number of random words that are not already hidden
    /// </summary>
    public void HideRandomWords(int count)
    {
        // Get indices of words that are not yet hidden
        List<int> visibleIndices = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                visibleIndices.Add(i);
            }
        }
        
        // If there are no visible words, return
        if (visibleIndices.Count == 0)
            return;
        
        // Hide up to 'count' words, but not more than available
        int wordsToHide = Math.Min(count, visibleIndices.Count);
        for (int i = 0; i < wordsToHide; i++)
        {
            // Select a random index from visible indices
            int randomIndex = _random.Next(visibleIndices.Count);
            int wordIndex = visibleIndices[randomIndex];
            
            // Hide the word
            _words[wordIndex].Hide();
            
            // Remove the index from visible indices so we don't select it again in this call
            visibleIndices.RemoveAt(randomIndex);
        }
    }

    /// <summary>
    /// Returns true if all words in the scripture are hidden
    /// </summary>
    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    /// <summary>
    /// Returns the percentage of words that have been hidden (memorized)
    /// </summary>
    public double GetProgressPercentage()
    {
        if (_words.Count == 0)
            return 100.0;
            
        int hiddenCount = _words.Count(word => word.IsHidden());
        return (double)(hiddenCount * 100) / _words.Count;
    }
}