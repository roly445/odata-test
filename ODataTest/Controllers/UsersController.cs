using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataTest.Models;

namespace ODataTest.Controllers;

public class UsersController : ODataController
{
    private static List<User> users = new List<User>
    {
        new User
        {
            Id = Guid.Parse("e1bead22-a1fb-400c-8911-061490c688fb"),
            FirstName = "Test1",
            LastName = "User1",
            Devices = new List<Device>
            {
                new Device
                {
                    Id = Guid.Parse("72fd83c2-3c7e-4b11-864c-2b31de68ff30"),
                    DeviceName = "Test1-User1_Device1",
                    DeviceFeatures = new List<DeviceFeature>
                    {
                        new DeviceFeature
                        {
                            Id = Guid.Parse("96de8925-d7c4-4e6d-b248-3333f56e25d4"),
                            Code = "Code1"
                        },
                        new DeviceFeature
                        {
                            Id = Guid.Parse("38c0dcad-f45d-4a8d-97dd-5ccbbb8d7bfc"),
                            Code = "Code2"
                        },
                        new DeviceFeature
                        {
                            Id = Guid.Parse("315a9f63-0d0a-419a-b151-4f3b601720e0"),
                            Code = "Code3"
                        },
                        new DeviceFeature
                        {
                            Id = Guid.Parse("0011eea0-9948-4398-8ed8-c7baaae6ae31"),
                            Code = "Code4"
                        },
                        new DeviceFeature
                        {
                            Id = Guid.Parse("95382b2e-f93c-4e2a-8078-35d4a0e35382"),
                            Code = "Code5"
                        }
                    }
                }

            }
        },
        new User
        {
            Id = Guid.Parse("3905d3bb-cca3-477d-a134-c4af14bc0ca3"),
            FirstName = "Test2",
            LastName = "User2",
            Devices = new List<Device>
            {
                new Device
                {
                    Id = Guid.Parse("789f28a3-58c7-4d9e-acb8-9f5e80df0d46"),
                    DeviceName = "Test2-User2_Device1",
                    DeviceFeatures = new List<DeviceFeature>(),
                }

            }
        }

    };

    [HttpGet]
    public IActionResult Get(ODataQueryOptions<User> options)
    {
        return this.Ok(options.ApplyTo(users.AsQueryable()));
    }

    [HttpGet]
    public IActionResult Get([FromODataUri] Guid key, ODataQueryOptions<User> options)
    {
        return Ok(options.ApplyTo(users.Where(x => x.Id == key).AsQueryable()));
    }

    [HttpGet]
    public IActionResult GetDevices([FromODataUri] Guid key, ODataQueryOptions<Device> options)
    {
        return Ok(options.ApplyTo(users.Single(x => x.Id == key).Devices.AsQueryable()));
    }
}