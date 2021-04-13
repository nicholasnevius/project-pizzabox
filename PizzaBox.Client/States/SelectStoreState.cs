using System;

using PizzaBox.Client.Contexts;
using PizzaBox.Client.Singletons;

namespace PizzaBox.Client.States
{
    public class SelectStoreState : AState
    {
        public override void Handle(Context context)
        {
            Console.WriteLine("Select a store");
            int input = 0;
            do
            {
                try {
                    input = int.Parse(Console.ReadLine());
                } catch (Exception)
                {
                    // We don't really need to handle this, just let them try again
                }
            } while (input <= 0 || input > StoreSingleton.Instance.Stores.Count);

            context.Store = StoreSingleton.Instance.Stores[input - 1];
            context.Order.Store = context.Store;

            context.State = StateSingleton.Instance.GetState<EditOrderState>();
        }
    }
}
