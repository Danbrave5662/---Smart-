namespace TrafficMonitoringSystem;

public class Truck : Vehicle
{
    // Унікальна властивість, якої немає у звичайних машин
    public double LoadCapacity { get; set; }

    public Truck(string licensePlate, double currentSpeed, double loadCapacity)
        : base(licensePlate, "Вантажний", currentSpeed)
    {
        LoadCapacity = loadCapacity;
    }

    // Реалізація абстрактного методу зі своїм форматуванням
    public override string GetVehicleSummary()
    {
        return $"[Вантажівка] Номер: {LicensePlate} | Швидкість: {CurrentSpeed} км/год | Вантаж: {LoadCapacity} т";
    }
}