namespace ODataTest.Models;

public class Device
{
    public Guid Id { get; set; }

    public string DeviceName { get; set; }

    public List<DeviceFeature> DeviceFeatures { get; set; }
}