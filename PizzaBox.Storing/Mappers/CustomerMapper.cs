using System.Linq;

namespace PizzaBox.Storing.Mappers
{
    public class CustomerMapper //: IMapper<PizzaBox.Storing.Entities.Customer, PizzaBox.Domain.Models.Customer>
    {
        public Domain.Models.Customer Map(Entities.Customer model)
        {
            return new Domain.Models.Customer(model.Name);
        }

        public Entities.Customer Map(Domain.Models.Customer model)
        {
            Entities.Customer customer = new Entities.Customer();
            customer.Name = model.Name;
            return customer;
        }
    }
}