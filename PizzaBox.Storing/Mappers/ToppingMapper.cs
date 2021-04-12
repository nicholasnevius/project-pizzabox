using System;

namespace PizzaBox.Storing.Mappers
{
    public class ToppingMapper : IMapper<Entities.Topping, PizzaBox.Domain.Models.Topping>
    {
        public Domain.Models.Topping Map(Entities.Topping model)
        {
            Domain.Models.Topping topping;
            switch (model.ToppingType)
            {
                case Entities.TOPPING_TYPE.Bacon:
                    topping = new Domain.Models.BaconTopping();
                    break;
                case Entities.TOPPING_TYPE.Mushroom:
                    topping = new Domain.Models.MushroomTopping();
                    break;
                case Entities.TOPPING_TYPE.Onion:
                    topping = new Domain.Models.OnionTopping();
                    break;
                case Entities.TOPPING_TYPE.Pepperoni:
                    topping = new Domain.Models.PepperoniTopping();
                    break;
                default:
                    throw new ArgumentException("ToppingMapper encountered unknown topping type when mapping from DB Model to Domain Model");
            }

            topping.Price = model.Price;
            return topping;
        }

        public Entities.Topping Map(Domain.Models.Topping model)
        {
            Entities.TOPPING_TYPE toppingType;
            switch (model)
            {
                case Domain.Models.BaconTopping:
                    toppingType = Entities.TOPPING_TYPE.Bacon;
                    break;
                case Domain.Models.MushroomTopping:
                    toppingType = Entities.TOPPING_TYPE.Mushroom;
                    break;
                case Domain.Models.OnionTopping:
                    toppingType = Entities.TOPPING_TYPE.Onion;
                    break;
                case Domain.Models.PepperoniTopping:
                    toppingType = Entities.TOPPING_TYPE.Pepperoni;
                    break;
                default:
                    throw new ArgumentException("ToppingMapper encountered an unknown type when mapping from Domain Model to DB Model");
            }
            Entities.Topping topping = new Entities.Topping();
            topping.ToppingType = toppingType;
            topping.Price = model.Price;
            return topping;
        }
    }
}