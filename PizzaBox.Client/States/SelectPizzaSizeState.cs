using System;
using PizzaBox.Client.Contexts;
using System.Collections.Generic;

namespace PizzaBox.Client.States
{
    public class SelectPizzaSizeState : AState
    {
        private PizzaBox.Client.Singletons.SizeSingleton _sizeSingleton = PizzaBox.Client.Singletons.SizeSingleton.Instance;
        public override void Handle(Context context)
        {
            Console.WriteLine("Select a size for your pizza");
            var index = 0;

            var pizza = context.Order.Pizzas[context.Order.Pizzas.Count - 1];
            if (pizza is null)
            {
                throw new Exception("Forgot to add pizza before selecting size");
            }

            List<Domain.Abstracts.APizza> pizzaList = new List<Domain.Abstracts.APizza>();
            foreach (Domain.Models.Size size in _sizeSingleton.Sizes)
            {
                Domain.Abstracts.APizza cloned = pizza.Clone();
                cloned.Size = size;
                pizzaList.Add(cloned);
            }

            _sizeSingleton.Sizes.ForEach(size => Console.WriteLine($"{++index} - {size} - {pizzaList[index - 1].Price}"));
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
            } while (input <= 0 || input > _sizeSingleton.Sizes.Count);
            pizza.Size = _sizeSingleton.Sizes[input - 1];

            context.State = PizzaBox.Client.Singletons.StateSingleton.Instance.GetState<CheckOrderTotalState>();
        }
    }
}