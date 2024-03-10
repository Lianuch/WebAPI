using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;

namespace WebAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class BeeController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllBees()
    {
        var bees = new List<Bee>
        {
            new Bee()
            {
                Id = 1,
                Name = "Worker",
                FirstName = "Steve",
                LastName = "Stevenson",
                Place = "New Zeland"
                    
            }
        };
        /*return bees;*/
        return Ok(bees);
    }
}
