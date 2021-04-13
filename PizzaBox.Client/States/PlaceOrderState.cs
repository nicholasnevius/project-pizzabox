using PizzaBox.Client.Contexts;

namespace PizzaBox.Client.States
{
    public class PlaceOrderState : AState
    {
        public override void Handle(Context context)
        {
            context.Order.TimePlaced = System.DateTime.Now;
            PizzaBox.Client.Singletons.OrderSingleton.Instance.PlaceOrder(context.Order);
            context.State = PizzaBox.Client.Singletons.StateSingleton.Instance.GetState<InitialState>();
        }
    }
}