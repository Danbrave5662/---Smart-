using System;
using System.Collections.Generic;

namespace TrafficMonitoringSystem;

/// Клас для керування маршрутними даними об'єкта.
public class GPSRoute
{
    public double TotalDistanceKm { get; set; } // Загальна дистанція
    public List<string> Waypoints { get; set; }  // Точки маршруту

    public GPSRoute()
    {
        TotalDistanceKm = 0;
        Waypoints = new List<string>();
    }

    public GPSRoute(double distance, List<string> waypoints)
    {
        TotalDistanceKm = distance;
        Waypoints = new List<string>(waypoints);
    }

    public GPSRoute(GPSRoute other)
    {
        this.TotalDistanceKm = other.TotalDistanceKm;
        this.Waypoints = new List<string>(other.Waypoints);
    }

    public void CalculateStatistics() { }
}