using System;
using System.Collections.Generic;
using System.Linq;
using PizzaStore.Models;

namespace PizzaStore.Services
{
    // Register as singleton in Program.cs (builder.Services.AddSingleton<OrderState>();)
    public class OrderState
    {
        public OrderState()
        {
            Order = new Order();
        }

        public Order Order { get; private set; } = new Order();

        public void AddPizza(Pizza pizza)
        {
            if (pizza == null) return;
            if (Order.Pizzas == null) Order.Pizzas = new List<Pizza>();
            Order.Pizzas.Add(pizza);
        }

        public void RemovePizzaAt(int index)
        {
            if (Order?.Pizzas == null) return;
            if (index < 0 || index >= Order.Pizzas.Count) return;
            Order.Pizzas.RemoveAt(index);
        }

        public void RemovePizza(Pizza p)
        {
            if (Order?.Pizzas == null || p == null) return;
            Order.Pizzas.Remove(p);
        }

        public void ResetOrder()
        {
            Order = new Order();
        }

        public bool HasItems => Order?.Pizzas?.Count > 0;
    }
}
