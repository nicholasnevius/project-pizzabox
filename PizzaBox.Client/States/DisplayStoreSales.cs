using PizzaBox.Client.Contexts;

namespace PizzaBox.Client.States
{
    public class DisplayStoreSales : AState
    {
        public override void Handle(Context context)
        {
            // get all orders for context.Store from context.FirstDate to context.LastDate
            // then get:
            // number of each type of pizza
            // total revenue


            context.State = PizzaBox.Client.Singletons.StateSingleton.Instance.GetState<StoreSelectedState>();
        }
    }
}