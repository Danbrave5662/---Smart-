using System;

public class Vehicle
{
    public string LicensePlate { get; set; }
    public double CurrentSpeed { get; set; }
    public string VehicleType { get; set; }

    // Агрегація: машина має маршрут, але маршрут може бути змінений
    public GPSRoute CurrentRoute { get; set; }

    // Порожній метод
    public void UpdateSpeed(double newSpeed) { }
}