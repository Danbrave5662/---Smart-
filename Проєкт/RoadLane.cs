using System;

namespace TrafficMonitoringSystem;


public class RoadLane
{
    public int LaneNumber { get; set; }
    public double AverageSpeed { get; set; }

    // Агрегація: на смузі встановлена камера
    public TrafficCamera InstalledCamera { get; set; }

    public void CalculateOccupancy() { }
}
