using System;

namespace TrafficMonitoringSystem;

public class RoadLane
{
    private int _laneNumber;
    private double _averageSpeed;
    private TrafficCamera _installedCamera;

    public int LaneNumber
    {
        get { return _laneNumber; }
        set { _laneNumber = value; }
    }

    public double AverageSpeed
    {
        get { return _averageSpeed; }
        set { _averageSpeed = value; }
    }

    public TrafficCamera InstalledCamera
    {
        get { return _installedCamera; }
        set { _installedCamera = value; }
    }

    public RoadLane()
    {
        _laneNumber = 1;
        _averageSpeed = 0.0;
        _installedCamera = null;
    }

    public RoadLane(int laneNumber, TrafficCamera camera)
    {
        _laneNumber = laneNumber;
        _averageSpeed = 0.0;
        _installedCamera = camera;
    }

    public RoadLane(RoadLane other)
    {
        _laneNumber = other._laneNumber;
        _averageSpeed = other._averageSpeed;
        _installedCamera = other._installedCamera;
    }

    public void CalculateOccupancy() { }
}