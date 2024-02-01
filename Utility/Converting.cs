using System.Text;

namespace Utility;

/// <summary>
/// A utility class for converting data between JSON and CarInfo objects.
/// </summary>
public static class Converting
{
    /// <summary>
    /// Converts a list of records from JSON format to CarInfo objects.
    /// </summary>
    /// <param name="records">The list of records to convert.</param>
    /// <returns>A list of CarInfo objects representing the converted records.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the input list is null or empty.</exception>
    public static List<CarInfo> JsonToCarInfo(List<List<List<string>>> records)
    {
        if (records is null)
        {
            throw new ArgumentNullException("Records is null.");
        }

        if (records is not null && !records.Any())
        {
            throw new ArgumentNullException("Records is empty.");
        }

        try
        {
            List<CarInfo> carInfos = new List<CarInfo>();

            foreach (var record in records)
            {
                if (record is null)
                {
                    throw new ArgumentNullException("Record is null");
                }
                Validate.ValidateRecord(record);
                List<String> elems = record[6].GetRange(1, record[6].Count() - 1);
                elems.Sort();
                CarInfo carInfo = new CarInfo(ulong.Parse(record[0][1]),
                    record[1][1],
                    record[2][1],
                    ulong.Parse(record[3][1]),
                    double.Parse(record[4][1].Replace('.', ',')),
                    bool.Parse(record[5][1]),
                    elems);
                carInfos.Add(carInfo);
            }

            return carInfos;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    /// <summary>
    /// Converts a list of CarInfo objects to JSON format.
    /// </summary>
    /// <param name="carInfoList">The list of CarInfo objects to convert.</param>
    /// <returns>A JSON string representing the converted CarInfo objects.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the input list is null.</exception>
    public static string CarInfoToJson(List<CarInfo> carInfoList)
    {
        if (carInfoList is null)
        {
            throw new ArgumentNullException(nameof(carInfoList), "Given value is null");
        }

        try
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            foreach (CarInfo carInfo in carInfoList)
            {
                Validate.ValidateCarInfo(carInfo);
                sb.Append("{");
                sb.Append($"\"car_id\": {carInfo.CarId}, ");
                sb.Append($"\"brand\": \"{carInfo.Brand}\", ");
                sb.Append($"\"model\": \"{carInfo.Model}\", ");
                sb.Append($"\"year\": {carInfo.Year}, ");
                sb.Append($"\"price\": {carInfo.Price.ToString().Replace(',', '.')}, ");
                sb.Append($"\"is_used\": {carInfo.IsUsed.ToString().ToLower()}, ");
                sb.Append("\"features\": [");

                for (int i = 0; i < carInfo.Features.Count; i++)
                {
                    sb.Append($"\"{carInfo.Features[i]}\"");

                    if (i != carInfo.Features.Count - 1)
                    {
                        sb.Append(", ");
                    }
                }

                sb.Append("]}, ");
            }

            sb.Remove(sb.Length - 2, 2);

            sb.Append("]");

            return sb.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}