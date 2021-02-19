using System;
using System.Collections.Generic;
using System.Data;
using burgershack_winter20.Models;
using Dapper;

namespace burgershack_winter20.Repositories
{
    public class DrinkRepository
    {
        public readonly IDbConnection _db;

        public DrinkRepository(IDbConnection db)
        {
            _db = db;
        }
        //NOTE dotnet add package dapper - to be able to communicate with db
        public IEnumerable<Drink> GetAll()
        {
            string sql = "SELECT * FROM drinks;";
            return _db.Query<Drink>(sql);
        }

        internal Drink GetById(int id)
        {
            string sql = "SELECT * FROM drinks WHERE id = @id;";
            return _db.QueryFirstOrDefault<Drink>(sql, new { id });
        }


        internal Drink Create(Drink newDrink)
        {
            string sql = @"
            INSERT INTO drinks
            (size, price, description)
            VALUES
            (@Size, @Price, @Description);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newDrink);
            newDrink.Id = id;
            return newDrink;
        }



        internal void Delete(Drink drink)
        {
            string sql = "DELETE FROM drinks WHERE id = @Id";
            _db.Execute(sql, drink);
        }

        internal Drink Edit(Drink original)
        {
            string sql = @"
        UPDATE drinks
        SET
            size = @Size,
            price = @Price,
            description = @Description,
        WHERE id = @Id;
        SELECT * FROM burgers WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Drink>(sql, original);
        }
    }
}