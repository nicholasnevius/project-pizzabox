using PizzaBox.Client.Contexts;
using System.Linq;

namespace PizzaBox.Client.States
{
    public class DisplayOrderHistoryState : AState
    {
        public override void Handle(Context context)
        {
            PizzaBox.Client.Singletons.OrderSingleton.Instance.Orders
                .Where(o => o.Customer.Name.Equals(context.Customer.Name)).ToList()
                .ForEach(order => System.Console.WriteLine(order));

            context.State = PizzaBox.Client.Singletons.StateSingleton.Instance.GetState<CustomerSelectedState>();
        }
    }
}