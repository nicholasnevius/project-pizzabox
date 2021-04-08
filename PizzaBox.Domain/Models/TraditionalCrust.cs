namespace PizzaBox.Domain.Models
{
    public class TraditionalCrust : Crust
    {
        private const decimal PRICE = 1.0m;

        public TraditionalCrust()
        {
            Name = "Traditional Crust";
        }

        public override decimal Price
        {
            get
            {
                return PRICE;
            }
        }
    }
}
