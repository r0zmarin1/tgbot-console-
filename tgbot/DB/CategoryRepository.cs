using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tgbot.DB
{
    public class CategoryRepository
    {
        private CategoryRepository()
        {

        }
        static CategoryRepository instance;
        public static CategoryRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoryRepository();
                return instance;
            }
        }

        internal List<Category> GetCategory()
        {
            List<Category> result = new List<Category>();
            var connect = MariaDB.Instance.GetConnection();
            if (connect == null)
                return result;

            string sql = "SELECT title FROM category";
            using (var mc = new MySqlCommand(sql, connect))
            using (var reader = mc.ExecuteReader())
            {
                while (reader.Read())
                {
                    var category = new Category
                    {
                        Id = reader.GetInt32("id"),
                        Title = reader.GetString("title"),
                    };
                    result.Add(category);
                }
            }
            return result;
        }
    }
}
