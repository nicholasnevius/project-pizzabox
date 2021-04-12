namespace PizzaBox.Domain.Models
{
    public class OnionTopping : Topping
    {
        private const decimal PRICE = 0.45m;

        public OnionTopping() : base(PRICE)
        {
            Name = "Onion";
        }  

        public OnionTopping(decimal price) : base(price)
        {
            Name = "Onion";     
        }
    }
}
