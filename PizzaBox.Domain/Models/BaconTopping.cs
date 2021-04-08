namespace PizzaBox.Domain.Models
{
    public class BaconTopping : Topping
    {
        private const decimal PRICE = 0.5m;

        public BaconTopping(uint amount) : base(amount, PRICE)
        {
            Name = "Bacon";
        }

        public BaconTopping() : this(1) {}
    }
}
