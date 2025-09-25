// Word.cs
using System;

/// <summary>
/// Represents a single word in the scripture that can be hidden or shown
/// </summary>
public class Word
{
    private string _text;
    private bool _isHidden;

    /// <summary>
    /// Creates a new word with the specified text
    /// </summary>
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    /// <summary>
    /// Gets the display text for the word (hidden as underscores if hidden)
    /// </summary>
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        return _text;
    }

    /// <summary>
    /// Gets the hint text for the word (first letter visible, rest as underscores if hidden)
    /// </summary>
    public string GetHintText()
    {
        if (_isHidden)
        {
            if (_text.Length == 1)
                return _text;
            return _text[0] + new string('_', _text.Length - 1);
        }
        return _text;
    }

    /// <summary>
    /// Hides the word by setting it to be displayed as underscores
    /// </summary>
    public void Hide()
    {
        _isHidden = true;
    }

    /// <summary>
    /// Returns whether the word is currently hidden
    /// </summary>
    public bool IsHidden()
    {
        return _isHidden;
    }

    /// <summary>
    /// Returns the original text of the word
    /// </summary>
    public string GetText()
    {
        return _text;
    }
}