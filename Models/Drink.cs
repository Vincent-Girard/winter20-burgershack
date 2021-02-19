using System;
using System.ComponentModel.DataAnnotations;

namespace burgershack_winter20.Models
{
    public class Drink
    {
        public int Id { get; set; }
        [Required]
        public string Size { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }



        public Drink()
        {

        }
        public Drink(string size, double price, string description)
        {
            Size = size;
            Price = price;
            Description = description;
        }
    }
}