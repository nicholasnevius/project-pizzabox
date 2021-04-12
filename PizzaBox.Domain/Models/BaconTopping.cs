namespace PizzaBox.Domain.Models
{
    public class BaconTopping : Topping
    {
        private const decimal PRICE = 0.5m;

        public BaconTopping() : base(PRICE)
        {
            Name = "Bacon";
        }

        public BaconTopping(decimal price) : base(price)
        {
            Name = "Bacon";
        }

    }
}
