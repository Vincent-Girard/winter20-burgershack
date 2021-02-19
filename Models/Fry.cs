using System;
using System.ComponentModel.DataAnnotations;

namespace burgershack_winter20.Models
{
    public class Fry
    {
        public int Id { get; set; }
        [Required]
        public string Size { get; set; }

        public double Price { get; set; }



        public Fry()
        {

        }
        public Fry(string size, double price)
        {
            Size = size;
            Price = price;
        }
    }
}