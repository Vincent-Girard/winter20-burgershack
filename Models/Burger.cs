using System;
using System.ComponentModel.DataAnnotations;

namespace burgershack_winter20.Models
{
  public class Burger
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    public double Price { get; set; }
    public string Description { get; set; }


    public Burger()
    {

    }
    public Burger(string name, double price, string description)
    {
      Name = name;
      Price = price;
      Description = description;
    }
  }
}