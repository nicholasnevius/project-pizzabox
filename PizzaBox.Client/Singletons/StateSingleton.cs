using System.Collections.Generic;
using System;
using PizzaBox.Client.States;

namespace PizzaBox.Client.Singletons
{
    public class StateSingleton
    {
        private static StateSingleton _instance = null;
        public static StateSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StateSingleton();
                }
                return _instance;
            }
        }

        private Dictionary<Type, AState> _states = new Dictionary<Type, AState>();
        public AState GetState<T>()
        {
            return _states[typeof(T)];
        }


        private StateSingleton()
        {
            _states.Add(typeof(CreateCustomerState), new CreateCustomerState());
            _states.Add(typeof(DisplayStoresState), new DisplayStoresState());
            _states.Add(typeof(ExitState), new ExitState());
            _states.Add(typeof(SelectStoreState), new SelectStoreState());
            _states.Add(typeof(DisplayOrderState), new DisplayOrderState());
            _states.Add(typeof(EditOrderState), new EditOrderState());
            _states.Add(typeof(AddPizzaState), new AddPizzaState());
            _states.Add(typeof(RemovePizzaState), new RemovePizzaState());
            _states.Add(typeof(PlaceOrderState), new PlaceOrderState());
            _states.Add(typeof(InitialState), new InitialState());
            _states.Add(typeof(CreateStoreState), new CreateStoreState());
            _states.Add(typeof(SelectPizzaSizeState), new SelectPizzaSizeState());
            _states.Add(typeof(CheckOrderTotalState), new CheckOrderTotalState());
            _states.Add(typeof(CreateCustomPizzaState), new CreateCustomPizzaState());
            _states.Add(typeof(CustomerSelectedState), new CustomerSelectedState());
            _states.Add(typeof(DisplayOrderHistoryState), new DisplayOrderHistoryState());
        }
    }
}
