using PizzaBox.Client.Contexts;
using PizzaBox.Client.Singletons;
using System;

namespace PizzaBox.Client.States
{
    public class DisplayStoresState : AState
    {
        public override void Handle(Context context)
        {
            var index = 0;
            StoreSingleton.Instance.Stores.ForEach(store => Console.WriteLine($"{++index} - {store}"));
            context.State = new SelectStoreState();
        }
    }
}