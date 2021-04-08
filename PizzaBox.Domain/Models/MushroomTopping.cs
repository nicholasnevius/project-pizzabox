namespace PizzaBox.Domain.Models
{
    public class MushroomTopping : Topping
    {
        private const decimal PRICE = 0.6m;
        
        public MushroomTopping(uint amount) : base(amount, PRICE)
        {
            Name = "Mushroom";
        }

        public MushroomTopping() : this(1) {} 
    }
}
