namespace PizzaBox.Domain.Models
{
    public class PepperoniTopping : Topping
    {
        private const decimal PRICE = 0.5m;

        public PepperoniTopping(uint amount) : base(amount, PRICE)
        {
            Name = "Pepperoni";
        }

        public PepperoniTopping() : this(1) {}
    }
}
