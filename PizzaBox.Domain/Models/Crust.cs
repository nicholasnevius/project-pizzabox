using PizzaBox.Domain.Abstracts;
using System.Xml.Serialization;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
    [XmlInclude(typeof(CheeseStuffedCrust))]
    [XmlInclude(typeof(DeepDishCrust))]
    [XmlInclude(typeof(TraditionalCrust))]
    public abstract class Crust : AComponent
    {
        public override string ToString()
        {
            return $"{Name}";
        }

        public override decimal Price { get; set; }
        protected Crust(decimal priceper)
        {
            Price = priceper;
        }
    }
}
