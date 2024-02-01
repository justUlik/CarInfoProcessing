using System.Text.RegularExpressions;

namespace UserInterface;

/// <summary>
/// Reading data from user.
/// </summary>
public static class Read
{
    /// <summary>
    /// Prompts the user to select an option from a given set of options. The options are presented as numbers, 
    /// and the user can select an option by pressing the corresponding number key. The method continues to ask 
    /// for an option until a valid one is selected.
    /// </summary>
    /// <param name="entry">The prompt to display to the user.</param>
    /// <param name="options">The set of options to present to the user.</param>
    /// <param name="cmd">This is an out parameter that will hold the key pressed by the user to select an option.</param>
    /// <exception cref="ArgumentNullException">Thrown if the options array is null or if it contains less than 2 or more
    /// than 10 items.</exception>
    /// <exception cref="ArgumentException">Thrown if the options array contains more than 10 items.</exception>
    public static void ReadOptionAnswer(string entery, string[] options, out ConsoleKey cmd)
    {
        if (options is null)
        {
            throw new ArgumentNullException("Options is null.");
        }
 
        if (options.Length <= 0)
        {
            throw new ArgumentNullException("Options length must be > 1.");
        }
 
        if (options.Length > 10)
        {
            throw new ArgumentException("Options must be 1 < && < 10");
        }
 
        Console.WriteLine(entery);
 
        ConsoleKey[] possible = new ConsoleKey[]
        {
            ConsoleKey.D0, ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4, ConsoleKey.D5, ConsoleKey.D6,
            ConsoleKey.D7, ConsoleKey.D8, ConsoleKey.D9
        };
        Array.Resize(ref possible, options.Length);
        for (int i = 0; i < options.Length; ++i)
        {
            Console.WriteLine($"{i}. {options[i]}");
        }
 
        bool isRead = false;
        do
        {
            cmd = Console.ReadKey().Key;
            bool flag = false;
            foreach (var opt in possible)
            {
                if (cmd == opt)
                {
                    flag = true;
                    break;
                }
            }
 
            if (flag)
            {
                isRead = true;
            }
        } while (!isRead);
    }
    
    /// <summary>
    /// Asks the user to enter a file path, ensuring that the entered path is valid and ends with the .json extension. 
    /// The method continues to ask for a valid file path until one is provided.
    /// </summary>
    /// <returns>The validated file path entered by the user.</returns>
    public static string GetFilePath()
    {
        bool isRead = false;
        string fileName = "";
        Console.WriteLine("Please enter file path. File extension should be json:");
        do
        {
            fileName = Console.ReadLine();
            try
            {
                Regex containsABadCharacter = new Regex("["
                                                        + Regex.Escape(new string(System.IO.Path.GetInvalidPathChars())) + "]");
                if (containsABadCharacter.IsMatch(fileName))
                {
                    isRead = false;
                }
                else
                {
                    bool isCheckedExtension = Path.GetExtension(fileName) == ".json";
                    bool isNullOrEmpty = string.IsNullOrEmpty(Path.GetFileNameWithoutExtension(fileName));
                    bool is0Length = Path.GetFileNameWithoutExtension(fileName).Length == 0;
                    if (!isCheckedExtension || isNullOrEmpty || is0Length)
                    {
                        isRead = false;
                    }
                    else
                    {
                        isRead = true;
                        fileName = Path.GetFullPath(fileName);
                    }
                }
            }
            catch (Exception ex)
            {
                isRead = false;
                Console.WriteLine(ex.Message);
            }
 
            if (!isRead)
            {
                Console.WriteLine("Please try again:");
            }
        } while (!isRead);
 
        return fileName;
    }
}