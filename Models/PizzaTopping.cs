namespace PizzaStore.Models;

public class PizzaTopping
{
    // composite key of PizzaId + ToppingId
    public int PizzaId { get; set; }
    public Pizza? Pizza { get; set; }

    public int ToppingId { get; set; }
    public Topping? Topping { get; set; }
}
