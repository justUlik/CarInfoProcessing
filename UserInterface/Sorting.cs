using Utility;

namespace UserInterface;

/// <summary>
/// Sorting dataset.
/// </summary>
public static class Sorting
{
    /// <summary>
    /// Sorts a given list of CarInfo objects based on a specified field. The sorting can be done in either ascending
    /// or descending order. 
    /// The fields that can be sorted are: car_id, brand, model, year, price, is_used, features. If an invalid field is
    /// specified, a FormatException is thrown. 
    /// If the list is null or the field is null or empty, an ArgumentNullException is thrown.
    /// </summary>
    /// <param name="carInfos">The list of CarInfo objects to sort.</param>
    /// <param name="ascending">Whether to sort in ascending order. If false, the list will be sorted in descending order.</param>
    /// <param name="field">The field to sort by. Must be one of: car_id, brand, model, year, price, is_used, features.</param>
    /// <exception cref="ArgumentNullException">Thrown if the list is null or if the field is null or empty.</exception>
    /// <exception cref="FormatException">Thrown if an invalid field is specified.</exception>
    public static void CallingSoring(ref List<CarInfo> carInfos, bool ascending, string field)
    {
        if (Helpers.IsNullOrEmpty(carInfos) || string.IsNullOrEmpty(field))
        {
            throw new ArgumentNullException("Given value is null");
        }

        try
        {
            List<CarInfo> res;
            switch (field)
            {
                case "car_id":
                    res = SortCarInfo.SortData(carInfos, ascending, (a, b) => a.CarId.CompareTo(b.CarId));
                    break;
                case "brand":
                    res = SortCarInfo.SortData(carInfos, ascending, (a, b) => string.Compare(a.Brand, b.Brand));
                    break;
                case "model":
                    res = SortCarInfo.SortData(carInfos, ascending, (a, b) => string.Compare(a.Model, b.Model));
                    break;
                case "year":
                    res = SortCarInfo.SortData(carInfos, ascending, (a, b) => a.Year.CompareTo(b.Year));
                    break;
                case "price":
                    res = SortCarInfo.SortData(carInfos, ascending, (a, b) => a.Price.CompareTo(b.Price));
                    break;
                case "is_used":
                    res = SortCarInfo.SortData(carInfos, ascending, (a, b) => a.IsUsed.CompareTo(b.IsUsed));
                    break;
                case "features":
                    res = SortCarInfo.SortData(carInfos, ascending, 
                        (a, b) => string.Join(", ", a.Features).CompareTo(string.Join(", ", b.Features)));
                    break;
                default:
                    throw new FormatException("No such field.");
            }

            carInfos = res;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}