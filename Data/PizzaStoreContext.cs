using Microsoft.EntityFrameworkCore;
using PizzaStore.Models;

namespace PizzaStore.Data;

public class PizzaStoreContext : DbContext
{
    public PizzaStoreContext(DbContextOptions<PizzaStoreContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Pizza> Pizzas => Set<Pizza>();
    public DbSet<PizzaSpecial> Specials => Set<PizzaSpecial>();
    public DbSet<Topping> Toppings => Set<Topping>();
    public DbSet<PizzaTopping> PizzaToppings => Set<PizzaTopping>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PizzaTopping>()
            .HasKey(pt => new { pt.PizzaId, pt.ToppingId });

        modelBuilder.Entity<PizzaTopping>()
            .HasOne(pt => pt.Pizza)
            .WithMany(p => p.Toppings)
            .HasForeignKey(pt => pt.PizzaId);

        modelBuilder.Entity<PizzaTopping>()
            .HasOne(pt => pt.Topping)
            .WithMany()
            .HasForeignKey(pt => pt.ToppingId);
    }
}
