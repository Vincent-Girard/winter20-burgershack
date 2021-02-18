using System.Collections.Generic;
using burgershack_winter20.Models;

namespace burgershack_winter20.FakeDB
{
  public static class FAKEDB
  {
    public static List<Burger> Burgers { get; set; } = new List<Burger>();
  }
}