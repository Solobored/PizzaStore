namespace PizzaStore.Models;

public class PizzaSpecial
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string? Category { get; set; } = "Classic";  // Classic, Meat, Vegetarian, Specialty
    public decimal Rating { get; set; } = 4.5m;  // Rating out of 5
    public bool IsSpecial { get; set; } = false;  // Highlight as featured
}
