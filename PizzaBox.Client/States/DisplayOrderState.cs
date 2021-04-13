using System;
using PizzaBox.Client.Contexts;
using PizzaBox.Client.Singletons;

namespace PizzaBox.Client.States
{
    public class DisplayOrderState : AState
    {
        public override void Handle(Context context)
        {
            var index = 0;
            Console.WriteLine("Your order is: ");
            context.Order.Pizzas.ForEach(pizza =>  
                    Console.WriteLine($"{++index} - {pizza.Price} - {pizza}"));
            Console.WriteLine($"Total - {context.Order.Price}");

            context.State = StateSingleton.Instance.GetState<EditOrderState>();
        }
    }
}
