using System;
using System.Collections.Generic;

namespace TrafficMonitoringSystem;


public class MonitoringSystem
{
    public string CityName { get; set; }

    // Композиція: система жорстко складається зі смуг (видаляється система - видаляються смуги)
    public List<RoadLane> Lanes { get; set; }

    // Асоціація: система просто підключається до бази поліції
    public PoliceDatabase DatabaseConnection { get; set; }

    public MonitoringSystem(string city)
    {
        CityName = city;
        Lanes = new List<RoadLane>();
    }

    public void Shutdown() { }
}
