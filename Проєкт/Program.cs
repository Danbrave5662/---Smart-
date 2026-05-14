using System;
using System.Text;

namespace TrafficMonitoringSystem;

class Program
{
    static void Main(string[] args)
    {
        // Налаштування кодування для коректного виводу кирилиці
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("ПІБ студента: Таніч Данило");
        Console.WriteLine("Курс: 1 курс, Група: ІПЗ-12");
        Console.WriteLine("Варіант завдання: 11");
        Console.WriteLine("Версія 2 (Конструктори та аксесори)");
        Console.WriteLine("Старт роботи програми\n");

        // ДЕМОНСТРАЦІЯ РОБОТИ:

        //  Використання конструктора за замовчуванням
        Vehicle carDefault = new Vehicle();
        Console.WriteLine($"Авто 1 (Default): Номер - {carDefault.LicensePlate}, Швидкість - {carDefault.CurrentSpeed}");

        // Конструктор з параметрами + перевірка аксесора (передаємо від'ємну швидкість -30)
        Vehicle carWithParams = new Vehicle("AA0001BB", "Вантажний", -30.0);
        Console.WriteLine($"Авто 2 (Params): Номер - {carWithParams.LicensePlate}, Швидкість - {carWithParams.CurrentSpeed} (корекція аксесором)");

        // Конструктор копіювання
        Vehicle carCopy = new Vehicle(carWithParams);
        Console.WriteLine($"Авто 3 (Copy): Номер - {carCopy.LicensePlate}, Швидкість - {carCopy.CurrentSpeed}");

        Console.WriteLine("\nКаркас Версії 2 готовий. Всі типи конструкторів реалізовані.");

        Console.WriteLine("\nФініш роботи програми");
        Console.ReadLine();
    }
}