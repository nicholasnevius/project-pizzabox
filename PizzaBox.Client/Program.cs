using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Client.Singletons;

using PizzaBox.Client.Contexts;
using PizzaBox.Client.States;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;
using PizzaBox.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PizzaBox.Client
{
    /// <summary>
    /// 
    /// </summary>
    internal class Program
    {
        private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
        private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;
        private static readonly StateSingleton _stateSingleton = StateSingleton.Instance;

        private static readonly OrderSingleton _orderSingleton = OrderSingleton.Instance;
        private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance;
        private static readonly PizzaBox.Storing.Entities.AnimalsDbContext _context = DbContextSingleton.Instance.Context;

        public static void SeedData()
        {

            // For some reason EF doesn't like this
            // if a command runs that doesn't update a row
            // EF will completely error out and stop all transactionsg
            //_context.Database.ExecuteSqlRaw("ALTER INDEX IX_Toppings_ToppingType on dbo.Toppings SET ( IGNORE_DUP_KEY = ON )");
            //_context.Database.ExecuteSqlRaw("ALTER INDEX IX_Crusts_CrustType on dbo.Crusts SET ( IGNORE_DUP_KEY = ON )");
            //_context.Database.ExecuteSqlRaw("ALTER INDEX IX_Stores_Name on dbo.Stores SET ( IGNORE_DUP_KEY = ON )");
            //_context.Database.ExecuteSqlRaw("ALTER INDEX IX_Sizes_SizeType on dbo.Sizes SET ( IGNORE_DUP_KEY = ON )");
            //_context.Database.ExecuteSqlRaw("ALTER INDEX IX_Customers_Name on dbo.Customers SET ( IGNORE_DUP_KEY = ON )");

            OrderRepository orderRepository = new OrderRepository(DbContextSingleton.Instance.Context);
            Customer cust = new Customer("Nick");

            AStore store = new NewYorkStore();
            store.Name = "Test New York Store";

            Order order = new Order();
            order.Store = store;
            order.Customer = cust;

            APizza pizza = new CustomPizza();
            pizza.Crust = new DeepDishCrust();
            pizza.Size = new LargeSize();
            pizza.Toppings = new List<Topping>();
            pizza.Toppings.Add(new BaconTopping());
            pizza.Toppings.Add(new OnionTopping());

            order.Pizzas = new List<APizza>()
            {
              pizza
              //new MeatPizza(),
              //new VeganPizza()
            };

            orderRepository.Add(order);
            //orderRepository.Add(order);




            /*
      public Store Store { get; set; }
              public Customer Customer { get; set; }
              public List<Pizza> Pizzas { get; set; }
              public decimal TotalPrice { get; set; }
              public DateTime OrderTime { get; set; }

            */
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            Run();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void Run()
        {

            using (var dbContext = new PizzaBox.Storing.Entities.AnimalsDbContext())
            {
                //SeedData();
                var pizza = dbContext.Pizzas;
                var pizza2 = dbContext.Pizzas.Include(p => p.Crust).Include(p => p.Toppings).Include(p => p.Size).Select(pizza => pizza.PizzaType).Distinct();

                var orderHistory = dbContext.Orders.Include(o => o.Customer).Include(o => o.Store).Include(o => o.Pizzas).Where(o => o.Customer.Name.Equals("Nick")).ToList();

                var x = 0;
            }

            //.new CreateCustomerState()
            Context context = new Context(_stateSingleton.GetState<InitialState>());
            while (context.State != _stateSingleton.GetState<ExitState>())
            {
                context.Request();
            }

            /*
            Console.WriteLine("Welcome to PizzaBox");
            DisplayStoreMenu();

            order.Customer = new Customer();
            order.Store = SelectStore();
            order.Pizza = SelectPizza();

            order.Save();
            */
        }

        /// <summary>
        /// 
        /// </summary>
        private static void DisplayOrder(APizza pizza)
        {
            Console.WriteLine($"Your order is: {pizza}");
            Console.WriteLine($"The price is: {pizza.Price}");
        }

        /// <summary>
        /// 
        /// </summary>
        private static void DisplayPizzaMenu()
        {
            var index = 0;

            foreach (var item in _pizzaSingleton.Pizzas)
            {
                Console.WriteLine($"{++index} - {item}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void DisplayStoreMenu()
        {
            var index = 0;

            foreach (var item in _storeSingleton.Stores)
            {
                Console.WriteLine($"{++index} - {item}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static APizza SelectPizza()
        {
            //var input = int.Parse(Console.ReadLine());
            var input = 1;
            var pizza = _pizzaSingleton.Pizzas[input - 1];

            DisplayOrder(pizza);

            return pizza;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static AStore SelectStore()
        {
            var input = int.Parse(Console.ReadLine()); // be careful (think execpetion/error handling)

            DisplayPizzaMenu();

            return _storeSingleton.Stores[input - 1];
        }
    }
}
