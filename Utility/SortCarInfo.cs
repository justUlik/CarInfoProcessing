namespace Utility;

/// <summary>
/// Class represents methods for sorting dataset.
/// </summary>
public static class SortCarInfo
{
    /// <summary>
    /// Sorting data.
    /// </summary>
    /// <param name="data">Dataset</param>
    /// <param name="ascending">In which way sorting will be</param>
    /// <returns></returns>
    public static List<CarInfo> SortData(List<CarInfo> data, bool ascending, Func<CarInfo, CarInfo, int> comparison)
    {
        if (data is null)
        {
            throw new ArgumentNullException("Dataset is null.");
        }
 
        try
        {
            // could write merge sort or use build in sort method for List.
            QuickSort(data, 0, data.Count - 1, ascending, comparison); // could use regular Array.Sort.
            return data;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    /// <summary>
    /// Realization of quick sort algorithm.
    /// </summary>
    private static void QuickSort(List<CarInfo> data, int left, int right,
                           bool ascending, Func<CarInfo, CarInfo, int> comparison)
    {
        try
        {
            if (left < right)
            {
                int pivotIndex = Partition(data, left, right, ascending, comparison);
                QuickSort(data, left, pivotIndex - 1, ascending, comparison);
                QuickSort(data, pivotIndex + 1, right, ascending, comparison);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
 
    /// <summary>
    /// Sub method for quick sort.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="ascending"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private static int Partition(List<CarInfo> data, int left, int right, bool ascending, Func<CarInfo, CarInfo, int> comparison)
    {
        try
        {
            var pivot = data[right];
            int i = left - 1;
 
            for (int j = left; j < right; j++)
            {
                int comparisonResult = comparison(data[j], pivot);
                bool condition = ascending ? comparisonResult < 0 : comparisonResult > 0;
 
                if (condition)
                {
                    i++;
                    Swap(data, i, j);
                }
            }
 
            Swap(data, i + 1, right);
            return i + 1;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
 
    /// <summary>
    /// Swap realisation for SecPoint.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="i"></param>
    /// <param name="j"></param>
    private static void Swap(List<CarInfo> data, int i, int j)
    {
        try
        {
            var temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}