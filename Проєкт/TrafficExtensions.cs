using System;

namespace TrafficMonitoringSystem;

public static class TrafficExtensions
{
    //  Метод розширення для стандартного типу string

    public static bool IsValidLicensePlate(this string plate)
    {
        if (string.IsNullOrWhiteSpace(plate))
        {
            return false;
        }

        // Базова перевірка: номер зазвичай має від 4 до 8 символі
        return plate.Length >= 4 && plate.Length <= 8;
    }

    // Метод розширення для double
    // Перевод швидкості з км/год на м/c
    public static double ToMetersPerSecond(this double speedKmh)
    {
        return speedKmh * 0.277778;
    }
}
