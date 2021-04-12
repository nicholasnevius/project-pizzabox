using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class CustomPizza : APizza
    {
        public CustomPizza() : base("Custom Pizza")
        {
        }

        public override void AddCrust()
        {

        }

        public override void AddSize()
        {

        }

        public override void AddToppings()
        {

        }

        public override APizza Clone()
        {
            return new CustomPizza();
        }
    }
}
