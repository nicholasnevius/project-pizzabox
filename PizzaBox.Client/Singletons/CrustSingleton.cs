using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Singletons
{
    public class CrustSingleton
    {
        private static CrustSingleton _instance = null;
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
            Crusts = new List<Crust>()
            {
                new CheeseStuffedCrust(),
                new DeepDishCrust(),
                new TraditionalCrust()
            };
        }
    }
}
