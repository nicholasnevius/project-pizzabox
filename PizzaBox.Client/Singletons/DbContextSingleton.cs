using PizzaBox.Storing.Entities;

namespace PizzaBox.Client.Singletons
{
    public class DbContextSingleton
    {
        private readonly AnimalsDbContext context = null;
        private static DbContextSingleton _instance = null;

        public static DbContextSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DbContextSingleton();
                }

                return _instance;
            }
        }

        public AnimalsDbContext Context
        {
            get
            {
                return context;
            }
        }

        private DbContextSingleton()
        {
            context = new AnimalsDbContext();
        }
    }
}