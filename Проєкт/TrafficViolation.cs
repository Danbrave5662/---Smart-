using System;

namespace TrafficMonitoringSystem;

public class TrafficViolation
{
    private Vehicle _offender;
    private DateTime _timestamp;
    private string _violationType;
    private string _photoFilePath;

    public Vehicle Offender
    {
        get { return _offender; }
        set { _offender = value; }
    }

    public DateTime Timestamp
    {
        get { return _timestamp; }
        set { _timestamp = value; }
    }

    public string ViolationType
    {
        get { return _violationType; }
        set { _violationType = value; }
    }

    public string PhotoFilePath
    {
        get { return _photoFilePath; }
        set { _photoFilePath = value; }
    }

    public TrafficViolation()
    {
        _timestamp = DateTime.Now;
        _violationType = "Невизначено";
        _photoFilePath = "no_image.jpg";
        _offender = null;
    }

    public TrafficViolation(Vehicle offender, string violationType, string photoPath)
    {
        _offender = offender;
        _timestamp = DateTime.Now;
        _violationType = violationType;
        _photoFilePath = photoPath;
    }

    public TrafficViolation(TrafficViolation other)
    {
        _offender = other._offender;
        _timestamp = other._timestamp;
        _violationType = other._violationType;
        _photoFilePath = other._photoFilePath;
    }
}