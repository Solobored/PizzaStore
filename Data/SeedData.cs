using System;
using System.Linq;
using PizzaStore.Models;

namespace PizzaStore.Data
{
    public static class SeedData
    {
        public static void Initialize(PizzaStoreContext context)
        {
            // If DB already seeded, do nothing.
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (context.Specials.Any() || context.Toppings.Any())
            {
                return;
            }

            // Add pizza specials
            var specials = new[]
            {
                new PizzaSpecial
                {
                    Name = "Margherita",
                    Description = "Tomato, basil, and mozzarella",
                    Price = 8.50m,
                    ImageUrl = "images/margherita.png"
                },
                new PizzaSpecial
                {
                    Name = "Pepperoni",
                    Description = "Pepperoni and mozzarella",
                    Price = 9.50m,
                    ImageUrl = "images/pepperoni.png"
                },
                new PizzaSpecial
                {
                    Name = "Vegetarian",
                    Description = "Seasonal vegetables and mozzarella",
                    Price = 9.00m,
                    ImageUrl = "images/vegetarian.png"
                }
            };

            context.Specials.AddRange(specials);

            // Add toppings
            var toppings = new[]
            {
                new Topping { Name = "Extra cheese", Price = 1.00m },
                new Topping { Name = "Mushrooms", Price = 0.75m },
                new Topping { Name = "Onions", Price = 0.50m },
                new Topping { Name = "Green peppers", Price = 0.75m },
                new Topping { Name = "Olives", Price = 0.75m },
                new Topping { Name = "Pineapple", Price = 1.00m }
            };

            context.Toppings.AddRange(toppings);

            // Commit the seed to DB
            context.SaveChanges();
        }
    }
}
