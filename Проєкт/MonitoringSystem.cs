using System;
using System.Collections.Generic;

namespace TrafficMonitoringSystem;

public class MonitoringSystem
{
    private string _cityName;
    private List<RoadLane> _lanes;
    private PoliceDatabase _databaseConnection;

    public string CityName
    {
        get { return _cityName; }
        set { _cityName = value; }
    }

    public List<RoadLane> Lanes
    {
        get { return _lanes; }
        set { _lanes = value; }
    }

    public PoliceDatabase DatabaseConnection
    {
        get { return _databaseConnection; }
        set { _databaseConnection = value; }
    }

    public MonitoringSystem()
    {
        _cityName = "Невідоме місто";
        _lanes = new List<RoadLane>();
        _databaseConnection = null;
    }

    public MonitoringSystem(string cityName, PoliceDatabase dbConnection)
    {
        _cityName = cityName;
        _lanes = new List<RoadLane>();
        _databaseConnection = dbConnection;
    }

    public MonitoringSystem(MonitoringSystem other)
    {
        _cityName = other._cityName;
        _databaseConnection = other._databaseConnection;
        _lanes = new List<RoadLane>();

        foreach (var lane in other._lanes)
        {
            _lanes.Add(new RoadLane(lane));
        }
    }

    // індексатор
    // Дозволяє звертатися: system[0] замість system.Lanes[0]
    public RoadLane this[int index]
    {
        get
        {
            // Перевірка індексу на коректність перед доступом до поля
            if (_lanes != null && index >= 0 && index < _lanes.Count)
            {
                return _lanes[index];
            }
            return null;
        }
        set
        {
            if (_lanes != null && index >= 0 && index < _lanes.Count)
            {
                _lanes[index] = value;
            }
        }
    }
}