using System;
using PizzaBox.Client.Contexts;
using PizzaBox.Client.Singletons;

namespace PizzaBox.Client.States
{
    public class RemovePizzaState : AState
    {
        public override void Handle(Context context)
        {
            var index = 0;
            context.Order.Pizzas.ForEach(pizza => Console.WriteLine($"{++index} - {pizza} - {pizza.Price}"));
            var input = 0;
            do
            {
                try {
                    input = int.Parse(Console.ReadLine());
                } catch (Exception)
                {

                }
            } while (input <= 0 || input > context.Order.Pizzas.Count);

            context.Order.Pizzas.RemoveAt(input - 1);

            context.State = StateSingleton.Instance.GetState<DisplayOrderState>();
        }
    }
}
