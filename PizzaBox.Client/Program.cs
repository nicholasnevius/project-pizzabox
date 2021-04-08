using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Client.Singletons;

using PizzaBox.Client.Contexts;
using PizzaBox.Client.States;

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
      //.new CreateCustomerState()
      Console.WriteLine("Welcome to PizzaBox");
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
