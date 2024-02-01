using UserInterface;
using Utility;

/// <summary>
/// The main entry point for the application.
/// </summary>
/// <remarks>
/// This class contains the main method which starts the application. It fetches car data from the user, performs various operations on it based on user input, and writes the result to a file if requested. 
/// Exception handling is implemented to catch any exceptions that occur during the execution of the program and print them to the console. 
/// The program continues to run until the user decides to exit by pressing the backspace key.
/// </remarks>
class Program
{
    static void Main()
    {
        do
        {
            try
            {
                string filePath = "";
                List<CarInfo> carInfos = GetData.JsonDataFromUser(out filePath);
                carInfos = FunctionalityMenu.AskFunctionality(carInfos);
                if (WritingToFile.AskIfWantToWriteToFile())
                {
                    WritingToFile.WritingFunctionality(filePath, carInfos);
                }
            }
            catch (Exception ex)
            {
                Helpers.WriteToConsoleException(ex.Message);
            }
            Console.WriteLine("To have another session press any key, to exit - press backspace.");
        } while (Console.ReadKey().Key != ConsoleKey.Backspace);

    }
}