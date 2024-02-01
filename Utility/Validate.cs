namespace Utility;

/// <summary>
/// A utility class for validating CarInfo objects and records.
/// </summary>
public static class Validate
{
    /// <summary>
    /// Validates a record of data.
    /// </summary>
    /// <param name="record">The record to validate.</param>
    /// <exception cref="ArgumentNullException">Thrown if the record is null or empty.</exception>
    /// <exception cref="FormatException">Thrown if the record does not correspond to the expected format.</exception>
    public static void ValidateRecord(List<List<string>> record)
    {
        if (record is null)
        {
            throw new ArgumentNullException("List is null.");
        }

        if (record is not null && !record.Any())
        {
            throw new ArgumentNullException("List is empty.");
        }

        try
        {
            if (record.Count != 7)
            {
                throw new FormatException("Record does not correspond format.");
            }

            foreach (var item in record)
            {
                if (item is null)
                {
                    throw new ArgumentNullException("List is null.");
                }

                if (item is not null && item.Count < 2)
                {
                    throw new FormatException("List does not correspond format.");
                }
            }

            if (record[0].Count != 2 || record[0][0] != "car_id" || !ulong.TryParse(record[0][1], out _))
            {
                throw new FormatException("Record does not correspond format.");
            }

            if (record[1].Count != 2 || record[1][0] != "brand")
            {
                throw new FormatException("Record does not correspond format.");
            }

            if (record[2].Count != 2 || record[2][0] != "model")
            {
                throw new FormatException("Record does not correspond format.");
            }

            if (record[3].Count != 2 || record[3][0] != "year" || !ulong.TryParse(record[3][1], out _))
            {
                throw new FormatException("Record does not correspond format.");
            }

            if (record[4].Count != 2 || record[4][0] != "price" || !double.TryParse(record[4][1].Replace('.', ','), out _))
            {
                throw new FormatException("Record does not correspond format.");
            }

            if (record[5].Count != 2 || record[5][0] != "is_used" || !bool.TryParse(record[5][1], out _))
            {
                throw new FormatException("Record does not correspond format.");
            }

            if (record[6].Count < 2 || record[6][0] != "features")
            {
                throw new FormatException("Record does not correspond format.");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Validates a CarInfo object.
    /// </summary>
    /// <param name="carInfo">The CarInfo object to validate.</param>
    /// <exception cref="ArgumentNullException">Thrown if the CarInfo object is null.</exception>
    /// <exception cref="FormatException">Thrown if the CarInfo object does not correspond to the expected format.</exception>o
    public static void ValidateCarInfo(CarInfo carInfo)
    {
        if (carInfo is null)
        {
            throw new ArgumentNullException(nameof(carInfo));
        }
        try
        {
            if (string.IsNullOrEmpty(carInfo.Brand))
            {
                throw new FormatException("Value does not correspond format.");
            }

            if (string.IsNullOrEmpty(carInfo.Model))
            {
                throw new FormatException("Value does not correspond format.");
            }

            if (carInfo.Features is null || (carInfo.Features is not null && carInfo.Features.Count == 0))
            {
                throw new FormatException("Value does not correspond format.");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}