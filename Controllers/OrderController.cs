using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Data;
using PizzaStore.Models;

namespace PizzaStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly PizzaStoreContext _db;

    public OrdersController(PizzaStoreContext db) => _db = db;

    [HttpGet]
    public async Task<ActionResult<List<OrderWithStatus>>> GetOrders()
    {
        var orders = await _db.Orders
            .Include(o => o.Pizzas).ThenInclude(p => p.Special)
            .Include(o => o.Pizzas).ThenInclude(p => p.Toppings).ThenInclude(pt => pt.Topping)
            .OrderByDescending(o => o.CreatedTime)
            .ToListAsync();

        return orders.Select(o => OrderWithStatus.FromOrder(o)).ToList();
    }

    [HttpGet("{orderId}")]
    public async Task<ActionResult<OrderWithStatus>> GetOrderWithStatus(int orderId)
    {
        var order = await _db.Orders
            .Where(o => o.OrderId == orderId)
            .Include(o => o.Pizzas).ThenInclude(p => p.Special)
            .Include(o => o.Pizzas).ThenInclude(p => p.Toppings).ThenInclude(pt => pt.Topping)
            .SingleOrDefaultAsync();

        if (order == null) return NotFound();

        return OrderWithStatus.FromOrder(order);
    }

    [HttpPost]
    public async Task<ActionResult<int>> PlaceOrder([FromBody] Order order)
    {
        order.CreatedTime = DateTime.Now;

        // For simplicity: detach special objects and keep SpecialId
        foreach (var pizza in order.Pizzas)
        {
            if (pizza.Special != null)
            {
                pizza.SpecialId = pizza.Special.Id;
                pizza.Special = null;
            }

            // ensure pizza toppings have only ToppingId
            if (pizza.Toppings != null)
            {
                foreach (var pt in pizza.Toppings)
                {
                    if (pt.Topping != null)
                    {
                        pt.ToppingId = pt.Topping.Id;
                        pt.Topping = null;
                    }
                }
            }
        }

        _db.Orders.Add(order);
        await _db.SaveChangesAsync();

        return order.OrderId;
    }

    // DELETE /api/orders/{orderId}
    [HttpDelete("{orderId}")]
    public async Task<IActionResult> DeleteOrder(int orderId)
    {
        var order = await _db.Orders
            .Include(o => o.Pizzas).ThenInclude(p => p.Toppings)
            .SingleOrDefaultAsync(o => o.OrderId == orderId);

        if (order == null) return NotFound();

        // Remove toppings, pizzas then order (to be explicit)
        var pizzas = order.Pizzas?.ToList() ?? new List<Pizza>();
        foreach (var p in pizzas)
        {
            // remove pizza-toppings if any
            if (p.Toppings != null)
            {
                _db.RemoveRange(p.Toppings);
            }
        }

        _db.Pizzas.RemoveRange(pizzas);
        _db.Orders.Remove(order);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}
