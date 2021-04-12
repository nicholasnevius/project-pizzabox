using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace PizzaBox.Storing.Entities
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public Store Store { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public List<Pizza> Pizzas { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public DateTime TimePlaced { get; set; }
    }
}