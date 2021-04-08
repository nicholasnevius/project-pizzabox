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
    private const string _path = @"pizza.xml";
    private static readonly FileRepository _fileRepository = new FileRepository();

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
      Pizzas = _fileRepository.ReadFromFile<APizza>(_path);
    }
  }
}
