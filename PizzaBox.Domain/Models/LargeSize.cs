namespace PizzaBox.Domain.Models
{
    public class LargeSize : Size
    {
        private const decimal PRICE = 4.5m;

        public LargeSize()
        {
            Name = "Large Size";
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
