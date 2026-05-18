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
        Console.WriteLine("Версія 3.0 (Статика, Оператори, Індексатори)\n");

        List<Vehicle> loadedVehicles = new List<Vehicle>();
        string filePath = "vehicles.txt";

        // Зчитування з файлу
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

        Console.WriteLine("--- Список зареєстрованих автомобілів ---");
        foreach (var car in loadedVehicles)
        {
            Console.WriteLine($"Авто: Номер - {car.LicensePlate}, Тіп - {car.VehicleType}, Швидкість - {car.CurrentSpeed}");
        }

        // демонстрація функціоналу 3 версії
        Console.WriteLine("\n=== ДЕМОНСТРАЦІЯ ВЕРСІЇ 3 ===");

        // Тест статичного лічильника
        Console.WriteLine($"Загалом створено об'єктів Vehicle у пам'яті (статика): {Vehicle.GetTotalCount()}");

        // Створюємо додаткові екземпляри для тестів
        Vehicle car1 = new Vehicle("AA1111BB", "Легковий", 50);
        Vehicle car2 = new Vehicle("AA1111BB", "Вантажний", 75);
        Vehicle car3 = new Vehicle("BC2222CC", "Легковий", 40);

        Console.WriteLine($"Кількість авто після створення тестових екземплярів: {Vehicle.GetTotalCount()}");

        // Тест бінарних операторів порівняння (== та !=)
        Console.WriteLine($"\nПорівняння car1 та car2 (номери однакові): {car1 == car2}");
        Console.WriteLine($"Порівняння car1 та car3 (номери різні): {car1 != car3}");

        // Тест унарних операторів (++ та --)
        Console.WriteLine($"\nПочаткова швидкість car1: {car1.CurrentSpeed} км/год");
        car1++;
        Console.WriteLine($"Швидкість після car1++: {car1.CurrentSpeed} км/год");
        car1--;
        Console.WriteLine($"Швидкість після car1--: {car1.CurrentSpeed} км/год");

        // Тест неявного перетворення типів (implicit operator double)
        double speedAsDouble = car3;
        Console.WriteLine($"\nНеявне перетворення типу Vehicle -> double (швидкість car3): {speedAsDouble}");

        // Тест індексатора класу MonitoringSystem
        PoliceDatabase db = new PoliceDatabase();
        MonitoringSystem citySystem = new MonitoringSystem("Київ", db);

        TrafficCamera cam = new TrafficCamera(101, 60.0); // Ліміт 60 км/год
        RoadLane lane0 = new RoadLane(1, cam);

        citySystem.Lanes.Add(lane0);

        // Звертаємось через квадратні дужки системи
        RoadLane selectedLane = citySystem[0];
        if (selectedLane != null)
        {
            Console.WriteLine($"\n[Індексатор] Успішно отримано смугу руху №{selectedLane.LaneNumber} через індексатор citySystem[0]");
        }

        // Тест бізнес-логіки камери (ScanVehicle)
        Console.WriteLine($"\nКамера №{cam.CameraId} сканує авто {car2.LicensePlate} зі швидкістю {car2.CurrentSpeed} км/год...");
        TrafficViolation violation = cam.ScanVehicle(car2);

        if (violation != null)
        {
            Console.WriteLine($"[ФІКСАЦІЯ ПОРУШЕННЯ]: {violation.ViolationType}. Фото: {violation.PhotoFilePath}");
        }
        else
        {
            Console.WriteLine("Порушень швидкості не виявлено.");
        }

        Console.WriteLine("\nФініш роботи програми");
        Console.ReadLine();
    }
}