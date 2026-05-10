using System;
using System.Collections.Generic;

public class PoliceDatabase
{
    public List<string> WantedPlates { get; set; }

    public PoliceDatabase()
    {
        WantedPlates = new List<string>();
    }

    public void CheckIfWanted(string licensePlate) { }
}