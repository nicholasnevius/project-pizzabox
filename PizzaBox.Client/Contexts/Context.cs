using PizzaBox.Domain.Models;
using PizzaBox.Client.States;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Client.Contexts
{
    public class Context
    {
        private Customer _customer = null;
        public Customer Customer
        {
            get
            {
                return _customer;
            }
            set
            {
                _customer = value;
            }
        }

        private Order _order = null;
        public Order Order
        {
            get
            {
                if (_order == null)
                {
                    _order = new Order();
                }
                return _order;
            }
            set
            {
                _order = value;
            }
        }

        private AStore _store = null;
        public AStore Store
        {
            get
            {
                return _store;
            }
            set
            {
                _store = value;
            }
        }
        private AState _state;
        public Context(AState state)
        {
            _state = state;
        }

        public AState State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        public System.DateTime FirstDay { get; set; }
        public System.DateTime LastDay { get; set; }

        public void Request()
        {
            _state.Handle(this);
        }
    }
}
