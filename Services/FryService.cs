using System;
using System.Collections.Generic;
using burgershack_winter20.FakeDB;
using burgershack_winter20.Models;
using burgershack_winter20.Repositories;

namespace burgershack_winter20.Services
{
    public class FryService
    {

        private readonly FryRepository _repo;

        public FryService(FryRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Fry> Get()
        {
            return _repo.GetAll();
        }

        internal Fry Get(int id)
        {
            Fry fry = _repo.GetById(id);
            if (fry == null)
            {
                throw new Exception("invalid Id");
            }
            return fry;
        }

        internal Fry Create(Fry newFry)
        {
            return _repo.Create(newFry);
        }

        internal Fry Edit(Fry editFry)
        {
            Fry original = Get(editFry.Id);

            original.Size = editFry.Size != null ? editFry.Size : original.Size;
            original.Price = editFry.Price > 0 ? editFry.Price : original.Price;

            return _repo.Edit(original);


        }

        internal Fry Delete(int id)
        {

            Fry fry = Get(id);
            _repo.Delete(fry);
            return fry;
        }
    }
}