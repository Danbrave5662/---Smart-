using System;

namespace TrafficMonitoringSystem;

public class TrafficCamera
{
    private int _cameraId;
    private double _speedLimit;

    public int CameraId
    {
        get { return _cameraId; }
        set { _cameraId = value; }
    }

    public double SpeedLimit
    {
        get { return _speedLimit; }
        set { _speedLimit = value; }
    }

    public TrafficCamera()
    {
        _cameraId = 0;
        _speedLimit = 50.0;
    }

    public TrafficCamera(int cameraId, double speedLimit)
    {
        _cameraId = cameraId;
        _speedLimit = speedLimit;
    }

    public TrafficCamera(TrafficCamera other)
    {
        _cameraId = other._cameraId;
        _speedLimit = other._speedLimit;
    }

    public TrafficViolation ScanVehicle(ITrackable vehicle)
    {
        // Перевіряємо, чи швидкість авто більша за ліміт камери
        if (vehicle.CurrentSpeed > _speedLimit)
        {
            string violationName = $"Перевищення швидкості на {vehicle.CurrentSpeed - _speedLimit} км/год";
            string photoPath = $"cam_{_cameraId}_snap.jpg";

            // Робимо приведення типів (каст) до (Vehicle) для сумісності з існуючим класом порушень
            return new TrafficViolation((Vehicle)vehicle, violationName, photoPath);
        }

        return null; // Порушення немає
    }
}