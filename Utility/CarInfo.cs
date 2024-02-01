namespace Utility;


/// <summary>
/// The CarInfo class represents the information about a car.
/// It contains properties to store the car's ID, brand, model, year, price,
/// usage status, and list of features.
/// This class ensures that the values passed to the properties are valid and throws exceptions when necessary.
/// </summary>
public class CarInfo
{
    private ulong _carId;
    private string _brand;
    private string _model;
    private ulong _year;
    private double _price;
    private bool _isUsed;
    private List<string> _feautures;

    /// <summary>
    /// Store information about id of the car.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">Car id could not be less than zero.</exception>
    public ulong CarId
    {
        get => _carId;

        init
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Value could not be less than zero.");
            }

            _carId = value;
        }
    }

    /// <summary>
    /// Store the information about car`s brand.
    /// </summary>
    /// <exception cref="ArgumentNullException">Brand must be not null or empty.</exception>
    public string Brand
    {
        get => _brand;

        init
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Value could not be null or empty.");
            }

            _brand = value;
        }
    }

    /// <summary>
    /// Store the information about car`s model.
    /// </summary>
    /// <exception cref="ArgumentNullException">Model must be not null or empty.</exception>
    public string Model
    {
        get => _model;

        init
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Value could not be null or empty.");
            }

            _model = value;
        }
    }

    /// <summary>
    /// Store the ulong value for year of creating the car.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">Year could not be less than zero.</exception>
    public ulong Year
    {
        get => _year;

        init
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Value could not be less than zero.");
            }

            _year = value;
        }
    }

    /// <summary>
    /// Store the information about price of the car.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">Price could not be less than zero.</exception>
    public double Price
    {
        get => _price;

        init
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Value could not be less than zero.");
            }

            _price = value;
        }
    }

    /// <summary>
    /// Store the information if car is used or not.
    /// </summary>
    public bool IsUsed
    {
        get => _isUsed;

        init
        {
            _isUsed = value;
        }
    }

    /// <summary>
    /// Store the information about features of the car.
    /// </summary>
    /// <exception cref="ArgumentNullException">Feautures must be not null.</exception>
    public List<string> Features
    {
        get => _feautures;

        init
        {
            if (value is null)
            {
                throw new ArgumentNullException("Value could not be null.");
            }
            _feautures = value;
        }
    }

    public CarInfo(ulong carId, string brand, string model, ulong year, double price, bool isUsed, List<string> features)
    {
        try
        {
            CarId = carId;
            Brand = brand;
            Model = model;
            Year = year;
            Price = price;
            IsUsed = isUsed;
            Features = features;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public CarInfo()
    {
        CarId = 0;
        Brand = "undefined";
        Model = "undefined";
        Year = 0;
        Price = 0;
        IsUsed = false;
        Features = new List<string>();
    }
}