namespace PizzaBox.Domain.Models
{
    public class DeepDishCrust : Crust
    {
        private const decimal PRICE = 1.5m;

        public DeepDishCrust() : base(PRICE)
        {
            Name = "Deep Dish Crust";
        }

        public DeepDishCrust(decimal price) : base(price)
        {
            Name = "Deep Dish Crust";
        }
    }
}
