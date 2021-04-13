using PizzaBox.Client.Contexts;
using System.Linq;
using PizzaBox.Client.Singletons;
using PizzaBox.Client.States;

namespace PizzaBox.Client.States
{
    public class DisplayStoreOrderHistoryState : AState
    {
        public override void Handle(Context context)
        {
            // just show order history
            var index = 0;
            OrderSingleton.Instance.Orders.Where(order => order.Store.Name.Equals(context.Store.Name))
                .ToList().ForEach(order => System.Console.WriteLine($"{++index} - {order}"));
            context.State = StateSingleton.Instance.GetState<StoreSelectedState>();
        }
    }
}