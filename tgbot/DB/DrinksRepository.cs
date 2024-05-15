using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace tgbot.DB
{
    //public class DrinksRepository
    //{
    //    private DrinksRepository()
    //    {

    //    }

    //    static DrinksRepository instance;
    //    public static DrinksRepository Instance
    //    {
    //        get
    //        {
    //            if (instance == null)
    //                instance = new DrinksRepository();
    //            return instance;
    //        }
    //    }
    //    internal List<Drinks> GetDrinks(string sql)
    //    {
    //        List<Drinks> result = new List<Drinks>();
    //        var connect = MariaDB.Instance.GetConnection();
    //        if (connect == null)
    //            return result;

    //        sql = "SELECT * FROM drinks";
    //        using (var mc = new MySqlCommand(sql, connect))
    //        using (var reader = mc.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                var drinks = new Drinks
    //                {
    //                    Id = reader.GetInt32("id"),
    //                    Title = reader.GetString("title"),
    //                    Description = reader.GetString("description"),
    //                    Price = reader.GetDecimal("price"),
    //                    Size = reader.GetString("size"),
    //                    Id_category = reader.GetInt32("id_category"),
    //                };
    //                result.Add(drinks);
    //            }
    //        }
    //        return result;
    //    }
    //}
}
