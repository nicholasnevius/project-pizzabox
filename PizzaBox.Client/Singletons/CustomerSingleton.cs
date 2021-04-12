using PizzaBox.Storing.Repositories;
using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Singletons
{
    public class CustomerSingleton
    {
        private readonly CustomerRepository repository = null;
        private static CustomerSingleton _instance = null;
        public List<Customer> Customers { get; set; }
        public static CustomerSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomerSingleton();
                }
                return _instance;
            }
        }

        private CustomerSingleton()
        {
            repository = new CustomerRepository(DbContextSingleton.Instance.Context);
            Customers = repository.GetList();
        }
    }
}