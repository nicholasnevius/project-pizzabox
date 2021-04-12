using System.Collections.Generic;
using PizzaBox.Storing.Repositories;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Singletons
{
    public class ToppingSingleton
    {

        private readonly ToppingRepository repository = null;
        private static ToppingSingleton _instance = null;
        public List<Topping> Toppings { get; set; }
        public static ToppingSingleton Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new ToppingSingleton();
                }
                return _instance;
            }
        }

        private ToppingSingleton()
        {
            repository = new ToppingRepository(DbContextSingleton.Instance.Context);
            Toppings = repository.GetList();
        }
    }
}