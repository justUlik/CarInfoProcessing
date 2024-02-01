using Utility;

namespace UserInterface;

/// <summary>
/// User connection to write for file.
/// </summary>
public static class WritingToFile
{
    /// <summary>
    /// Prompts the user to decide whether they want to write the produced data to a JSON file. 
    /// Returns true if the user chooses to write to a file, false otherwise.
    /// </summary>
    /// <returns>True if the user chooses to write to a file, false otherwise.</returns>
    public static bool AskIfWantToWriteToFile()
    {
        ConsoleKey want;
        Read.ReadOptionAnswer("Do you want to write the produced data to json file?", new []{"Yes", "No"}, out want);
        return want == ConsoleKey.D0;
    }

    /// <summary>
    /// Writes a list of CarInfo objects to a JSON file. The user is asked if they want to save to the provided file
    /// path or another file. 
    /// If the list is null or empty, an ArgumentNullException is thrown.
    /// </summary>
    /// <param name="inputFilePath">The initial file path to consider for saving the data.</param>
    /// <param name="carInfos">The list of CarInfo objects to write to the file.</param>
    /// <exception cref="ArgumentNullException">Thrown if the list is null or empty.</exception>
    public static void WritingFunctionality(string inputFilePath, List<CarInfo> carInfos)
    {
        if (Helpers.IsNullOrEmpty(carInfos))
        {
            throw new ArgumentNullException(nameof(carInfos));
        }

        try
        {
            string data = Converting.CarInfoToJson(carInfos);
            ConsoleKey cmd = ConsoleKey.A;
            if (!string.IsNullOrEmpty(inputFilePath))
            {
                Read.ReadOptionAnswer("Choose option:", new []{$"Save to {inputFilePath}", "Save to another file"}, out cmd);
                
            }

            string filePath;
            if (cmd == ConsoleKey.D1 || cmd == ConsoleKey.A)
            {
                Console.Clear();
                filePath = Read.GetFilePath();
                Console.Clear();    
            }
            else
            {
                filePath = inputFilePath;
            }

            JsonParser.WriteJson(data, filePath);
            Console.WriteLine("Data successful was written.");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}