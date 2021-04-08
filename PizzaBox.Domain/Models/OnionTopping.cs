namespace PizzaBox.Domain.Models
{
    public class OnionTopping : Topping
    {
        private const decimal PRICE = 0.45m;

        public OnionTopping(uint amount) : base(amount, PRICE)
        {
            Name = "Onion";
        }  

        public OnionTopping() : this(1) {}
    }
}
