using System;

namespace TrafficMonitoringSystem;

public class Vehicle
{
    // Приватні поля
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
        set { _currentSpeed = (value >= 0) ? value : 0; } // Логіка перевірки
    }

    public GPSRoute CurrentRoute
    {
        get { return _currentRoute; }
        set { _currentRoute = value; }
    }

    // Конструктори
    public Vehicle()
    {
        _licensePlate = "Невідомо";
        _vehicleType = "Легковий";
        _currentSpeed = 0;
        _currentRoute = null;
    }

    public Vehicle(string licensePlate, string vehicleType, double currentSpeed)
    {
        _licensePlate = licensePlate;
        _vehicleType = vehicleType;
        // Дублюємо логіку перевірки швидкості для прямого запису в поле
        _currentSpeed = (currentSpeed >= 0) ? currentSpeed : 0;
    }

    public Vehicle(Vehicle other)
    {
        _licensePlate = other._licensePlate;
        _vehicleType = other._vehicleType;
        _currentSpeed = other._currentSpeed;
        _currentRoute = other._currentRoute;
    }

    // порожній метод
    public void UpdateSpeed(double newSpeed) { }
}