using PizzaBox.Client.Contexts;

namespace PizzaBox.Client.States
{
    public abstract class AState
    {
        public abstract void Handle(Context context);
    }
}
