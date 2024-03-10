using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities;

public class Bee
{
    public int Id { get; set; }
    [Required]
    public  string Name { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public  string LastName { get; set; } = string.Empty;
    public  string Place { get; set; } = string.Empty;
     
     
}