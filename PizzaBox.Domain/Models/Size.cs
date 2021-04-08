using PizzaBox.Domain.Abstracts;
using System.Xml.Serialization;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
    [XmlInclude(typeof(SmallSize))]
    [XmlInclude(typeof(MediumSize))]
    [XmlInclude(typeof(LargeSize))]
    public abstract class Size : AComponent
    {
        public override string ToString()
        {
            return $"{Name}";    
        }
    }
}
