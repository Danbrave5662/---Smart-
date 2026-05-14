using System;

namespace TrafficMonitoringSystem;

/// Описує смугу руху на дорозі.
public class RoadLane
{
    public int LaneNumber { get; set; }      // Номер смуги
    public double AverageSpeed { get; set; } // Середня швидкість на смузі
    public TrafficCamera InstalledCamera { get; set; } // Встановлена камера (агрегація)

    public RoadLane()
    {
        LaneNumber = 1;
        AverageSpeed = 0.0;
    }

    public RoadLane(int laneNumber, TrafficCamera camera)
    {
        LaneNumber = laneNumber;
        AverageSpeed = 0.0;
        InstalledCamera = camera;
    }

    public RoadLane(RoadLane other)
    {
        this.LaneNumber = other.LaneNumber;
        this.AverageSpeed = other.AverageSpeed;
        this.InstalledCamera = other.InstalledCamera;
    }

    public void CalculateOccupancy() { }
}