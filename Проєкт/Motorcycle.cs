namespace TrafficMonitoringSystem;

public class Motorcycle : Vehicle
{
    // Мотоцикл передає свій тип у базовий клас
    public Motorcycle(string licensePlate, double currentSpeed)
        : base(licensePlate, "Мотоцикл", currentSpeed)
    {
    }

    // Власна реалізація виведення
    public override string GetVehicleSummary()
    {
        return $"[Мотоцикл] Номер: {LicensePlate} | Швидкість: {CurrentSpeed} км/год (Двоколісний)";
    }
}