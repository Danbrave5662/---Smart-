using System;
using System.IO; // Підключаємо бібліотеку для роботи з файлами
using System.Text;
using System.Collections.Generic; // Для роботи зі списками

namespace TrafficMonitoringSystem;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("ПІБ студента: Таніч Данило | Група: ІПЗ-12");
        Console.WriteLine("Варіант завдання: 11");
        Console.WriteLine("Версія 2.1 (Інкапсуляція та File I/O)\n");

        List<Vehicle> loadedVehicles = new List<Vehicle>();
        string filePath = "vehicles.txt";

        // Зчитування з файлу
        if (File.Exists(filePath))
        {
            Console.WriteLine($"[Система] Зчитування даних з файлу {filePath}...");
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                // Розбиваємо рядок на частини: Номер;Тип;Швидкість
                string[] data = line.Split(';');
                if (data.Length == 3)
                {
                    string plate = data[0];
                    string type = data[1];
                    double speed = Convert.ToDouble(data[2]);

                    // Створюємо об'єкт і додаємо в список
                    Vehicle newCar = new Vehicle(plate, type, speed);
                    loadedVehicles.Add(newCar);
                }
            }
            Console.WriteLine("[Система] Дані успішно завантажено!\n");
        }
        else
        {
            Console.WriteLine("[Помилка] Файл з даними не знайдено!");
        }

        // Демонстрація роботи
        Console.WriteLine("--- Список зареєстрованих автомобілів ---");
        foreach (var car in loadedVehicles)
        {
            // Звертаємось до об'єктів ззовні — тому використовуємо властивості (з великої літери)
            Console.WriteLine($"Авто: Номер - {car.LicensePlate}, Тип - {car.VehicleType}, Швидкість - {car.CurrentSpeed}");
        }

        Console.WriteLine("\nФініш роботи програми");
        Console.ReadLine();
    }
}