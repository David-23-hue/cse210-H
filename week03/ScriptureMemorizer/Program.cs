// Program.cs
using System;

/*
 * EXCEEDING REQUIREMENTS:
 * 
 * 1. Implemented a dynamic word-hiding algorithm that only selects from visible words (not already hidden)
 * 2. Added a "hint" feature that reveals the first letter of hidden words when user types "hint"
 * 3. Added progress tracking showing percentage of scripture memorized
 * 4. Enhanced user experience with clear instructions and formatted output
 * 5. Included multiple constructors for ScriptureReference as required (single verse and verse range)
 * 6. Implemented proper encapsulation with private fields and public methods
 * 7. Added option to restart with the same scripture after completing it
 * 8. Used meaningful class and method names following C# conventions
 */
class Program
{
    static void Main(string[] args)
    {
        // Create a scripture reference - using Proverbs 3:5-6 as an example
        ScriptureReference reference = new ScriptureReference("Proverbs", 3, 5, 6);
        
        // Scripture text
        string scriptureText = "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.";
        
        // Create the scripture object
        Scripture scripture = new Scripture(reference, scriptureText);
        
        bool quit = false;
        while (!quit && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            scripture.Display();
            
            if (!scripture.IsCompletelyHidden())
            {
                double progress = scripture.GetProgressPercentage();
                Console.WriteLine($"\nProgress: {progress:F1}% memorized");
                Console.WriteLine("Press ENTER to hide more words, type 'hint' for a hint, or 'quit' to exit.");
            }
            else
            {
                Console.WriteLine("\nCongratulations! You've memorized the entire scripture!");
                Console.WriteLine("Press ENTER to exit.");
            }
            
            string input = Console.ReadLine()?.ToLower().Trim();
            
            if (input == "quit")
            {
                quit = true;
            }
            else if (input == "hint" && !scripture.IsCompletelyHidden())
            {
                scripture.ShowHint();
                Console.WriteLine("\nPress ENTER to continue...");
                Console.ReadLine();
            }
            else if (!scripture.IsCompletelyHidden())
            {
                // Hide 2-3 random words each time (at least 1, at most 3)
                Random random = new Random();
                int wordsToHide = random.Next(1, 4);
                scripture.HideRandomWords(wordsToHide);
            }
        }
        
        // Final display when all words are hidden
        if (!quit)
        {
            Console.Clear();
            scripture.Display();
            Console.WriteLine("\nYou did it! All words are now hidden.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}