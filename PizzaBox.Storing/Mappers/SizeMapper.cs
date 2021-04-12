using System;

namespace PizzaBox.Storing.Mappers
{
    public class SizeMapper : IMapper<PizzaBox.Storing.Entities.Size, PizzaBox.Domain.Models.Size>
    {
        public Domain.Models.Size Map(Entities.Size model)
        {
            Domain.Models.Size size;
            switch (model.SizeType)
            {
                case Entities.SIZE_TYPE.Small:
                    size = new Domain.Models.SmallSize();
                    break;
                case Entities.SIZE_TYPE.Medium:
                    size = new Domain.Models.MediumSize();
                    break;
                case Entities.SIZE_TYPE.Large:
                    size = new Domain.Models.LargeSize();
                    break;
                default:
                    throw new ArgumentException("SizeMapper encountered an unknown type when mapping from DB Model to Domain Model");
            }

            if (model.Price.HasValue)
            {
                size.Price = model.Price.Value;
            }
            return size;
        }

        public Entities.Size Map(Domain.Models.Size model)
        {
            Entities.SIZE_TYPE sizeType;
            switch (model)
            {
                case Domain.Models.SmallSize:
                    sizeType = Entities.SIZE_TYPE.Small;
                    break;
                case Domain.Models.MediumSize:
                    sizeType = Entities.SIZE_TYPE.Medium;
                    break;
                case Domain.Models.LargeSize:
                    sizeType = Entities.SIZE_TYPE.Large;
                    break;
                default:
                    throw new ArgumentException("SizeMapper encountered an unknown type when mapping from Domain Model to DB Model");
            }
            Entities.Size size = new Entities.Size();
            size.SizeType = sizeType;
            size.Price = model.Price;
            return size;
        }
    }
}