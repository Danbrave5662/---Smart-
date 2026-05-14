using System;

namespace TrafficMonitoringSystem;


public class TrafficCamera
{
    public int CameraId { get; set; }
    public double SpeedLimit { get; set; }

    // Асоціація: камера сканує машину, яка проїжджає повз
    public void ScanVehicle(Vehicle vehicle) { }
}
