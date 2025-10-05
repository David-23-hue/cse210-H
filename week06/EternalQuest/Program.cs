/*
 * EXCEEDING REQUIREMENTS:
 * 
 * This program goes beyond the base requirements by implementing:
 * 
 * 1. A LEVELING SYSTEM: Every 1,000 points increases the user's level.
 * 2. BADGES: When the user levels up, they earn a badge (e.g., "Level 2 Achiever").
 * 3. ENHANCED USER EXPERIENCE: 
 *    - Emoji and celebratory messages make the quest feel engaging.
 *    - Clear feedback on points, bonuses, and progress.
 *    - Badges are saved and loaded with the user profile.
 * 
 * These gamification elements help motivate users to continue working on their eternal goals,
 * aligning with the spiritual purpose of the program while adding fun and personalization.
 */

public class Program
{
    public static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}