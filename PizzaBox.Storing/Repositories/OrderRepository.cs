using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Mappers;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PizzaBox.Storing.Repositories
{
    public class OrderRepository : IRepository<Domain.Models.Order>
    {
        private readonly OrderMapper mapper = new OrderMapper();
        private readonly AnimalsDbContext context;
        public OrderRepository(AnimalsDbContext context)
        {
            this.context = context;
        }

        public void Add(Domain.Models.Order t)
        {
            context.Orders.Add(mapper.Map(t));
            context.SaveChanges();
        }

        public List<Domain.Models.Order> GetList()
        {
            return context.Orders.Include(o => o.Customer).Include(o => o.Store).Include(o => o.Pizzas)
                    .ThenInclude(p => p.Toppings).Include(o => o.Pizzas).ThenInclude(p => p.Size)
                    .Include(o => o.Pizzas).ThenInclude(p => p.Crust).Select(mapper.Map).ToList();
        }

        public void Remove(Domain.Models.Order t)
        {
            Entities.Order dbOrder = mapper.Map(t);
            Entities.Order order = context.Orders.ToList().Find(o => o.GetHashCode() == dbOrder.GetHashCode());
            if (order is not null)
            {
                context.Remove(order);
                context.SaveChanges();
            }
        }

        public void Update(Domain.Models.Order existing, Domain.Models.Order updated)
        {
            Entities.Order dbOrder = mapper.Map(existing);
            Entities.Order order = context.Orders.ToList().Find(o => o.GetHashCode() == dbOrder.GetHashCode());
            if (order is not null)
            {
                Entities.Order updatedOrder = mapper.Map(updated);
                order.Customer = updatedOrder.Customer;
                order.Pizzas = updatedOrder.Pizzas;
                order.Store = updatedOrder.Store;
                order.TimePlaced = updatedOrder.TimePlaced;
                order.TotalPrice = updatedOrder.TotalPrice;
                context.SaveChanges();
            }
        }
    }
}