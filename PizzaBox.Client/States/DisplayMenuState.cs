using System;
using PizzaBox.Client.Contexts;
using PizzaBox.Client.Singletons;

namespace PizzaBox.Client.States
{
    public class DisplayMenuState : AState
    {
        private readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;

        public override void Handle(Context context)
        {
            var index = 0;
            _pizzaSingleton.Pizzas.ForEach(pizza => Console.WriteLine($"{++index} - {pizza}"));
            var input = 0;
            do
            {
                try {
                    input = int.Parse(Console.ReadLine());
                } catch (Exception)
                {
                    // No handle expections April
                }
            } while (input <= 0 || input > _pizzaSingleton.Pizzas.Count);

            context.Order.Pizzas.Add(_pizzaSingleton.Pizzas[input - 1]);

            context.State = StateSingleton.Instance.GetState<DisplayOrderState>();
        }
    }
}