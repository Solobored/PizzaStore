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
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSX2w-6ljxAJtEImAJ4zBsRnou1CoSAVmgvQw&s",
                    Category = "Classic",
                    Rating = 4.8m,
                    IsSpecial = false
                },
                new PizzaSpecial
                {
                    Name = "Pepperoni",
                    Description = "Pepperoni slices on cheese and tomato sauce",
                    Price = 10.99m,
                    ImageUrl = "https://www.sortirambnens.com/wp-content/uploads/2019/02/pizza-de-peperoni.jpg",
                    Category = "Classic",
                    Rating = 4.7m,
                    IsSpecial = true
                },
                new PizzaSpecial
                {
                    Name = "Hawaiian",
                    Description = "Ham, pineapple, and mozzarella",
                    Price = 11.99m,
                    ImageUrl = "https://hips.hearstapps.com/hmg-prod/images/hawaiian-pizza-index-65f4641de4b08.jpg?crop=0.889xw:1.00xh;0.0224xw,0",
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
                    ImageUrl = "https://emilybites.com/wp-content/uploads/2011/12/Meat-Lover-27s-Pizza-1c.jpg",
                    Category = "Meat",
                    Rating = 4.9m,
                    IsSpecial = true
                },
                new PizzaSpecial
                {
                    Name = "BBQ Chicken",
                    Description = "Grilled chicken, BBQ sauce, red onion, and cilantro",
                    Price = 12.99m,
                    ImageUrl = "https://www.allrecipes.com/thmb/qZ7LKGV1_RYDCgYGSgfMn40nmks=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/AR-24878-bbq-chicken-pizza-beauty-4x3-39cd80585ad04941914dca4bd82eae3d.jpg",
                    Category = "Meat",
                    Rating = 4.6m,
                    IsSpecial = false
                },
                new PizzaSpecial
                {
                    Name = "Italian Sausage",
                    Description = "Italian sausage, bell peppers, onions, and mozzarella",
                    Price = 11.99m,
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTiqsUJVrWzDsGea8iiRLOQq7QQ_bJyJU4HFA&s",
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
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRGsO8_BXeu1PTx2mLrb7OPazuxz4hJp273FQ&s",
                    Category = "Vegetarian",
                    Rating = 4.4m,
                    IsSpecial = false
                },
                new PizzaSpecial
                {
                    Name = "Spinach & Feta",
                    Description = "Fresh spinach, feta cheese, sun-dried tomatoes, and garlic",
                    Price = 11.99m,
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcThXNPsH6rt9K7zwXOYZBVwPKEssMz9trlO2w&s",
                    Category = "Vegetarian",
                    Rating = 4.7m,
                    IsSpecial = false
                },
                new PizzaSpecial
                {
                    Name = "Mushroom Deluxe",
                    Description = "Mix of fresh and sautéed mushrooms with truffle oil",
                    Price = 12.99m,
                    ImageUrl = "https://www.savingdessert.com/wp-content/uploads/2024/05/Mushroom-Pizza-13.jpg",
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
                    ImageUrl = "https://kitchenatics.com/wp-content/uploads/2020/09/Cheese-pizza-1.jpg",
                    Category = "Specialty",
                    Rating = 4.8m,
                    IsSpecial = true
                },
                new PizzaSpecial
                {
                    Name = "Pesto Genovese",
                    Description = "Fresh basil pesto, pine nuts, sun-dried tomatoes",
                    Price = 13.99m,
                    ImageUrl = "https://www.seriouseats.com/thmb/q9NBShpHtJmYScuHVnF3P8jf2KE=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__serious_eats__seriouseats.com__recipes__images__2013__04__20130320-pesto-pizza-8-842f875ee47447ed9b9396962a47e3ea.jpg",
                    Category = "Specialty",
                    Rating = 4.7m,
                    IsSpecial = false
                },
                new PizzaSpecial
                {
                    Name = "Spicy Diavolo",
                    Description = "Hot peppers, pepperoni, jalapeños, and garlic",
                    Price = 11.99m,
                    ImageUrl = "https://www.thecandidcooks.com/wp-content/uploads/2022/08/spicy-sausage-pepper-pizza-feature.jpg",
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
