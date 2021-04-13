using PizzaBox.Client.Contexts;
using PizzaBox.Client.Singletons;
using System;
using System.Linq;
using System.Collections.Generic;

namespace PizzaBox.Client.States
{
    public class DisplayStoresState : AState
    {
        public override void Handle(Context context)
        {
            // has a list of IGrouping
            // where the first instance in each is the newest order
            List<Domain.Abstracts.AStore> validStores = new List<Domain.Abstracts.AStore>();
            var orderHistory = PizzaBox.Client.Singletons.OrderSingleton.Instance.Orders
                                .Where(order => order.Customer.Name.Equals(context.Customer.Name))
                                .OrderByDescending(o => o.TimePlaced)
                                .GroupBy(o => o.Store.Name).Select(s => s.First()).ToList();
            foreach(Domain.Abstracts.AStore store in PizzaBox.Client.Singletons.StoreSingleton.Instance.Stores)
            {
                var lastOrderFromStore = orderHistory.Find(order => order.Store.Name.Equals(store.Name));
                if (lastOrderFromStore is not null)
                {
                    // the current customer HAS at least 1 order from the current store
                    // check difference of time placed is less than 2 hours
                    var timeDifference = System.DateTime.Now - lastOrderFromStore.TimePlaced;
                    if (timeDifference.TotalHours < 2)
                    {
                        validStores.Add(store);
                    }
                } else
                {
                    // customer has never placed an order from the current store
                    // store must be valid then
                    validStores.Add(store);
                }
            }

            var index = 0;
            validStores.ForEach(store => Console.WriteLine($"{++index} - {store}"));
            if (validStores.Count == 0)
            {
                Console.WriteLine("There are no stores available for you to order from");
                context.State = Singletons.StateSingleton.Instance.GetState<InitialState>();
                return;
            }
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
            } while (input <= 0 || input > validStores.Count);
            
            context.Store = validStores[input - 1];
            context.Order.Store = context.Store;

            //context.State = PizzaBox.Client.Singletons.StateSingleton.Instance.GetState<SelectStoreState>();
            context.State = StateSingleton.Instance.GetState<EditOrderState>();


        }
    }
}