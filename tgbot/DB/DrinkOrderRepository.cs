using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tgbot.DB
{
    public class DrinkOrderRepository
    {
        private DrinkOrderRepository()
        {

        }

        static DrinkOrderRepository instance;
        public static DrinkOrderRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new DrinkOrderRepository();
                return instance;
            }
        }

        internal IEnumerable<DrinkOrder> GetAllDrinkOrders(string sql)
        {
            var result = new List<DrinkOrder>();
            var connect = MariaDB.Instance.GetConnection();
            if (connect == null)
                return result;
            using (var mc = new MySqlCommand(sql, connect))
            using (var reader = mc.ExecuteReader())
            {
                DrinkOrder order;
                while (reader.Read())
                {
                    order = new DrinkOrder();
                    result.Add(order);
                    order.Id = reader.GetInt32("id");
                    order.Id_status = reader.GetInt32("id_status");
                    order.Id_customer = reader.GetInt32("id_customer");

                }
            }
            return result;
        }
    }
}
