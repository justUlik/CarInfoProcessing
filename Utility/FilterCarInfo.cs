namespace Utility;

/// <summary>
/// A utility class for filtering lists of CarInfo objects based on certain criteria.
/// </summary>
public static class FilterCarInfo
{
    /// <summary>
    /// Filters a list of CarInfo objects based on a specific field and value.
    /// </summary>
    /// <param name="field">The field to filter on. Can be "car_id", "brand", "model", "year", "price", "is_used", or
    /// "features".</param>
    /// <param name="uniqueValue">The value to filter for.</param>
    /// <param name="carInfos">The list of CarInfo objects to filter.</param>
    /// <returns>A list of CarInfo objects that match the specified field and value.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the input parameters are null or empty, or if the carInfos
    /// list is null or empty.</exception>
    /// <exception cref="FormatException">Thrown if the field does not correspond to a valid CarInfo property.</exception>
    public static List<CarInfo> FilterByField(string field, string uniqueValue, List<CarInfo> carInfos)
    {
        try
        {
            if (string.IsNullOrEmpty(field) || string.IsNullOrEmpty(uniqueValue) || carInfos is null || 
                (carInfos is not null && carInfos.Count == 0))
            {
                throw new ArgumentNullException("Given value is null");
            }
            List<CarInfo> filteredData = new List<CarInfo>();
        
            foreach (var carInfo in carInfos)
            {
                switch (field)
                {
                    case "car_id":
                        if (carInfo.CarId.ToString() == uniqueValue)
                        {
                            filteredData.Add(carInfo);
                        }

                        break;
                    case "brand":
                        if (carInfo.Brand == uniqueValue)
                        {
                            filteredData.Add(carInfo);
                        }

                        break;
                    case "model":
                        if (carInfo.Model == uniqueValue)
                        {
                            filteredData.Add(carInfo);
                        }

                        break;
                    case "year":
                        if (carInfo.Year.ToString() == uniqueValue)
                        {
                            filteredData.Add(carInfo);
                        }

                        break;
                    case "price":
                        if (carInfo.Price.ToString() == uniqueValue)
                        {
                            filteredData.Add(carInfo);
                        }

                        break;
                    case "is_used":
                        if (carInfo.IsUsed.ToString() == uniqueValue)
                        {
                            filteredData.Add(carInfo);
                        }

                        break;
                    case "features":
                        if (string.Join(", ", carInfo.Features) == uniqueValue)
                        {
                            filteredData.Add(carInfo);
                        }

                        break;
                    default:
                        throw new FormatException("No such field.");
                }
            }

            return filteredData;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}