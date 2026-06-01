using System;
using System.Collections.Generic;

namespace TrafficMonitoringSystem;

public class PoliceDatabase
{
    // Приватне поле
    private List<string> _wantedPlates;

    // Публічна властивість
    public List<string> WantedPlates
    {
        get { return _wantedPlates; }
        set { _wantedPlates = value ?? new List<string>(); }
    }

    public PoliceDatabase()
    {
        _wantedPlates = new List<string>();
    }

    public PoliceDatabase(List<string> initialPlates)
    {
        _wantedPlates = new List<string>(initialPlates);
    }

    public PoliceDatabase(PoliceDatabase other)
    {
        // Звертаємось напряму до приватного поля іншого об'єкта
        _wantedPlates = new List<string>(other._wantedPlates);
    }
}