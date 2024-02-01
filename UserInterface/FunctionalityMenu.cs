using Utility;

namespace UserInterface;

/// <summary>
/// Implements connection with user to make all operations with data.
/// </summary>
public static class FunctionalityMenu
{
    /// <summary>
    /// Interactively prompts the user to choose between filtering or sorting data based on certain fields.
    /// Filters or sorts the data accordingly and displays the result. Continues until the user chooses to stop operations.
    /// </summary>
    /// <param name="carInfos">The list of CarInfo objects to filter or sort.</param>
    /// <returns>The filtered or sorted list of CarInfo objects.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the provided list of CarInfo objects is null.</exception>
    public static List<CarInfo> AskFunctionality(List<CarInfo> carInfos)
    {
        if (carInfos is null)
        {
            throw new ArgumentNullException("List is null.");
        }

        try
        {
            ConsoleKey cmd = ConsoleKey.A;
            while (cmd != ConsoleKey.D2)
            {
                Read.ReadOptionAnswer("Choose one option:",
                    new[] { "Filter data by one of the fields", "Sort data by one of the fields", "Stop doing operations" },
                    out cmd);
                if (cmd == ConsoleKey.D0)
                {
                    string field = Filtering.GetFieldName();
                    List<string> uniqueValues = Filtering.GetValues(field, carInfos);
                    string uniqueValue = Filtering.GetUniqueValue(uniqueValues);

                    carInfos = FilterCarInfo.FilterByField(field, uniqueValue, carInfos);
                    Display.DisplayCarInfo(carInfos, closing:$"Filtered by field: {field} and value : {uniqueValue}");
                } else if (cmd == ConsoleKey.D1)
                {
                    string field = Filtering.GetFieldName();
                    ConsoleKey sortCmd;
                    Read.ReadOptionAnswer("Choose one option:", new[] {"Sort ascending", "Sort descending"}, out sortCmd);
                    bool ascending = false;
                    if (sortCmd == ConsoleKey.D0)
                    {
                        Sorting.CallingSoring(ref carInfos, true, field);
                        ascending = true;
                    } else if (sortCmd == ConsoleKey.D1)
                    {
                        Sorting.CallingSoring(ref carInfos, false, field);
                    }
                    string strAscending = ascending ? "ascending" : "descending";
                    Display.DisplayCarInfo(carInfos, $"Sorted {strAscending} by field {field}");
                }
                else
                {
                    break;
                }
            }

            return carInfos;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
