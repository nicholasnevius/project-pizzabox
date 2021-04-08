namespace PizzaBox.Domain.Models
{
    public class SmallSize : Size
    {
        private const decimal PRICE = 3.0m;

        public SmallSize()
        {
            Name = "Small Size";
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
