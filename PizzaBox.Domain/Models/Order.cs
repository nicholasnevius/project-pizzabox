using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
  public class Order : ASellable
  {
    public AStore Store { get; set; }
    public Customer Customer { get; set; }
    public List<APizza> Pizzas { get; set; }

    public override decimal Price
    {
        get
        {
            decimal Total = 0.0m;
            Pizzas.ForEach(pizza => Total += pizza.Price);
            return Total;
        }
    }

    public Order()
    {
        Pizzas = new List<APizza>();
    }

    /// <summary>
    /// 
    /// </summary>
    public void Save()
    {

    }
  }
}
