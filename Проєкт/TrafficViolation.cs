using System;

namespace TrafficMonitoringSystem;


public class TrafficViolation
{
    // Агрегація: порушення містить посилання на конкретну машину
    public Vehicle Offender { get; set; }
    public DateTime Timestamp { get; set; }
    public string ViolationType { get; set; }
    public string PhotoFilePath { get; set; } // Збереження фото 

    public void RegisterViolation() { }
}