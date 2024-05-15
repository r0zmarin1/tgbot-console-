using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tgbot.DB
{
    //public class AddsRepository
    //{
    //    private AddsRepository()
    //    {

    //    }
    //    static AddsRepository instance;
    //    public static AddsRepository Instance
    //    {
    //        get
    //        {
    //            if (instance == null)
    //                instance = new AddsRepository();
    //            return instance;
    //        }
    //    }

    //    internal List<Adds> GetAdds()
    //    {
    //        List<Adds> result = new List<Adds>();
    //        var connect = MariaDB.Instance.GetConnection();
    //        if (connect == null)
    //            return result;

    //        string sql = "SELECT * FROM adds";
    //        using (var mc = new MySqlCommand(sql, connect))
    //        using (var reader = mc.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                var adds = new Adds
    //                {
    //                    Id = reader.GetInt32("id"),
    //                    Title = reader.GetString("title"),
    //                    Price = reader.GetDecimal("price"),
    //                    Description = reader.GetString("description")
    //                };
    //                result.Add(adds);
    //            }
    //        }
    //        return result;
    //    }
    //}
}
