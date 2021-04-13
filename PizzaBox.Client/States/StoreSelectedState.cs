using PizzaBox.Client.Contexts;
using System.Linq;
using PizzaBox.Client.Singletons;
using System.Collections.Immutable;
using System;
using System.Collections.Generic;

namespace PizzaBox.Client.States
{
    public class StoreSelectedState : AState
    {
        private static ImmutableArray<KeyValuePair<string, AState>> OPTIONS = ImmutableArray.Create(new KeyValuePair<string, AState>[]
        {
            new KeyValuePair<string, AState>("View Order History", StateSingleton.Instance.GetState<DisplayStoreOrderHistoryState>()),
            new KeyValuePair<string, AState>("View Sales Report", StateSingleton.Instance.GetState<StoreSalesReportSelectedState>()),
            new KeyValuePair<string, AState>("Exit", StateSingleton.Instance.GetState<ExitState>())
        });

        public override void Handle(Context context)
        {
            var index = 0;
            OPTIONS.ToList().ForEach(option => Console.WriteLine($"{index + 1} - {OPTIONS[index++].Key}"));
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
            } while (input <= 0 || input > index);

            context.State = OPTIONS[input - 1].Value;
        }
    }
}