using PizzaBox.Storing.Repositories;
using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Singletons
{
    public class SizeSingleton
    {
        private static SizeSingleton _instance = null;
        private readonly SizeRepository repository = null;
        public List<Size> Sizes { get; set; }
        public static SizeSingleton Instance 
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new SizeSingleton();
                }
                return _instance;
            }
        }

        private SizeSingleton()
        {
            repository = new SizeRepository(DbContextSingleton.Instance.Context);
            Sizes = repository.GetList();
        }

    }
}