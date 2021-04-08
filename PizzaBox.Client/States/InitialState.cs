using System;
using PizzaBox.Client.Contexts;
using PizzaBox.Client.Singletons;

namespace PizzaBox.Client.States
{
    public class InitialState : AState
    {

        public override void Handle(Context context) {
            Console.WriteLine("Welcome to PizzaBox");
            Console.WriteLine("How can I help you today?");
            Console.WriteLine("1 - I am a user");
            Console.WriteLine("2 - I am a store manager");
            var input = 0;
            do {
                try {
                    input = int.Parse(Console.ReadLine());
                } catch (Exception)
                {

                }
            } while (input <= 0 || input > 2);

            switch (input)
            {
                case 1:
                    context.State = StateSingleton.Instance.GetState<CreateCustomerState>();
                    break;
                case 2:
                    context.State = StateSingleton.Instance.GetState<CreateStoreState>();
                    break;
                default:
                    break;
            }
        }
    }
}

