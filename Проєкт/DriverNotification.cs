using System;

namespace TrafficMonitoringSystem;

public class DriverNotification
{
    private string _messageText;
    private string _alertType;
    private DateTime _sentAt;

    public string MessageText
    {
        get { return _messageText; }
        set { _messageText = value; }
    }

    public string AlertType
    {
        get { return _alertType; }
        set { _alertType = value; }
    }

    public DateTime SentAt
    {
        get { return _sentAt; }
        set { _sentAt = value; }
    }

    public DriverNotification()
    {
        _messageText = "Повідомлення відсутнє";
        _alertType = "Інфо";
        _sentAt = DateTime.Now;
    }

    public DriverNotification(string messageText, string alertType)
    {
        _messageText = messageText;
        _alertType = alertType;
        _sentAt = DateTime.Now;
    }

    public DriverNotification(DriverNotification other)
    {
        _messageText = other._messageText;
        _alertType = other._alertType;
        _sentAt = other._sentAt;
    }
}