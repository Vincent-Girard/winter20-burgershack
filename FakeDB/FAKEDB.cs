using System.Collections.Generic;
using burgershack_winter20.Models;

namespace burgershack_winter20.FakeDB
{
    public static class FAKEDB
    {
        public static List<Burger> Burgers { get; set; } = new List<Burger>();

        public static List<Drink> Drinks { get; set; } = new List<Drink>();

        public static List<Fry> Fries { get; set; } = new List<Fry>();
    }
}