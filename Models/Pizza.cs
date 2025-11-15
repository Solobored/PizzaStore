namespace PizzaStore.Models;

public class Pizza
{
    public int PizzaId { get; set; }

    // size in inches, used throughout UI
    public int Size { get; set; } = 12;

    // Which special this pizza is based on
    public int SpecialId { get; set; }
    public PizzaSpecial? Special { get; set; }

    // relation to order
    public int OrderId { get; set; }
    public Order? Order { get; set; }

    public List<PizzaTopping> Toppings { get; set; } = new();

    // Price helpers used by UI
    public decimal GetTotalPrice()
    {
        var specialPrice = Special?.Price ?? 0m;
        var toppingsPrice = Toppings?.Sum(pt => pt.Topping?.Price ?? 0m) ?? 0m;
        return specialPrice + toppingsPrice;
    }

    public string GetFormattedTotalPrice() => GetTotalPrice().ToString("0.00");
}
