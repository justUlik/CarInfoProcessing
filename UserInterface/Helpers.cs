namespace UserInterface;
using Utility;

/// <summary>
/// Class that save time for developer not to write the same code lots of time.
/// </summary>
public static class Helpers
{
    /// <summary>
    /// Writes a given message to the console, followed by a message indicating that the current session has ended. 
    /// After a delay of 5 seconds, the console is cleared. If the input message is null or empty, only the ending message
    /// is printed.
    /// </summary>
    /// <param name="message">The message to be written to the console.</param>
    public static void WriteToConsoleException(string message)
    {
        if (!string.IsNullOrEmpty(message))
        {
            Console.WriteLine(message);    
        }
        Console.WriteLine("This session stopped automatically.");
        Thread.Sleep(5000);
        Console.Clear();
    }
    
    /// <summary>
    /// Checks if a given list of CarInfo objects is null or empty. Returns true if the list is null or if it contains
    /// no elements.
    /// </summary>
    /// <param name="array">The list of CarInfo objects to check.</param>
    /// <returns>True if the list is null or empty, false otherwise.</returns>
    public static bool IsNullOrEmpty(List<CarInfo> array)
    {
        return (array is null || (array is not null && array.Count == 0));
    }
}