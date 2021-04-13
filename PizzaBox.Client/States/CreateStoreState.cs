using PizzaBox.Client.Contexts;
using System.Linq;
using PizzaBox.Client.Singletons;
using System.Collections.Immutable;
using System;
using System.Collections.Generic;

namespace PizzaBox.Client.States
{
    public class CreateStoreState : AState
    {

        public override void Handle(Context context)
        {
            Console.WriteLine("Select a store");
            var index = 0;
            StoreSingleton.Instance.Stores.ForEach(store => Console.WriteLine($"{++index} - {store.Name}"));
            int input = 0;
            do
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    // We don't really need to handle this, just let them try again
                }
            } while (input <= 0 || input > StoreSingleton.Instance.Stores.Count);
            context.Store = StoreSingleton.Instance.Stores[input - 1];
            context.State = StateSingleton.Instance.GetState<StoreSelectedState>();
        }
    }
}
