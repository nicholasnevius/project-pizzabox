using System.Collections.Generic;
using PizzaBox.Storing.Repositories;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Singletons
{
    public class OrderSingleton
    {
        private static OrderSingleton _instance = null;
        private readonly OrderRepository repository;
        public List<Order> Orders { get; set; }
        public static OrderSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new OrderSingleton();
                }
                return _instance;
            }
        }

        public void PlaceOrder(Order order)
        {
            repository.Add(order);
        }

        private OrderSingleton()
        {
            repository = new OrderRepository(DbContextSingleton.Instance.Context);
            Orders = repository.GetList();
        }
    }
}