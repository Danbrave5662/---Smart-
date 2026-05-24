using System;

namespace TrafficMonitoringSystem;

public class Vehicle
{
    // Статичні та зайві поля
    private static int _totalVehiclesRegistered = 0;

    private string _licensePlate;
    private string _vehicleType;
    private double _currentSpeed;
    private GPSRoute _currentRoute;

    // Властивості
    public string LicensePlate
    {
        get { return _licensePlate; }
        set { _licensePlate = value; }
    }

    public string VehicleType
    {
        get { return _vehicleType; }
        set { _vehicleType = value; }
    }

    public double CurrentSpeed
    {
        get { return _currentSpeed; }
        set { _currentSpeed = (value >= 0) ? value : 0; }
    }

    public GPSRoute CurrentRoute
    {
        get { return _currentRoute; }
        set { _currentRoute = value; }
    }

    // Статичний метод
    public static int GetTotalCount()
    {
        return _totalVehiclesRegistered;
    }

    // Конструктори
    public Vehicle()
    {
        // Використовуємо константи замість звичайних слів
        _licensePlate = TrafficConstants.UnknownVehicle;
        _vehicleType = TrafficConstants.DefaultVehicleType;
        _currentSpeed = 0;
        _currentRoute = null;
        _totalVehiclesRegistered++;
    }

    public Vehicle(string licensePlate, string vehicleType, double currentSpeed)
    {
        _licensePlate = licensePlate;
        _vehicleType = vehicleType;
        _currentSpeed = (currentSpeed >= 0) ? currentSpeed : 0;
        _totalVehiclesRegistered++;
    }

    public Vehicle(Vehicle other)
    {
        _licensePlate = other._licensePlate;
        _vehicleType = other._vehicleType;
        _currentSpeed = other._currentSpeed;
        _currentRoute = other._currentRoute;
        _totalVehiclesRegistered++;
    }

    // Методи
    public void UpdateSpeed(double newSpeed)
    {
        _currentSpeed = (newSpeed >= 0) ? newSpeed : 0;
    }

    public static Vehicle operator ++(Vehicle vehicle)
    {
        // Використовуємо константу SpeedStep замість числа 10
        vehicle._currentSpeed += TrafficConstants.SpeedStep;
        return vehicle;
    }

    public static Vehicle operator --(Vehicle vehicle)
    {
        // Використовуємо константу SpeedStep замість числа 10
        vehicle._currentSpeed -= TrafficConstants.SpeedStep;
        if (vehicle._currentSpeed < 0)
        {
            vehicle._currentSpeed = 0;
        }
        return vehicle;
    }

    // Бінарний оператор == (порівняння за номерами)
    public static bool operator ==(Vehicle left, Vehicle right)
    {
        if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) return true;
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return false;

        return left._licensePlate == right._licensePlate;
    }

    // Бінарний operator !=
    public static bool operator !=(Vehicle left, Vehicle right)
    {
        return !(left == right);
    }

    //  Бінарний математичний оператор + (збільшення швидкості)
    public static Vehicle operator +(Vehicle vehicle, double speedIncrease)
    {
        // Використовуємо наш конструктор копіювання, щоб не змінювати оригінал
        Vehicle result = new Vehicle(vehicle);
        result._currentSpeed += speedIncrease; // Звертаємось напряму до приватного поля!
        return result;
    }

    // Бінарний математичний оператор - (зменшення швидкості на)
    public static Vehicle operator -(Vehicle vehicle, double speedDecrease)
    {
        Vehicle result = new Vehicle(vehicle);
        result._currentSpeed -= speedDecrease;

        // Захист від від'ємної швидкості
        if (result._currentSpeed < 0)
        {
            result._currentSpeed = 0;
        }
        return result;
    }

    // Неявне перетворення об'єкта Vehicle в double (повертає швидкість автомобіля з приватного поля)
    public static implicit operator double(Vehicle vehicle)
    {
        if (vehicle == null) return 0;
        return vehicle._currentSpeed;
    }

    public override bool Equals(object obj)
    {
        if (obj is Vehicle other)
        {
            return this._licensePlate == other._licensePlate;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return _licensePlate != null ? _licensePlate.GetHashCode() : 0;
    }
} 