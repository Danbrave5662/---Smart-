namespace TrafficMonitoringSystem;

public class PassengerCar : Vehicle
{
    // Конструктор передає дані в базовий клас
    public PassengerCar(string licensePlate, double currentSpeed)
        : base(licensePlate, TrafficConstants.DefaultVehicleType, currentSpeed)
    {
    }

    // Реалізація абстрактного методу
    public override string GetVehicleSummary()
    {
        return $"[Легкове авто] Номер: {LicensePlate} | Швидкість: {CurrentSpeed} км/год";
    }
}