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
            Toppings.AddRange(new Topping[] { new PepperoniTopping(), new BaconTopping() });
        }

        public override void AddSize()
        {
            Size = new MediumSize();
        }

        public override void AddCrust()
        {
            Crust = new TraditionalCrust();
        }

        public override APizza Clone()
        {
            return new MeatPizza();
        }
    }
}
