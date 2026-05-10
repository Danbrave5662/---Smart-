using System;

public class DriverNotification
{
    public string MessageText { get; set; }
    public string AlertType { get; set; }
    public DateTime SentAt { get; set; }

    // Асоціація: надсилання повідомлення конкретному транспорту
    public void SendToVehicle(Vehicle targetVehicle) { }
}
