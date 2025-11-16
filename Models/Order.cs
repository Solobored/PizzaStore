namespace PizzaStore.Models;

public class Order
{
    // Matches the controllers that expect OrderId
    public int OrderId { get; set; }

    public DateTime CreatedTime { get; set; } = DateTime.Now;

    // Order status
    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    // Estimated delivery time (set after order placement)
    public DateTime? EstimatedDeliveryTime { get; set; }

    // Navigation
    public List<Pizza> Pizzas { get; set; } = new();

    // Delivery information
    public DeliveryInfo? DeliveryInfo { get; set; }

    // Helpers used in the UI
    public decimal GetDeliveryFee()
    {
        var total = GetTotalPrice();
        if (total < 15m) return 2.50m;
        if (total < 30m) return 1.50m;
        return 0m; // Free delivery for orders £30+
    }

    public decimal GetTotalPrice() => Pizzas?.Sum(p => p.GetTotalPrice()) ?? 0m;

    public decimal GetGrandTotal() => GetTotalPrice() + GetDeliveryFee();

    public string GetTotalPriceString() => GetTotalPrice().ToString("0.00");

    public string GetDeliveryFeeString() => GetDeliveryFee().ToString("0.00");

    public string GetGrandTotalString() => GetGrandTotal().ToString("0.00");
}

public enum OrderStatus
{
    Pending = 0,
    Confirmed = 1,
    Preparing = 2,
    OutForDelivery = 3,
    Delivered = 4,
    Cancelled = 5
}

