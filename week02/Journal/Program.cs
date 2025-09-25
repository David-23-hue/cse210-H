/*
 * EXCEEDING REQUIREMENTS:
 * 
 * 1. FULL CSV COMPLIANCE:
 *    - All entries are saved in a standards-compliant CSV format (RFC 4180).
 *    - Fields containing commas, quotes, or newlines are properly wrapped in double quotes.
 *    - Internal double quotes are escaped by doubling them (e.g., "He said ""Hi"""").
 *    - Includes a header row for clarity.
 *    - Custom CSV parser correctly reads quoted fields, so journal files open perfectly in Excel, Google Sheets, or any CSV viewer.
 * 
 * 2. AUTO-BACKUP PROTECTION:
 *    - Before overwriting an existing journal file, the program creates a backup with a ".bak" extension.
 *    - Prevents accidental data loss if the user saves over an important journal.
 * 
 * These features significantly improve real-world usability:
 * - Users can analyze their journal trends in spreadsheet software.
 * - Data integrity is maintained through safe file operations.
 * - The journal becomes a long-term, reliable record.
 */
using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    Console.Write("What is the filename? ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;
                case "4":
                    Console.Write("What is the filename? ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;
                case "5":
                    quit = true;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select 1-5.\n");
                    break;
            }
        }
    }
}