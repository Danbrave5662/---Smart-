using System;
using System.Collections.Generic;

namespace TrafficMonitoringSystem;

/// Головний клас системи моніторингу міста.
public class MonitoringSystem
{
    public string CityName { get; set; } // Назва міста
    public List<RoadLane> Lanes { get; set; } // Список смуг (композиція)
    public PoliceDatabase DatabaseConnection { get; set; } // Зв'язок з БД (асоціація)

    public MonitoringSystem()
    {
        CityName = "Невідоме місто";
        Lanes = new List<RoadLane>();
    }

    public MonitoringSystem(string cityName, PoliceDatabase dbConnection)
    {
        CityName = cityName;
        Lanes = new List<RoadLane>();
        DatabaseConnection = dbConnection;
    }

    public MonitoringSystem(MonitoringSystem other)
    {
        this.CityName = other.CityName;
        this.DatabaseConnection = other.DatabaseConnection;
        this.Lanes = new List<RoadLane>();
        // Глибоке копіювання списку смуг
        foreach (var lane in other.Lanes)
        {
            this.Lanes.Add(new RoadLane(lane));
        }
    }

    public void Shutdown() { }
}