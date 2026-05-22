using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace TrafficMonitoringSystem;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("ПІБ студента: Таніч Данило | Група: ІПЗ-12");
        Console.WriteLine("Варіант завдання: 11");
        Console.WriteLine("Версія 4.0 (Методи розширення та математичні оператори)\n");

        List<Vehicle> loadedVehicles = new List<Vehicle>();
        string filePath = "vehicles.txt";

        // Зчитування з файлу (використанням методу розширення)
        if (File.Exists(filePath))
        {
            Console.WriteLine($"[Система] Зчитування даних з файлу {filePath}...");
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] data = line.Split(';');
                if (data.Length == 3)
                {
                    string plate = data[0];
                    string type = data[1];
                    double speed = Convert.ToDouble(data[2]);

                    // Метод розширення для рядка
                    if (plate.IsValidLicensePlate())
                    {
                        Vehicle newCar = new Vehicle(plate, type, speed);
                        loadedVehicles.Add(newCar);
                    }
                    else
                    {
                        Console.WriteLine($"[Попередження] Пропущено авто з некоректним номером: '{plate}'");
                    }
                }
            }
            Console.WriteLine("[Система] Дані успішно завантажено!\n");
        }
        else
        {
            Console.WriteLine("[Помилка] Файл з даними не знайдено!");
        }

        Console.WriteLine("--- Список зареєстрованих автомобілів ---");
        foreach (var car in loadedVehicles)
        {
            Console.WriteLine($"Авто: Номер - {car.LicensePlate}, Тип - {car.VehicleType}, Швидкість - {car.CurrentSpeed} км/год");
        }

        // демонстрація функціаналу версії 4
        Console.WriteLine("\n=== ДЕМОНСТРАЦІЯ ВЕРСІЇ 4 ===");

        if (loadedVehicles.Count > 0)
        {
            Vehicle testCar = loadedVehicles[0]; // Беремо першу машину з файлу
            Console.WriteLine($"Обрано авто для тестів: {testCar.LicensePlate} ({testCar.CurrentSpeed} км/год)");

            //  Демонстрація методу розширення для double 
            double speedMs = testCar.CurrentSpeed.ToMetersPerSecond();
            Console.WriteLine($"[Extension Method] Швидкість авто в метрах за секунду: {speedMs:F2} м/с");

            // Демонстрація математичних операторів + та - 
            Console.WriteLine("\n[Математичні оператори]");

            Vehicle acceleratedCar = testCar + 25; // Додаємо 25 км/год
            Console.WriteLine($"Швидкість після (car + 25): {acceleratedCar.CurrentSpeed} км/год");

            Vehicle brakedCar = testCar - 40; // Віднімаємо 40 км/год
            Console.WriteLine($"Швидкість після (car - 40): {brakedCar.CurrentSpeed} км/год");

            Vehicle hardBrakedCar = testCar - 100; // Перевірка захисту від від'ємної швидкості
            Console.WriteLine($"Екстрене гальмування (car - 100): {hardBrakedCar.CurrentSpeed} км/год");
        }

        Console.WriteLine("\nФініш роботи програми");
        Console.ReadLine();
    }
}