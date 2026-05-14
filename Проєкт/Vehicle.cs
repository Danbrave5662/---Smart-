using System;

namespace TrafficMonitoringSystem;

/// Клас, що описує транспортний засіб.
public class Vehicle
{
    private double _currentSpeed;

    /// Поточна швидкість автомобіля. Реалізовано перевірку на від'ємне значення.
    public double CurrentSpeed
    {
        get { return _currentSpeed; }
        set { _currentSpeed = (value >= 0) ? value : 0; } // Логіка аксесора: швидкість не може бути < 0
    }

    public string LicensePlate { get; set; } // Номерний знак
    public string VehicleType { get; set; }  // Тип (легковий, вантажний тощо)
    public GPSRoute CurrentRoute { get; set; } // Поточний маршрут (агрегація)

    // Конструктор за замовчуванням
    public Vehicle()
    {
        LicensePlate = "Невідомо";
        VehicleType = "Легковий";
        CurrentSpeed = 0;
    }

    // Конструктор з параметрами
    public Vehicle(string licensePlate, string vehicleType, double currentSpeed)
    {
        LicensePlate = licensePlate;
        VehicleType = vehicleType;
        CurrentSpeed = currentSpeed;
    }

    // Конструктор копіювання
    public Vehicle(Vehicle other)
    {
        this.LicensePlate = other.LicensePlate;
        this.VehicleType = other.VehicleType;
        this.CurrentSpeed = other.CurrentSpeed;
        this.CurrentRoute = other.CurrentRoute;
    }

    public void UpdateSpeed(double newSpeed) { }
}