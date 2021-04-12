using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
    /// <summary>
    /// 
    /// </summary>
    public class PizzaSingleton
  {
    private static PizzaSingleton _instance;
    private readonly PizzaRepository repository = null;

    public List<APizza> Pizzas { get; set; }
    public static PizzaSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new PizzaSingleton();
        }

        return _instance;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private PizzaSingleton()
    {
      /*
      Pizzas = new List<APizza>()
      {
        new MeatPizza(),
        new VeganPizza()
      };

      _fileRepository.WriteToFile(Pizzas);
      */
      repository = new PizzaRepository(DbContextSingleton.Instance.Context);
      Pizzas = repository.GetList();
      //Pizzas = _fileRepository.ReadFromFile<APizza>(_path);
    }
  }
}
