using System;

namespace TrafficMonitoringSystem;

/// Клас для реєстрації порушення ПДР.
public class TrafficViolation
{
    public Vehicle Offender { get; set; }    // Об'єкт машини-порушника
    public DateTime Timestamp { get; set; }  // Час фіксації
    public string ViolationType { get; set; } // Тип порушення
    public string PhotoFilePath { get; set; } // Шлях до фото-доказу

    public TrafficViolation()
    {
        Timestamp = DateTime.Now;
        ViolationType = "Невизначено";
        PhotoFilePath = "no_image.jpg";
    }

    public TrafficViolation(Vehicle offender, string violationType, string photoPath)
    {
        Offender = offender;
        Timestamp = DateTime.Now;
        ViolationType = violationType;
        PhotoFilePath = photoPath;
    }

    public TrafficViolation(TrafficViolation other)
    {
        this.Offender = other.Offender;
        this.Timestamp = other.Timestamp;
        this.ViolationType = other.ViolationType;
        this.PhotoFilePath = other.PhotoFilePath;
    }

    public void RegisterViolation() { }
}