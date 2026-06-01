namespace TrafficMonitoringSystem;

public static class TrafficConstants
{
    public const string TruckType = "Вантажний";
    public const string MotorcycleType = "Мотоцикл";

    // Шляхи до файлів
    public const string DefaultVehiclesFilePath = "vehicles.txt";

    // Значення за замовчуванням
    public const string UnknownVehicle = "Невідомо";
    public const string DefaultVehicleType = "Легковий";

    // Налаштування швидкості
    public const double SpeedStep = 10.0;

    // Валідація номерів
    public const int MinLicensePlateLength = 4;
    public const int MaxLicensePlateLength = 8;
}