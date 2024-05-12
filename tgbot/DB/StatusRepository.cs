using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tgbot.DB
{
    public class StatusRepository
    {
        private StatusRepository()
        {

        }
        static StatusRepository instance;
        public static StatusRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new StatusRepository();
                return instance;
            }
        }

        internal List<Status> GetStatus()
        {
            List<Status> result = new List<Status>();
            var connect = MariaDB.Instance.GetConnection();
            if (connect == null)
                return result;

            string sql = "SELECT title FROM status";
            using (var mc = new MySqlCommand(sql, connect))
            using (var reader = mc.ExecuteReader())
            {
                while (reader.Read())
                {
                    var status = new Status
                    {
                        Id = reader.GetInt32("id"),
                        Title = reader.GetString("title")
                    };
                    result.Add(status);
                }
            }
            return result;
        }
    }
}
