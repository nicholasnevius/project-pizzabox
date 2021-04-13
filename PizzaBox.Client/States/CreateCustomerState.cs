using System;
using PizzaBox.Client.Contexts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;

namespace PizzaBox.Client.States
{
    public class CreateCustomerState : AState
    {
        public override void Handle(Context context)
        {
            Console.WriteLine("Enter customer name");
            var input = Console.ReadLine();
            context.Customer = new Customer(input);
            context.Order.Customer = context.Customer;
            //context.State = StateSingleton.Instance.GetState<DisplayStoresState>();
            context.State = StateSingleton.Instance.GetState<CustomerSelectedState>();
        }
    }
}