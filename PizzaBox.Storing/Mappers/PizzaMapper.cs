using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Entities;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Mappers;
using System;
using System.Collections.Generic;

namespace PizzaBox.Storing.Mappers
{
    public class PizzaMapper : IMapper<Entities.Pizza, PizzaBox.Domain.Abstracts.APizza>
    {
        private CrustMapper crustMapper = new CrustMapper();
        private SizeMapper sizeMapper = new SizeMapper();
        private ToppingMapper toppingMapper = new ToppingMapper();

        public APizza Map(Pizza model)
        {
            APizza pizza;
            switch (model.PizzaType)
            {
                case Entities.PIZZA_TYPE.Meat:
                    pizza = new MeatPizza();
                    break;
                case Entities.PIZZA_TYPE.Vegan:
                    pizza = new VeganPizza();
                    break;
                case Entities.PIZZA_TYPE.Custom:
                    pizza = new CustomPizza();
                    break;
                default:
                    throw new ArgumentException("PizzaMapper encountered an unknown type when mapping from DB Model to Domain Model");
            }

            pizza.Crust = crustMapper.Map(model.Crust);
            pizza.Size = sizeMapper.Map(model.Size);
            List<Domain.Models.Topping> toppings = new List<Domain.Models.Topping>();
            model.Toppings.ForEach(topping => toppings.Add(toppingMapper.Map(topping)));
            pizza.Toppings = toppings;
            //pizza.Price = model.Price;
            return pizza;
        }

        public Pizza Map(APizza model)
        {
            PIZZA_TYPE pizzaType;
            switch (model)
            {
                case MeatPizza:
                    pizzaType = PIZZA_TYPE.Meat;
                    break;
                case VeganPizza:
                    pizzaType = PIZZA_TYPE.Vegan;
                    break;
                case CustomPizza:
                    pizzaType = PIZZA_TYPE.Custom;
                    break;
                default:
                    throw new ArgumentException("PizzaMapper encountered unknown type when mapping from Domain Model to DB Model");
            }
            Pizza pizza = new Pizza();
            pizza.PizzaType = pizzaType;
            pizza.Crust = crustMapper.Map(model.Crust);
            pizza.Size = sizeMapper.Map(model.Size);
            List<Entities.Topping> toppings = new List<Entities.Topping>();
            model.Toppings.ForEach(topping => toppings.Add(toppingMapper.Map(topping)));
            pizza.Toppings = toppings;
            pizza.Price = model.Price;
            return pizza;
        }
    }
}