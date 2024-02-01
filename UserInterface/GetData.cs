using Utility;

namespace UserInterface;

/// <summary>
/// Implements connection with user to get dataset.
/// </summary>
public static class GetData
{
    /// <summary>
    /// This method prompts the user to select a method for reading JSON data. 
    /// If the user chooses to read from a file, the method will keep asking for a valid file path until one is provided. 
    /// If the user chooses to enter data manually, the method will instruct them to enter data in JSON format. 
    /// Once the data has been entered or read from a file, the method will parse the JSON data into a list of CarInfo objects. 
    /// If an exception occurs during parsing, the method will rethrow the exception.
    /// </summary>
    /// <param name="filePath">This is an out parameter that will hold the path to the file from which JSON data is read.</param>
    /// <returns>A list of CarInfo objects parsed from the JSON data.</returns>
    /// <exception cref="Exception">Thrown if an exception occurs during parsing of the JSON data.</exception>
    public static List<CarInfo> JsonDataFromUser(out string filePath)
    {
        filePath = "";
        Console.Clear();
        ConsoleKey cmd;
        Read.ReadOptionAnswer("Enter way for reading data:", 
                                new string[] {"Put JSON to Console", "Enter filepath to read JSON from file"}, 
                                out cmd);
        
        if (cmd == ConsoleKey.D1)
        {
            Console.Clear();
            bool isRead = false;
            do
            {
                try
                {
                    filePath = Read.GetFilePath();
                    StreamReader sr = new StreamReader(filePath);
                    Console.SetIn(sr);
                    isRead = true;
                }
                catch (Exception ex)
                {
                    isRead = false;
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Try again:");
                }
            } while (!isRead);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Enter data in JSON format. End of input is empty line");
        }

        try
        {
            List<CarInfo> records = JsonParser.ReadJson();
            return records;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            try
            {
                Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}