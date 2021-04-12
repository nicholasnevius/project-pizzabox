using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Storing.Entities
{
    public enum CRUST_TYPE
    {
        CheeseStuffed,
        DeepDish,
        Traditional,
        Unknown
    }

    public class Crust
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public CRUST_TYPE CrustType { get; set; }
        public decimal? Price { get; set; }
    }
}