using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tgbot.DB
{
    //public class DrinkOrderRepository
    //{
    //    private DrinkOrderRepository()
    //    {

    //    }

    //    static DrinkOrderRepository instance;
    //    public static DrinkOrderRepository Instance
    //    {
    //        get
    //        {
    //            if (instance == null)
    //                instance = new DrinkOrderRepository();
    //            return instance;
    //        }
    //    }

    //    internal IEnumerable<DrinkOrder> GetAllDrinkOrders(string sql)
    //    {
    //        var result = new List<DrinkOrder>();
    //        var connect = MariaDB.Instance.GetConnection();
    //        if (connect == null)
    //            return result;
    //        using (var mc = new MySqlCommand(sql, connect))
    //        using (var reader = mc.ExecuteReader())
    //        {

    //            while (reader.Read())
    //            {
    //                DrinkOrder order = new DrinkOrder
    //                {
    //                    Date = reader.GetDateTime("date"),
    //                    Id = reader.GetInt32("id"),
    //                    Time = reader.GetString("time"),
    //                    Description = reader.GetString("description"),
    //                    Status = reader.GetString("status"),
    //                    Customer = new Customer
    //                    {
    //                        Id = reader.GetInt32("cid"),
    //                        PhoneNumber = reader.GetString("phone_number")
    //                    },
    //                    Id_customer = reader.GetInt32("cid"),
    //                    //Id_status = reader.GetInt32("sid"),
    //                    //Status = new Status
    //                    //{
    //                    //    Title = reader.GetString("title"),
    //                    //    Id = reader.GetInt32("sid"),
    //                    //}
    //                };
    //                result.Add(order);
    //            }
    //        }
    //        return result;
    //    }
    //    internal void EditStatus(DrinkOrder selectedDrinkOrder)
    //    {
    //        var connect = MariaDB.Instance.GetConnection();
    //        if (connect == null)
    //            return;

    //        string sql = "UPDATE DrinkOrder SET status = @status WHERE Id = " + selectedDrinkOrder.Id;
    //        using (var mc = new MySqlCommand(sql, connect))
    //        {
    //            mc.Parameters.Add(new MySqlParameter("title", selectedDrinkOrder.Status));
    //            mc.ExecuteNonQuery();
    //        }
    //    }

    //    internal static List<string> GetDrinksInfo(DrinkOrder selectedDrinkOrder, out decimal totalPrice)
    //    {
    //        totalPrice = 0;
    //        string sql = "SELECT c.amount, d.title, d.price, d.size, c1.title as category FROM crossdrinksorderdrinks c LEFT outer JOIN drinks d ON c.id_drinks = d.id  LEFT outer JOIN category c1 ON c1.id = d.id_category WHERE c.id_drinksOrder = " + selectedDrinkOrder.Id;

    //        var result = new List<string>();
    //        var connect = MariaDB.Instance.GetConnection();
    //        if (connect == null)
    //            return result;
    //        using (var mc = new MySqlCommand(sql, connect))
    //        using (var reader = mc.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                totalPrice += reader.GetDecimal("price");
    //                string category = "";
    //                if (!reader.IsDBNull("category"))
    //                    category = reader.GetString("category");
    //                result.Add($"{category} {reader.GetString("title")} {reader.GetString("size")} кол-во: {reader.GetInt32("amount")} ");
    //            }
    //        }
    //        return result;
    //    }

    //    internal static List<string> GetAddsInfo(DrinkOrder selectedDrinkOrder, out decimal totalPrice)
    //    {
    //        totalPrice = 0;
    //        string sql = "SELECT c.amount, a.title, a.price FROM crossaddsdrinkorder c LEFT outer JOIN adds a ON c.id_adds = a.id WHERE c.id_drinksOrder = " + selectedDrinkOrder.Id;

    //        var result = new List<string>();
    //        var connect = MariaDB.Instance.GetConnection();
    //        if (connect == null)
    //            return result;
    //        using (var mc = new MySqlCommand(sql, connect))
    //        using (var reader = mc.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                totalPrice += reader.GetDecimal("price");
    //                result.Add($"{reader.GetString("title")} кол-во: {reader.GetInt32("amount")} ");
    //            }
    //        }
    //        return result;
    //    }
    //}
}
