namespace PizzaBox.Domain.Models
{
    public class CheeseStuffedCrust : Crust
    {
        private const decimal PRICE = 1.5m;

        public CheeseStuffedCrust()
        {
            Name = "Cheese Stuffed Crust";
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
