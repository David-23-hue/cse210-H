// ScriptureReference.cs
using System;

/// <summary>
/// Represents a scripture reference such as "John 3:16" or "Proverbs 3:5-6"
/// </summary>
public class ScriptureReference
{
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int? _verseEnd; // Nullable for single verses

    /// <summary>
    /// Constructor for a single verse reference (e.g., "John 3:16")
    /// </summary>
    public ScriptureReference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verse;
        _verseEnd = null;
    }

    /// <summary>
    /// Constructor for a verse range reference (e.g., "Proverbs 3:5-6")
    /// </summary>
    public ScriptureReference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }

    /// <summary>
    /// Returns the string representation of the scripture reference
    /// </summary>
    public override string ToString()
    {
        if (_verseEnd.HasValue)
        {
            return $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
        }
        return $"{_book} {_chapter}:{_verseStart}";
    }
}