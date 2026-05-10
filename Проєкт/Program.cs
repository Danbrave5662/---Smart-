using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("ПІБ студента: Таніч Данило");
        Console.WriteLine("Курс: 1 курс, Група: ІПЗ-12");
        Console.WriteLine("Варіант завдання: 10 (Моделювання бізнес-процесів моніторингу дорожнього руху)");
        Console.WriteLine("Версія 1");
        Console.WriteLine("Старт роботи програми\n");

        // 2. Ініціалізація об'єктів для перевірки працездатності каркасу
        MonitoringSystem kyivTrafficControl = new MonitoringSystem("Kyiv");
        PoliceDatabase policeDb = new PoliceDatabase();

        // Зв'язуємо об'єкти
        kyivTrafficControl.DatabaseConnection = policeDb;

        Console.WriteLine("Каркас класiв устiшно iнiцiалiзовано.");
        Console.WriteLine("Реалiзовано 8 базових класiв предметної областi.");
        Console.WriteLine("Зв'язки: Асоцiацiя, Агрегацiя та Композицiя реалiзованi успiшно.\n");

        // 3. Завершення
        Console.WriteLine("Фiнiш роботи програми");
        Console.ReadLine(); 
    }
}
