namespace PizzaBox.Domain.Models
{
    public class CheeseStuffedCrust : Crust
    {
        private const decimal PRICE = 1.5m;

        public CheeseStuffedCrust() : base(PRICE)
        {
            Name = "Cheese Stuffed Crust";
        }

        public CheeseStuffedCrust(decimal price) : base(price)
        {
            Name = "Cheese Stuffed Crust";           
        }
    }
}
