using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Storing.Entities
{

    public enum SIZE_TYPE
    {
        Small,
        Medium,
        Large
    }

    public class Size
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public SIZE_TYPE SizeType { get; set; }
        public decimal? Price { get; set; }
    }
}