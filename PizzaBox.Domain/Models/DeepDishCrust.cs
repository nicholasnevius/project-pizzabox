namespace PizzaBox.Domain.Models
{
    public class DeepDishCrust : Crust
    {
        private const decimal PRICE = 1.5m;

        public DeepDishCrust()
        {
            Name = "Deep Dish Crust";
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
