namespace PizzaBox.Domain.Models
{
    public class MushroomTopping : Topping
    {
        private const decimal PRICE = 0.6m;
        
        public MushroomTopping() : base(PRICE)
        {
            Name = "Mushroom";
        }

        public MushroomTopping(decimal price) : base(price)
        {
            Name = "Mushroom";
        }
    }
}
