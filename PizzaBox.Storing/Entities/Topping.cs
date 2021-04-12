using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Storing.Entities
{
    public enum TOPPING_TYPE
    {
        Bacon,
        Mushroom,
        Onion,
        Pepperoni
    }
    public class Topping
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public TOPPING_TYPE ToppingType { get; set; }
        public decimal? Price { get; set; }
    }
}