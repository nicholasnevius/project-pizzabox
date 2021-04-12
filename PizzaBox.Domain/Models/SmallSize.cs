namespace PizzaBox.Domain.Models
{
    public class SmallSize : Size
    {
        private const decimal PRICE = 3.0m;

        public SmallSize() : base(PRICE)
        {
            Name = "Small Size";
        }

        public SmallSize(decimal price) : base(price)
        {
            Name = "Small Size"; 
        }
    }
}
