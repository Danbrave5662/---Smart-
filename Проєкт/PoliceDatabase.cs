using System;
using System.Collections.Generic;

namespace TrafficMonitoringSystem;

/// Система зберігання даних про номери в розшуку.
public class PoliceDatabase
{
    public List<string> WantedPlates { get; set; } // Список номерів у розшуку

    public PoliceDatabase()
    {
        WantedPlates = new List<string>();
    }

    public PoliceDatabase(List<string> initialPlates)
    {
        // Створюємо новий список на основі переданого
        WantedPlates = new List<string>(initialPlates);
    }

    public PoliceDatabase(PoliceDatabase other)
    {
        this.WantedPlates = new List<string>(other.WantedPlates);
    }

    public void CheckIfWanted(string licensePlate) { }
}