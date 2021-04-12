using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Storing.Entities
{
    public enum STORE_TYPE
    {
        NewYork,
        Chicago,
        Unknown
    }

    public class Store
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public STORE_TYPE StoreType { get; set; }
    }
}