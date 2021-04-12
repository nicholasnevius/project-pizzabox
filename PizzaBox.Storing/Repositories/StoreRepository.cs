using System.Collections.Generic;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Mappers;
using PizzaBox.Domain.Abstracts;
using System.Linq;

namespace PizzaBox.Storing.Repositories
{
    public class StoreRepository : IRepository<AStore>
    {
        private readonly AnimalsDbContext context;
        private readonly StoreMapper mapper = new StoreMapper();

        public StoreRepository(AnimalsDbContext context)
        {
            this.context = context;
        }

        public void Add(AStore t)
        {
            context.Add(mapper.Map(t));
            context.SaveChanges();
        }

        public List<AStore> GetList()
        {
            List<AStore> AStores = new List<AStore>();

            context.Stores.AsEnumerable().GroupBy(s => s.Name).Select(s => s.First()).ToList().ForEach(store => AStores.Add(mapper.Map(store)));

            //context.Stores.ToList().ForEach(store => AStores.Add(mapper.Map(store)));
            return AStores;
        }

        public void Remove(AStore t)
        {
            Store existingStore = context.Stores.ToList().Find(store => store.Name.Equals(t.Name));
            if (existingStore is not null)
            {
                context.Remove(existingStore);
                context.SaveChanges();
            }
        }

        public void Update(AStore existing, AStore updated)
        {
            Store existingInDb = context.Stores.ToList().Find(store => store.Name.Equals(existing.Name));
            if (existingInDb is not null)
            {
                Store mappedUpdated = mapper.Map(updated);
                existingInDb.Name = mappedUpdated.Name;
                existingInDb.StoreType = mappedUpdated.StoreType;
                context.SaveChanges();
            }
        }
    }
}