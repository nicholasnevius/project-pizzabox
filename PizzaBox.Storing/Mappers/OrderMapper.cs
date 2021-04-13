using System.Collections.Generic;
using PizzaBox.Storing.Entities;
using System;

namespace PizzaBox.Storing.Mappers
{
    public class OrderMapper : IMapper<Entities.Order, Domain.Models.Order>
    {
        private CustomerMapper customerMapper = new CustomerMapper();
        private PizzaMapper pizzaMapper = new PizzaMapper();
        private StoreMapper storeMapper = new StoreMapper();

        public Domain.Models.Order Map(Entities.Order model)
        {
            Domain.Models.Order order = new Domain.Models.Order();
            order.Customer = customerMapper.Map(model.Customer);

            List<Domain.Abstracts.APizza> apizzas = new List<Domain.Abstracts.APizza>();
            model.Pizzas.ForEach(p => apizzas.Add(pizzaMapper.Map(p)));
            order.Pizzas = apizzas;

            order.Price = model.TotalPrice;
            order.Store = storeMapper.Map(model.Store);
            order.TimePlaced = model.TimePlaced;
            return order;
        }

        public Entities.Order Map(Domain.Models.Order model)
        {
            Entities.Order order = new Entities.Order();

            order.Customer = customerMapper.Map(model.Customer);
            List<Pizza> pizzas = new List<Pizza>();
            model.Pizzas.ForEach(p => pizzas.Add(pizzaMapper.Map(p)));
            order.Pizzas = pizzas;

            order.Store = storeMapper.Map(model.Store);
            order.TotalPrice = model.Price;
            order.TimePlaced = DateTime.Now;
            return order;
        }
    }
}