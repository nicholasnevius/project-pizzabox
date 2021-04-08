using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    /// <summary>
    /// 
    /// </summary>
    [XmlInclude(typeof(MeatPizza))]
    [XmlInclude(typeof(VeganPizza))]
    public abstract class APizza : ASellable
  {
    public Crust Crust { get; set; }
    public Size Size { get; set; }

    // This stupid crap needs to be here so I it doesn't
    // serialize the Toppings then add them in using
    // the default constructors ending up with duplicates
    // TODO: find a better way to handle this
    [XmlIgnore]
    public List<Topping> Toppings { get; set; }
    public string Name { get; set; }
    public override decimal Price
    {
        get
        {
            decimal Total = 0.0m;
            Total += Crust.Price;
            Total += Size.Price;
            foreach(Topping topping in Toppings)
            {
                Total += topping.Price;
            }
            return Total;
        }
    }

    public override string ToString()
    {
        if (this is CustomPizza)
        {
            string output = $"Crust: {Crust}" + Environment.NewLine + $"Size: {Size}" + Environment.NewLine + "Toppings: ";
            Toppings.ForEach(topping => output += topping.ToString() + ", ");
            output = output.Substring(0, output.LastIndexOf(", "));
            return output;
        }

        return Name;
    }

    protected APizza(String name)
    {
        Name = name;
        Factory();
    }

    private void Factory()
    {
      Toppings = new List<Topping>();

      AddCrust();
      AddSize();
      AddToppings();
    }

    public abstract void AddCrust();

    public abstract void AddSize();

    public abstract void AddToppings();
  }
}
