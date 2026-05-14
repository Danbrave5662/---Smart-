using System;

namespace TrafficMonitoringSystem;

/// Система сповіщення водіїв про стан доріг.
public class DriverNotification
{
    public string MessageText { get; set; } // Текст повідомлення
    public string AlertType { get; set; }   // Тип (Інфо, Небезпека тощо)
    public DateTime SentAt { get; set; }    // Час відправлення

    public DriverNotification()
    {
        MessageText = "Повідомлення відсутнє";
        AlertType = "Інфо";
        SentAt = DateTime.Now;
    }

    public DriverNotification(string messageText, string alertType)
    {
        MessageText = messageText;
        AlertType = alertType;
        SentAt = DateTime.Now;
    }

    public DriverNotification(DriverNotification other)
    {
        this.MessageText = other.MessageText;
        this.AlertType = other.AlertType;
        this.SentAt = other.SentAt;
    }

    public void SendToVehicle(Vehicle targetVehicle) { }
}