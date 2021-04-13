using PizzaBox.Client.Contexts;
using System.Linq;
using PizzaBox.Client.Singletons;
using System.Collections.Immutable;
using System;
using System.Collections.Generic;

namespace PizzaBox.Client.States
{
    public class CustomerSelectedState : AState
    {

        private static ImmutableArray<KeyValuePair<string, AState>> OPTIONS = ImmutableArray.Create(new KeyValuePair<string, AState>[] 
        { 
            new KeyValuePair<string, AState>("Create Order", StateSingleton.Instance.GetState<DisplayStoresState>()),
            new KeyValuePair<string, AState>("View Order History", StateSingleton.Instance.GetState<DisplayOrderHistoryState>())
        });

        public override void Handle(Context context)
        {
            // check if they can place an order at all
            // if so, offer the option
            // offer the option to show order history
        
            var orderHistory = PizzaBox.Client.Singletons.OrderSingleton.Instance.Orders
                                .Where(order => order.Customer.Name.Equals(context.Customer.Name))
                                .OrderByDescending(o => o.TimePlaced).ToList();

            bool canPlaceOrder = true;
            if (orderHistory.Count > 0)
            {
                var timeDifference = System.DateTime.Now - orderHistory.First().TimePlaced;
                if (timeDifference.TotalHours < 2)
                {
                    // can't place order since it has been less than 2 hours
                    canPlaceOrder = false;
                }
            }

            var index = canPlaceOrder ? 0
                                      : 1;
            for(int i = index; index < OPTIONS.Length; i < OPTIONS.Length)
            {
                
            }
            Console.WriteLine($"{++index} - {OPTIONS[i].Key}");

        
        }
    }
}