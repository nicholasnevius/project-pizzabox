using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
    public class CrustSingleton
    {
        private static CrustSingleton _instance = null;
        private readonly CrustRepository repository = null;

        public List<Crust> Crusts { get; set; }
        public static CrustSingleton Instance 
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CrustSingleton();
                }
                return _instance;
            }
        }

        private CrustSingleton()
        {
            repository = new CrustRepository(DbContextSingleton.Instance.Context);
            Crusts = repository.GetList();
            /*
            Crusts = new List<Crust>()
            {
                new CheeseStuffedCrust(),
                new DeepDishCrust(),
                new TraditionalCrust()
            };
            */
        }
    }
}
