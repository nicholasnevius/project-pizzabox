namespace PizzaBox.Domain.Models
{
    public class TraditionalCrust : Crust
    {
        private const decimal PRICE = 1.0m;

        public TraditionalCrust() : base(PRICE)
        {
            Name = "Traditional Crust";
        }

        public TraditionalCrust(decimal price) : base(price)
        {
            Name = "Traditional Crust";
        }
    }
}
