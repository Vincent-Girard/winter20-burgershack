using System;
using System.Collections.Generic;
using System.Data;
using burgershack_winter20.Models;
using Dapper;

namespace burgershack_winter20.Repositories
{
    public class FryRepository
    {
        public readonly IDbConnection _db;

        public FryRepository(IDbConnection db)
        {
            _db = db;
        }
        //NOTE dotnet add package dapper - to be able to communicate with db
        public IEnumerable<Fry> GetAll()
        {
            string sql = "SELECT * FROM fries;";
            return _db.Query<Fry>(sql);
        }

        internal Fry GetById(int id)
        {
            string sql = "SELECT * FROM fries WHERE id = @id;";
            return _db.QueryFirstOrDefault<Fry>(sql, new { id });
        }


        internal Fry Create(Fry newFry)
        {
            string sql = @"
            INSERT INTO fries
            (size, price)
            VALUES
            (@Size, @Price);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newFry);
            newFry.Id = id;
            return newFry;
        }



        internal void Delete(Fry fry)
        {
            string sql = "DELETE FROM fries WHERE id = @Id";
            _db.Execute(sql, fry);
        }

        internal Fry Edit(Fry original)
        {
            string sql = @"
        UPDATE fries
        SET
            size = @Size,
            price = @Price
        WHERE id = @Id;
        SELECT * FROM fries WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Fry>(sql, original);
        }
    }
}