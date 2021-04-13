using System;
using PizzaBox.Client.Contexts;

namespace PizzaBox.Client.States
{
    public class CheckOrderTotalState : AState
    {
        public override void Handle(Context context)
        {
            if (context.Order.Price > 250.0m)
            {
                context.Order.Pizzas.RemoveAt(context.Order.Pizzas.Count - 1);
                Console.WriteLine("Cannot add pizza since order total would be over $250.00");
            }
            context.State = PizzaBox.Client.Singletons.StateSingleton.Instance.GetState<DisplayOrderState>();
        }
    }
}