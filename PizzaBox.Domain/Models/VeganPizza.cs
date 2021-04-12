using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class VeganPizza : APizza
    {
        public VeganPizza() : base("Vegan Pizza")
        {
        }

        public override void AddCrust()
        {
            Crust = new CheeseStuffedCrust();
        }

        public override void AddSize()
        {
            Size = new MediumSize();
        }

        public override void AddToppings()
        {
            Toppings.AddRange(new Topping[] { new MushroomTopping(), new OnionTopping() });
        }

        public override APizza Clone()
        {
            return new VeganPizza();
        }
    }
}
