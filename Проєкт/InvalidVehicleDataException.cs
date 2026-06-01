using System;

namespace TrafficMonitoringSystem;

// Власний клас винятку для нашої системи
public class InvalidVehicleDataException : Exception
{
    public string InvalidPlate { get; } = string.Empty;

    // Базовий конструктор
    public InvalidVehicleDataException() : base("Виявлено некоректні дані транспортного засобу.") { }

    // Конструктор із повідомленням
    public InvalidVehicleDataException(string message) : base(message) { }

    // Конструктор, який зберігає номер проблемного авто
    public InvalidVehicleDataException(string message, string invalidPlate) : base(message)
    {
        InvalidPlate = invalidPlate;
    }
}