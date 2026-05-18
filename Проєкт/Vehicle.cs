using System;

namespace TrafficMonitoringSystem;

public class Vehicle
{
    // статичне поле
    private static int _totalVehiclesRegistered = 0;

    private string _licensePlate;
    private string _vehicleType;
    private double _currentSpeed;
    private GPSRoute _currentRoute;

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

    // статичний метод
    public static int GetTotalCount()
    {
        return _totalVehiclesRegistered;
    }

    public Vehicle()
    {
        _licensePlate = "Невідомо";
        _vehicleType = "Легковий";
        _currentSpeed = 0;
        _currentRoute = null;

        // Збільшуємо лічильник при створенні будь-якого авто
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

    public void UpdateSpeed(double newSpeed)
    {
        _currentSpeed = (newSpeed >= 0) ? newSpeed : 0;
    }
}