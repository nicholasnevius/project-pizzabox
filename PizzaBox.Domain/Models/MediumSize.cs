namespace PizzaBox.Domain.Models
{
    public class MediumSize : Size 
    {
        private const decimal PRICE = 4.0m;

        public MediumSize()
        {
            Name = "Medium Size";
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
