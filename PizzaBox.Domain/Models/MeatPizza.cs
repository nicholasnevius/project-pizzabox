using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class MeatPizza : APizza
  {

    public MeatPizza() : base("Meat Pizza")
    {
    }

    public override void AddToppings()
    {
        Toppings.AddRange(new Topping[] { new PepperoniTopping(2), new BaconTopping(2) });
    }

    public override void AddSize()
    {
      if (Size == null)
      {
        Size = new MediumSize();
      }
    }

    public override void AddCrust()
    {
      if (Crust == null)
      {
        Crust = new TraditionalCrust();
      }
    }
  }
}
