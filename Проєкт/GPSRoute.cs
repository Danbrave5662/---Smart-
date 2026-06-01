using System;
using System.Collections.Generic;

namespace TrafficMonitoringSystem;

public class GPSRoute
{
    private double _totalDistanceKm;
    private List<string> _waypoints;

    public double TotalDistanceKm
    {
        get { return _totalDistanceKm; }
        set { _totalDistanceKm = value; }
    }

    public List<string> Waypoints
    {
        get { return _waypoints; }
        set { _waypoints = value ?? new List<string>(); }
    }

    public GPSRoute()
    {
        _totalDistanceKm = 0;
        _waypoints = new List<string>();
    }

    public GPSRoute(double distance, List<string> waypoints)
    {
        _totalDistanceKm = distance;
        _waypoints = new List<string>(waypoints);
    }

    public GPSRoute(GPSRoute other)
    {
        _totalDistanceKm = other._totalDistanceKm;
        _waypoints = new List<string>(other._waypoints);
    }
}