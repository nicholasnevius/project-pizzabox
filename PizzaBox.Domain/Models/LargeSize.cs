namespace PizzaBox.Domain.Models
{
    public class LargeSize : Size
    {
        private const decimal PRICE = 4.5m;

        public LargeSize() : base(PRICE)
        {
            Name = "Large Size";
        }

        public LargeSize(decimal price) : base(price)
        {
            Name = "Large Size";
        }
    }
}
