namespace PizzaStore.Models;

public class Order
{
    // Matches the controllers that expect OrderId
    public int OrderId { get; set; }

    public DateTime CreatedTime { get; set; } = DateTime.Now;

    // Navigation
    public List<Pizza> Pizzas { get; set; } = new();

    // Helpers used in the UI
    public decimal GetTotalPrice() => Pizzas?.Sum(p => p.GetTotalPrice()) ?? 0m;

    public string GetTotalPriceString() => GetTotalPrice().ToString("0.00");
}
