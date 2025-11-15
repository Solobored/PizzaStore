namespace PizzaStore.Models;

public class OrderWithStatus
{
    public Order Order { get; set; } = new();
    public string StatusText { get; set; } = "Unknown";

    public static OrderWithStatus FromOrder(Order o)
    {
        var s = new OrderWithStatus { Order = o };
        var age = (DateTime.Now - o.CreatedTime).TotalMinutes;

        if (age < 1) s.StatusText = "Received";
        else if (age < 2) s.StatusText = "Preparing";
        else if (age < 5) s.StatusText = "Out for delivery";
        else s.StatusText = "Delivered";

        return s;
    }
}
