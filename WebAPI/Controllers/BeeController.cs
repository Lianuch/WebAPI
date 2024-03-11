using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Entities;

namespace WebAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class BeeController : ControllerBase
{
    private readonly DataContext _context;

    public BeeController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBees()
    {
        var bees = await _context.Bees.ToListAsync();
        /*return bees;*/
        return Ok(bees);
    }  
    [HttpGet("{id}")]
    
    public async Task<IActionResult> GetBee(int id)
    {
        var bees = await _context.Bees.FindAsync(id);
        if (bees is null)
            return NotFound("Bee not found");
        
        return Ok(bees);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddBee(Bee bees)
    {
         _context.Bees.Add(bees);
         await _context.SaveChangesAsync();
        
        return Ok(await GetAllBees());
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveBee(int id)
    {
        var beeRemove = await _context.Bees.FindAsync(id);

        if (beeRemove == null)
        {
            return NotFound("Bee not found");
        }
         _context.Bees.Remove(beeRemove);
         await _context.SaveChangesAsync();
        
        return Ok(await GetAllBees());
    }
    [HttpPut]
    public async Task<IActionResult> UpdateBee(Bee updatedBees)
    {
        var dbBeees = await _context.Bees.FindAsync(updatedBees.Id);
        if (dbBeees is null)
            return NotFound("Bee not found");
        dbBeees.Name = updatedBees.Name;
        dbBeees.FirstName = updatedBees.FirstName;
        dbBeees.LastName = updatedBees.LastName;
        dbBeees.Place = updatedBees.Place;

        await _context.SaveChangesAsync();
        return Ok(await GetAllBees());
    }
}
