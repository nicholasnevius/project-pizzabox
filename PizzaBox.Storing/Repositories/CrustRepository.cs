using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Mappers;
using PizzaBox.Domain.Models;
using System.Linq;

namespace PizzaBox.Storing.Repositories
{
    public class CrustRepository : IRepository<PizzaBox.Domain.Models.Crust>
    {

        private readonly AnimalsDbContext context;
        private readonly CrustMapper mapper = new CrustMapper();

        public CrustRepository(AnimalsDbContext context)
        {
            this.context = context;
        }

        public void Add(Domain.Models.Crust t)
        {
            context.Crusts.Add(mapper.Map(t));
            context.SaveChanges();
        }

        public List<Domain.Models.Crust> GetList()
        {
            List<Domain.Models.Crust> crusts = new List<Domain.Models.Crust>();
            context.Crusts.ToList().ForEach(crust => crusts.Add(mapper.Map(crust)));
            return crusts;
        }

        public void Remove(Domain.Models.Crust t)
        {
            Entities.Crust dbCrust = mapper.Map(t);
            Entities.Crust crust = context.Crusts.ToList().Find(c => c.CrustType == dbCrust.CrustType);
            if (crust is not null)
            {
                context.Remove(crust);
                context.SaveChanges();
            }
        }

        public void Update(Domain.Models.Crust existing, Domain.Models.Crust updated)
        {
            Entities.Crust dbCrust = mapper.Map(existing);
            Entities.Crust crust = context.Crusts.ToList().Find(c => c.CrustType == dbCrust.CrustType);
            if (crust is not null)
            {
                Entities.Crust updatedMapped = mapper.Map(updated);
                crust.CrustType = updatedMapped.CrustType;
                crust.Price = updatedMapped.Price;
                context.SaveChanges();
            }
        }
    }
}