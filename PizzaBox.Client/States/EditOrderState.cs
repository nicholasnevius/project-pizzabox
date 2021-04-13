using PizzaBox.Client.Contexts;
using PizzaBox.Client.Singletons;
using System.Collections.Immutable;
using System;
using System.Collections.Generic;

namespace PizzaBox.Client.States
{
    public class EditOrderState : AState
    {
        private static readonly StateSingleton _stateSingleton = StateSingleton.Instance;
        private static ImmutableArray<KeyValuePair<string, AState>> OPTIONS = ImmutableArray.Create(new KeyValuePair<string, AState>[] 
        { 
            new KeyValuePair<string, AState>("Add Pizza", _stateSingleton.GetState<AddPizzaState>()) ,
            new KeyValuePair<string, AState>("Display Order", _stateSingleton.GetState<DisplayOrderState>()), 
            new KeyValuePair<string, AState>("Remove Pizza", _stateSingleton.GetState<RemovePizzaState>()),
            new KeyValuePair<string, AState>("Place Order", _stateSingleton.GetState<PlaceOrderState>())
        });
        public override void Handle(Context context)
        {
            var index = 0;
            // we can always add a pizza to the list but we cannot do the rest of the options without at least 1 pizza existing first
            bool printAddPizza = context.Order.Pizzas.Count < 50;
            if (printAddPizza)
            {
                Console.WriteLine($"{++index} - {OPTIONS[0].Key}");
            }
            if (context.Order.Pizzas.Count != 0) {
                for (int i = 1; i < OPTIONS.Length; i++)
                {
                    Console.WriteLine($"{++index} - {OPTIONS[i].Key}");
                }
            }

            var input = 0;
            do
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                } catch (Exception)
                {

                }
            } while (input <= 0 || input > index);

            context.State = OPTIONS[     
                                        printAddPizza ? input - 1
                                                      : input
                                    ].Value;
        }
    }
}