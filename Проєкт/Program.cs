using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;

namespace TrafficMonitoringSystem;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        string currentLang = "uk";
        string langFilePath = $"strings_{currentLang}.json";

        // Перевіряємо наявність файлу локалізації
        if (!File.Exists(langFilePath))
        {
            Console.WriteLine($"[Error] Localization file {langFilePath} missing!");
            return;
        }

        // Зчитуємо та десеріалізуємо словник перекладів з JSON
        string jsonText = File.ReadAllText(langFilePath);
        var localized = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonText);

        Console.WriteLine(localized["StudentInfo"]);
        Console.WriteLine(string.Format(localized["VersionInfo"], currentLang.ToUpper()));

        List<Vehicle> loadedVehicles = new List<Vehicle>();

        // Зчитування з файлу
        if (File.Exists(TrafficConstants.DefaultVehiclesFilePath))
        {
            Console.WriteLine(string.Format(localized["SystemLoading"], TrafficConstants.DefaultVehiclesFilePath));
            string[] lines = File.ReadAllLines(TrafficConstants.DefaultVehiclesFilePath);

            foreach (string line in lines)
            {
                string[] data = line.Split(';');
                if (data.Length == 3)
                {
                    string plate = data[0];
                    string type = data[1];
                    double speed = Convert.ToDouble(data[2]);

                    // Перевірка методом розширення
                    if (plate.IsValidLicensePlate())
                    {
                        Vehicle newCar;

                        // Поліморфне створення об'єктів залежно від типу у файлі
                        if (type.Equals("Вантажний", StringComparison.OrdinalIgnoreCase))
                        {
                            newCar = new Truck(plate, speed, 4.5); // 4.5 тонни
                        }
                        else if (type.Equals("Мотоцикл", StringComparison.OrdinalIgnoreCase))
                        {
                            newCar = new Motorcycle(plate, speed);
                        }
                        else
                        {
                            newCar = new PassengerCar(plate, speed);
                        }

                        loadedVehicles.Add(newCar);
                    }
                }
            }
            Console.WriteLine(localized["SystemSuccess"]);
        }
        else
        {
            Console.WriteLine(localized["SystemError"]);
        }

        // Виведення списку автомобілів
        Console.WriteLine(localized["HeaderList"]);
        foreach (var car in loadedVehicles)
        {
            Console.WriteLine(string.Format(localized["VehicleInfo"], car.LicensePlate, car.VehicleType, car.CurrentSpeed));
        }

        // Демонстрація методів розширення
        Console.WriteLine(localized["DemoHeader"]);

        if (loadedVehicles.Count > 0)
        {
            Vehicle testCar = loadedVehicles[0];
            Console.WriteLine(string.Format(localized["SelectedVehicle"], testCar.LicensePlate, testCar.CurrentSpeed));

            double speedMs = testCar.CurrentSpeed.ToMetersPerSecond();
            Console.WriteLine(string.Format(localized["ExtensionSpeedMs"], speedMs.ToString("F2")));
        }

        Console.WriteLine("\n[Polymorphism Demo]");
        foreach (var car in loadedVehicles)
        {
            Console.WriteLine(car.GetVehicleSummary());
        }

        Console.ReadLine();
    }
}