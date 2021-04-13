using System;
using PizzaBox.Client.Contexts;
using PizzaBox.Client.Singletons;

namespace PizzaBox.Client.States
{
    public class AddPizzaState : AState
    {
        private readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;

        public override void Handle(Context context)
        {
            var index = 0;
            _pizzaSingleton.Pizzas.ForEach(pizza => Console.WriteLine($"{++index} - {pizza.Name}"));
            var input = 0;
            do
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {

                }
            } while (input <= 0 || input > _pizzaSingleton.Pizzas.Count);

            Domain.Abstracts.APizza pizza = _pizzaSingleton.Pizzas[input - 1].Clone();
            context.Order.Pizzas.Add(pizza);

            context.State = pizza is Domain.Models.CustomPizza ? StateSingleton.Instance.GetState<CreateCustomPizzaState>()
                                                               : StateSingleton.Instance.GetState<SelectPizzaSizeState>();
        }
    }
}
