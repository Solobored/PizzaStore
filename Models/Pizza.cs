namespace PizzaStore.Models;

public enum PizzaSize
{
    Small = 10,
    Medium = 12,
    Large = 14,
    XLarge = 16
}

public class Pizza
{
    public int PizzaId { get; set; }

    // size of pizza
    public PizzaSize Size { get; set; } = PizzaSize.Medium;

    // Which special this pizza is based on
    public int SpecialId { get; set; }
    public PizzaSpecial? Special { get; set; }

    // relation to order
    public int OrderId { get; set; }
    public Order? Order { get; set; }

    public List<PizzaTopping> Toppings { get; set; } = new();

    // Price helpers used by UI
    public decimal GetSizePrice()
    {
        return Size switch
        {
            PizzaSize.Small => 0m,      // Small is base
            PizzaSize.Medium => 1.50m,   // +$1.50
            PizzaSize.Large => 3.00m,    // +$3.00
            PizzaSize.XLarge => 4.50m,   // +$4.50
            _ => 0m
        };
    }

    public decimal GetTotalPrice()
    {
        var specialPrice = Special?.Price ?? 0m;
        var sizePrice = GetSizePrice();
        var toppingsPrice = Toppings?.Sum(pt => pt.Topping?.Price ?? 0m) ?? 0m;
        return specialPrice + sizePrice + toppingsPrice;
    }

    public string GetFormattedTotalPrice() => GetTotalPrice().ToString("0.00");

    public string GetSizeDisplayName() => Size switch
    {
        PizzaSize.Small => "Small (10\")",
        PizzaSize.Medium => "Medium (12\")",
        PizzaSize.Large => "Large (14\")",
        PizzaSize.XLarge => "X-Large (16\")",
        _ => "Medium (12\")"
    };
}
