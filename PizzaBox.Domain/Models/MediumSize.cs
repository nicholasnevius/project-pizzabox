namespace PizzaBox.Domain.Models
{
    public class MediumSize : Size 
    {
        private const decimal PRICE = 4.0m;

        public MediumSize() : base(PRICE)
        {
            Name = "Medium Size";
        }
        
        public MediumSize(decimal price) : base(price)
        {
            Name = "Medium Size";
        }
    }
}
