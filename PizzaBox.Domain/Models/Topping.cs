using PizzaBox.Domain.Abstracts;
using System.Xml.Serialization;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
  [XmlInclude(typeof(BaconTopping))]
  [XmlInclude(typeof(MushroomTopping))]
  [XmlInclude(typeof(OnionTopping))]
  [XmlInclude(typeof(PepperoniTopping))]
  public abstract class Topping : AComponent
  {
    public override decimal Price { get; set; }
    protected Topping(decimal priceper)
    {
        Price = priceper;
    }
    
    public override string ToString()
    {
        return $"{Name}";
    }
  }
}
