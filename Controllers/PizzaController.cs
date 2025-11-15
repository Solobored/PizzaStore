using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Data;
using PizzaStore.Models;

namespace PizzaStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzasController : ControllerBase
{
    private readonly PizzaStoreContext _db;

    public PizzasController(PizzaStoreContext db) => _db = db;

    // GET api/pizzas -> returns specials
    [HttpGet]
    public async Task<ActionResult<List<PizzaSpecial>>> GetSpecials()
    {
        return await _db.Specials.OrderBy(s => s.Id).ToListAsync();
    }

    // GET api/pizzas/toppings
    [HttpGet("toppings")]
    public async Task<ActionResult<List<Topping>>> GetToppings()
    {
        return await _db.Toppings.OrderBy(t => t.Id).ToListAsync();
    }
}
