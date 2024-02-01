using System.Text;
using Utility;

namespace UserInterface;

/// <summary>
/// The Display class provides functionality for displaying car information in the console.
/// </summary>
public static class Display
{
    /// <summary>
    /// Displays a list of car information in the console. Each piece of information is displayed in a formatted table.
    /// </summary>
    /// <param name="data">The list of car information to display.</param>
    /// <param name="closing">An optional message to display after the list of car information.</param>
    /// <exception cref="ArgumentNullException">Thrown when the data parameter is null or empty.</exception>
    public static void DisplayCarInfo(List<CarInfo> data, string closing="")
    {
        Console.Clear();
        if (Helpers.IsNullOrEmpty(data))
        {
            throw new ArgumentNullException("List is null or empty.");
        }

        const int spaceCarId = 10;
        const int spaceBrand = 20;
        const int spaceModel = 15;
        const int spaceYear = 5;
        const int spacePrice = 10;
        const int spaceIsUsed = 10;
        const int spaceFeatures = 30;

        // could use Array.
        List<string> fieldNames = new List<string>(); 
        fieldNames.Add("car_id");
        fieldNames.Add("brand");
        fieldNames.Add("model");
        fieldNames.Add("year");
        fieldNames.Add("price");
        fieldNames.Add("is_used");
        fieldNames.Add("features");

        Console.WriteLine($"{fieldNames[0],spaceCarId} | {fieldNames[1],spaceBrand} | {fieldNames[2],spaceModel} | " +
                          $"{fieldNames[3],spaceYear} | {fieldNames[4],spacePrice} | {fieldNames[5],spaceIsUsed} | " +
                          $"{fieldNames[6],spaceFeatures} |");

        try
        {
            // could use for.
            foreach (var carInfo in data)
            {
                string features = string.Join(", ", carInfo.Features);
                Console.WriteLine($"{CutString(carInfo.CarId.ToString(), spaceCarId),spaceCarId} | " +
                                  $"{CutString(carInfo.Brand, spaceBrand),spaceBrand} | " +
                                  $"{CutString(carInfo.Model, spaceModel),spaceModel} | " +
                                  $"{CutString(carInfo.Year.ToString(), spaceYear),spaceYear} | " +
                                  $"{CutString(carInfo.Price.ToString(), spacePrice),spacePrice} | " +
                                  $"{CutString(carInfo.IsUsed.ToString(), spaceIsUsed),spaceIsUsed} | " +
                                  $"{CutString(features, spaceFeatures),spaceFeatures} |");

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        if (!string.IsNullOrEmpty(closing))
        {
            Console.WriteLine(closing);
        }
        
        Console.WriteLine("\nPress Q to close data view:");
        bool isRead = false;
        do
        {
            var cmd = Console.ReadKey().Key;
            if (cmd == ConsoleKey.Q)
            {
                isRead = true;
            }
        } while (!isRead);
    }
    
    /// <summary>
    /// Trims a string to fit within a specified size. If the string is longer than the specified size, it is cut off
    /// and '...' is appended to the end.
    /// </summary>
    /// <param name="str">The string to trim.</param>
    /// <param name="sz">The maximum size of the string.</param>
    /// <returns>The trimmed string.</returns>
    /// <exception cref="Exception">Thrown when an exception occurs during the trimming process.</exception>
    private static string CutString(string str, int sz)
    {
        if (string.IsNullOrEmpty(str) || str.Length == 0)
        {
            return "";
        }

        if (sz <= 0)
        {
            return "";
        }

        try
        {
            if (sz > str.Length)
            {
                return str;
            }

            StringBuilder result = new StringBuilder();
            sz -= 3;
            for (int i = 0; i < Math.Min(sz, str.Length); ++i)
            {
                result.Append(str[i]);
            }

            result.Append("...");
            return result.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}