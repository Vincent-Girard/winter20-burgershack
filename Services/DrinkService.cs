using System;
using System.Collections.Generic;
using burgershack_winter20.FakeDB;
using burgershack_winter20.Models;
using burgershack_winter20.Repositories;

namespace burgershack_winter20.Services
{
    public class DrinkService
    {

        private readonly DrinkRepository _repo;

        public DrinkService(DrinkRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Drink> Get()
        {
            return _repo.GetAll();
        }

        internal Drink Get(int id)
        {
            Drink drink = _repo.GetById(id);
            if (drink == null)
            {
                throw new Exception("invalid Id");
            }
            return drink;
        }

        internal Drink Create(Drink newDrink)
        {
            return _repo.Create(newDrink);
        }

        internal Drink Edit(Drink editDrink)
        {
            Drink original = Get(editDrink.Id);

            original.Size = editDrink.Size != null ? editDrink.Size : original.Size;
            original.Description = editDrink.Description != null ? editDrink.Description : original.Description;
            original.Price = editDrink.Price > 0 ? editDrink.Price : original.Price;

            return _repo.Edit(original);


        }

        internal Drink Delete(int id)
        {

            Drink drink = Get(id);
            _repo.Delete(drink);
            return drink;
        }
    }
}