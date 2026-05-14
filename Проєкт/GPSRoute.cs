using System;
using System.Collections.Generic;

namespace TrafficMonitoringSystem;


public class GPSRoute
{
    public double TotalDistanceKm { get; set; }
    public List<string> Waypoints { get; set; }

    public GPSRoute()
    {
        Waypoints = new List<string>();
    }

    public void CalculateStatistics() { }
}
