using Microsoft.AspNetCore.Mvc;
using VehicleAPI.Model;

namespace VehicleAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehiclesController : ControllerBase
{
    private static readonly List<Vehicle> Data = [];

    [HttpGet]
    public IActionResult<IEnumerable<Vehicle>> Get(string? make, int? year)
    {
        var result = Data.AsEnumerable();
        if (!string.IsNullOrWhiteSpace(make))
        {
            result = result.Where(v =>
                v.Make.Contains(make, StringComparison.OrdinalIgnoreCase));
        }

        if (year > 0)
        {
            result = result.Where(v => v.Year == year);
        }

        return Ok(result.ToList());
    }
}
