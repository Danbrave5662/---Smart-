namespace TrafficMonitoringSystem;

// Інтерфейс, який описує об'єкт, що підлягає моніторингу
public interface ITrackable
{
    string LicensePlate { get; }
    double CurrentSpeed { get; }
    string GetVehicleSummary(); // Метод для отримання короткої інформації
}