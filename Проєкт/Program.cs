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
        
        // Зчитування файлу
        if (File.Exists(TrafficConstants.DefaultVehiclesFilePath))
        {
            Console.WriteLine(string.Format(localized["SystemLoading"], TrafficConstants.DefaultVehiclesFilePath));
            string[] lines = File.ReadAllLines(TrafficConstants.DefaultVehiclesFilePath);

            foreach (string line in lines)
            {
                // try-catch всередині циклу
                try
                {
                    string[] data = line.Split(';');
                    if (data.Length == 3)
                    {
                        string plate = data[0];
                        string type = data[1];
                        double speed = Convert.ToDouble(data[2]);

                        // штучно викидаємо нашу кастомну помилку
                        if (speed < 0)
                        {
                            throw new InvalidVehicleDataException("Швидкість не може бути меншою за нуль!", plate);
                        }

                        if (plate.IsValidLicensePlate())
                        {
                            Vehicle newCar;
                            if (type.Equals("Вантажний", StringComparison.OrdinalIgnoreCase))
                                newCar = new Truck(plate, speed, 4.5);
                            else if (type.Equals("Мотоцикл", StringComparison.OrdinalIgnoreCase))
                                newCar = new Motorcycle(plate, speed);
                            else
                                newCar = new PassengerCar(plate, speed);

                            loadedVehicles.Add(newCar);
                        }
                        else
                        {
                            Console.WriteLine(string.Format(localized["WarningInvalidPlate"], plate));
                        }
                    }
                }
                catch (InvalidVehicleDataException ex)
                {
                    // Перехоплюємо нашу помилку
                    Console.WriteLine($"\n[Custom Error] {ex.Message} Проблемне авто: {ex.InvalidPlate}");
                }
                catch (Exception ex)
                {
                    // Перехоплюємо будь-які інші помилки
                    Console.WriteLine($"\n[System Error] Сталася непередбачувана помилка у рядку: {ex.Message}");
                }
                finally
                {
                    // Виконується для кожного рядка
                    Console.WriteLine($"[Info] Завершено обробку рядка: {line}");
                }
            }

            Console.WriteLine("\n" + localized["SystemSuccess"]);
        }
        else
        {
            Console.WriteLine(localized["SystemError"]);
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