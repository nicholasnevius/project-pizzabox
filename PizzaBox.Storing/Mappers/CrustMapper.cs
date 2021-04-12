using System;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Mappers
{
    public class CrustMapper : IMapper<PizzaBox.Storing.Entities.Crust, PizzaBox.Domain.Models.Crust>
    {
        public Domain.Models.Crust Map(Entities.Crust model)
        {
            Domain.Models.Crust crust = null;
            switch (model.CrustType)
            {
                case Entities.CRUST_TYPE.CheeseStuffed:
                    crust = new CheeseStuffedCrust();
                    break;
                case Entities.CRUST_TYPE.DeepDish:
                    crust = new DeepDishCrust();
                    break;
                case Entities.CRUST_TYPE.Traditional:
                    crust = new TraditionalCrust();
                    break;
                case Entities.CRUST_TYPE.Unknown:
                    // TODO: add logging to these last 2
                default:
                    throw new ArgumentException("CrustMapper ran into an unknown Crust Type when mapping from DB Model to Domain Model");
            }

            if (model.Price.HasValue)
            {
                crust.Price = model.Price.Value;
            }

            return crust;
        }

        public Entities.Crust Map(Domain.Models.Crust model)
        {
            Entities.Crust crust = new Entities.Crust();
            Entities.CRUST_TYPE crustType;
            switch (model)
            {
                case CheeseStuffedCrust:
                    crustType = Entities.CRUST_TYPE.CheeseStuffed;
                    break;
                case DeepDishCrust:
                    crustType = Entities.CRUST_TYPE.DeepDish;
                    break;
                case TraditionalCrust:
                    crustType = Entities.CRUST_TYPE.Traditional;
                    break;
                default:
                    throw new ArgumentException("CrustMapper ran into an unknown type of crust when mapping from Domain Model to DB Model");
            }

            crust.CrustType = crustType;
            crust.Price = model.Price;
            return crust;
        }
    }
}