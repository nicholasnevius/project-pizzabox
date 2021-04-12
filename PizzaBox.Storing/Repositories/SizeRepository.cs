using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Mappers;
using System.Linq;

namespace PizzaBox.Storing.Repositories
{
    public class SizeRepository : IRepository<Domain.Models.Size>
    {
        private readonly AnimalsDbContext context;
        private readonly SizeMapper mapper = new SizeMapper();

        public SizeRepository(AnimalsDbContext context)
        {
            this.context = context;
        }

        public void Add(Domain.Models.Size t)
        {
            context.Add(mapper.Map(t));
            context.SaveChanges();
        }

        public List<Domain.Models.Size> GetList()
        {
            List<Domain.Models.Size> sizes = new List<Domain.Models.Size>();
            context.Sizes.AsEnumerable().GroupBy(s => s.SizeType).Select(s => s.First()).ToList().ForEach(size => sizes.Add(mapper.Map(size)));
            return sizes;
        }

        public void Remove(Domain.Models.Size t)
        {
            Entities.Size dbSize = mapper.Map(t);
            Entities.Size size = context.Sizes.ToList().Find(s => s.SizeType == dbSize.SizeType);
            if (size is not null)
            {
                context.Remove(size);
                context.SaveChanges();
            }
        }

        public void Update(Domain.Models.Size existing, Domain.Models.Size updated)
        {
            Entities.Size dbSize = mapper.Map(existing);
            Entities.Size size = context.Sizes.ToList().Find(s => s.SizeType == dbSize.SizeType);
            if (size is not null)
            {
                Entities.Size updatedSize = mapper.Map(updated);
                size.Price = updatedSize.Price;
                size.SizeType = updatedSize.SizeType;
                context.SaveChanges();
            }
        }
    }
}