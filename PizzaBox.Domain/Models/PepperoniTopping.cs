namespace PizzaBox.Domain.Models
{
    public class PepperoniTopping : Topping
    {
        private const decimal PRICE = 0.5m;

        public PepperoniTopping() : base(PRICE)
        {
            Name = "Pepperoni";
        }

        public PepperoniTopping(decimal price) : base(price)
        {
            Name = "Pepperoni";
        }
    }
}
