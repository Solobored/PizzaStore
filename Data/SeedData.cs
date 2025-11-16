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

            // Add pizza specials - expanded menu
            var specials = new[]
            {
                new PizzaSpecial
                {
                    Name = "Margherita",
                    Description = "Fresh tomato, basil, and mozzarella",
                    Price = 9.99m,
                    ImageUrl = "images/margherita.svg",
                    Category = "Classic",
                    Rating = 4.8m,
                    IsSpecial = false
                },
                new PizzaSpecial
                {
                    Name = "Pepperoni",
                    Description = "Crispy pepperoni and melted mozzarella",
                    Price = 10.99m,
                    ImageUrl = "images/pepperoni.svg",
                    Category = "Classic",
                    Rating = 4.7m,
                    IsSpecial = true
                },
                new PizzaSpecial
                {
                    Name = "Hawaiian",
                    Description = "Ham, pineapple, and mozzarella",
                    Price = 11.99m,
                    ImageUrl = "images/hawaiian.svg",
                    Category = "Classic",
                    Rating = 4.2m,
                    IsSpecial = false
                },
                
                // MEAT LOVERS
                new PizzaSpecial
                {
                    Name = "Meat Feast",
                    Description = "Pepperoni, sausage, bacon, and ham",
                    Price = 13.99m,
                    ImageUrl = "images/meat-feast.svg",
                    Category = "Meat",
                    Rating = 4.9m,
                    IsSpecial = true
                },
                new PizzaSpecial
                {
                    Name = "BBQ Chicken",
                    Description = "Grilled chicken, BBQ sauce, red onion, and cilantro",
                    Price = 12.99m,
                    ImageUrl = "images/bbq-chicken.svg",
                    Category = "Meat",
                    Rating = 4.6m,
                    IsSpecial = false
                },
                new PizzaSpecial
                {
                    Name = "Italian Sausage",
                    Description = "Italian sausage, bell peppers, onions, and mozzarella",
                    Price = 11.99m,
                    ImageUrl = "images/italian-sausage.svg",
                    Category = "Meat",
                    Rating = 4.5m,
                    IsSpecial = false
                },
                
                // VEGETARIAN
                new PizzaSpecial
                {
                    Name = "Garden Fresh",
                    Description = "Bell peppers, mushrooms, onions, olives, and tomatoes",
                    Price = 10.99m,
                    ImageUrl = "images/garden-fresh.svg",
                    Category = "Vegetarian",
                    Rating = 4.4m,
                    IsSpecial = false
                },
                new PizzaSpecial
                {
                    Name = "Spinach & Feta",
                    Description = "Fresh spinach, feta cheese, sun-dried tomatoes, and garlic",
                    Price = 11.99m,
                    ImageUrl = "images/spinach-feta.svg",
                    Category = "Vegetarian",
                    Rating = 4.7m,
                    IsSpecial = false
                },
                new PizzaSpecial
                {
                    Name = "Mushroom Deluxe",
                    Description = "Mix of fresh and sautéed mushrooms with truffle oil",
                    Price = 12.99m,
                    ImageUrl = "images/mushroom-deluxe.svg",
                    Category = "Vegetarian",
                    Rating = 4.6m,
                    IsSpecial = false
                },
                
                // SPECIALTY
                new PizzaSpecial
                {
                    Name = "Four Cheese",
                    Description = "Mozzarella, cheddar, feta, and parmesan",
                    Price = 12.99m,
                    ImageUrl = "images/four-cheese.svg",
                    Category = "Specialty",
                    Rating = 4.8m,
                    IsSpecial = true
                },
                new PizzaSpecial
                {
                    Name = "Pesto Genovese",
                    Description = "Fresh basil pesto, pine nuts, sun-dried tomatoes",
                    Price = 13.99m,
                    ImageUrl = "images/pesto-genovese.svg",
                    Category = "Specialty",
                    Rating = 4.7m,
                    IsSpecial = false
                },
                new PizzaSpecial
                {
                    Name = "Spicy Diavolo",
                    Description = "Hot peppers, pepperoni, jalapeños, and garlic",
                    Price = 11.99m,
                    ImageUrl = "images/spicy-diavolo.svg",
                    Category = "Specialty",
                    Rating = 4.5m,
                    IsSpecial = true
                }
            };

            context.Specials.AddRange(specials);

            // Add toppings - expanded options
            var toppings = new[]
            {
                new Topping { Name = "Extra cheese", Price = 1.25m },
                new Topping { Name = "Mushrooms", Price = 0.75m },
                new Topping { Name = "Onions", Price = 0.50m },
                new Topping { Name = "Green peppers", Price = 0.75m },
                new Topping { Name = "Olives", Price = 0.75m },
                new Topping { Name = "Pineapple", Price = 1.00m },
                new Topping { Name = "Pepperoni", Price = 1.00m },
                new Topping { Name = "Sausage", Price = 1.00m },
                new Topping { Name = "Bacon", Price = 1.25m },
                new Topping { Name = "Tomatoes", Price = 0.60m },
                new Topping { Name = "Spinach", Price = 0.75m },
                new Topping { Name = "Feta cheese", Price = 1.00m },
                new Topping { Name = "Jalapeños", Price = 0.60m },
                new Topping { Name = "Ham", Price = 1.00m }
            };

            context.Toppings.AddRange(toppings);

            // Commit the seed to DB
            context.SaveChanges();
        }
    }
}
