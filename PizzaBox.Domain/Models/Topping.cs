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
    public override decimal Price
    {
        get
        {
            return Amount * PricePer;
        }
    }

    protected uint Amount { get; set; }
    protected decimal PricePer { get; set; }
    protected Topping(uint amount, decimal priceper)
    {
        Amount = amount;
        PricePer = priceper;
    }
    
    public override string ToString()
    {
        return $"{Amount} - {Name}";
    }
  }
}
