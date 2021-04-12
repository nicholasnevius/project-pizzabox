using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Storing.Entities
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}