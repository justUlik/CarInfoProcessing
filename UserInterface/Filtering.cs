using Utility;

namespace UserInterface;


/// <summary>
/// Class implements connection with user to filter the data.
/// </summary>
public static class Filtering
{
    /// <summary>
    /// Prompts the user to enter a field name from a predefined list. Continues asking until a valid field name is entered.
    /// </summary>
    /// <returns>The selected field name.</returns>
    public static string GetFieldName()
    {
        List<string> fieldNames = new List<string>();
        fieldNames.Add("car_id");
        fieldNames.Add("brand");
        fieldNames.Add("model");
        fieldNames.Add("year");
        fieldNames.Add("price");
        fieldNames.Add("is_used");
        fieldNames.Add("features");
        Console.Clear();
        Console.WriteLine("Type value of field to make operation by");

        foreach (var fieldName in fieldNames)
        {
            Console.WriteLine(fieldName);
        }
        
        bool isRead = false;
        string answer = "";
        // could use while ().
        do
        { 
            answer = Console.ReadLine();
            try
            {
                if (!fieldNames.Contains(answer))
                {
                    Console.WriteLine("No such field. Try again:");
                }
                else
                {
                    isRead = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } while (!isRead);

        return answer;
    }

    /// <summary>
    /// Iterates through a list of CarInfo objects and adds the corresponding field value to a new list. Returns a list
    /// of unique values for the specified field.
    /// </summary>
    /// <param name="field">The field name.</param>
    /// <param name="carInfos">The list of CarInfo objects.</param>
    /// <returns>A list of unique values for the specified field.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the provided field name or list of CarInfo objects is null or
    /// empty.</exception>
    /// <exception cref="FormatException">Thrown when the provided field name doesn't match any existing fields.</exception>
    public static List<string> GetValues(string field, List<CarInfo> carInfos)
    {
        if (string.IsNullOrEmpty(field))
        {
            throw new ArgumentNullException("Given value is null");
        }

        if (Helpers.IsNullOrEmpty(carInfos))
        {
            throw new ArgumentNullException("Given value is null");
        }
        
        List<string> uniqueValuesByField = new List<string>();
        try
        {
            foreach (var carInfo in carInfos)
            {
                switch (field)
                {
                    case "car_id":
                        uniqueValuesByField.Add(carInfo.CarId.ToString());
                        break;
                    case "brand":
                        uniqueValuesByField.Add(carInfo.Brand);
                        break;
                    case "model":
                        uniqueValuesByField.Add(carInfo.Model);
                        break;
                    case "price":
                        uniqueValuesByField.Add(carInfo.Price.ToString());
                        break;
                    case "year":
                        uniqueValuesByField.Add(carInfo.Year.ToString());
                        break;
                    case "is_used":
                        uniqueValuesByField.Add(carInfo.IsUsed.ToString());
                        break;
                    case "features":
                        uniqueValuesByField.Add(string.Join(", ", carInfo.Features));
                        break;
                    default:
                        throw new FormatException("No such field.");
                }
            }

            return uniqueValuesByField.Distinct().ToList();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Prompts the user to enter a value from a list of unique values. Continues asking until a valid value is entered.
    /// </summary>
    /// <param name="uniqueValues">The list of unique values.</param>
    /// <returns>The selected value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the provided list of unique values is null or empty.</exception>
    public static string GetUniqueValue(List<string> uniqueValues)
    {
        if (uniqueValues is null || (uniqueValues is not null && uniqueValues.Count == 0))
        {
            throw new ArgumentNullException("List is null or empty");
        }
        
        Console.Clear();
        Console.WriteLine("Type value of field to make operation by:");

        try
        {
            foreach (var value in uniqueValues)
            {
                Console.WriteLine(value);
            }

            bool isRead = false;
            string answer = "";
            do
            {
                answer = Console.ReadLine();
                try
                {
                    if (!uniqueValues.Contains(answer))
                    {
                        Console.WriteLine("No such field. Try again:");
                    }
                    else
                    {
                        isRead = true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            } while (!isRead);

            return answer;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
