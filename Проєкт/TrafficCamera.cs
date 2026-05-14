using System;

namespace TrafficMonitoringSystem;

/// Клас для опису камери фіксації трафіку.
public class TrafficCamera
{
    public int CameraId { get; set; }      // Унікальний ID камери
    public double SpeedLimit { get; set; } // Обмеження швидкості на ділянці

    public TrafficCamera()
    {
        CameraId = 0;
        SpeedLimit = 50.0;
    }

    public TrafficCamera(int cameraId, double speedLimit)
    {
        CameraId = cameraId;
        SpeedLimit = speedLimit;
    }

    public TrafficCamera(TrafficCamera other)
    {
        this.CameraId = other.CameraId;
        this.SpeedLimit = other.SpeedLimit;
    }

    public void ScanVehicle(Vehicle vehicle) { }
}