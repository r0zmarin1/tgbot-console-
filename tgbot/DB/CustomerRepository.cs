using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tgbot.DB
{
    public class CustomerRepository
    {
        private CustomerRepository()
        {

        }
        static CustomerRepository instance;
        public static CustomerRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new CustomerRepository();
                return instance;
            }
        }
        internal List<Customer> GetCustomer(string sql)
        {

            var result = new List<Customer>();
            var connect = MariaDB.Instance.GetConnection();
            if (connect == null)
                return result;
            using (var mc = new MySqlCommand(sql, connect))
            using (var reader = mc.ExecuteReader())
            {
                Customer customer;
                while (reader.Read())
                {
                    customer = new Customer();
                    result.Add(customer);
                    customer.Id = reader.GetInt32("id");
                    customer.PhoneNumber = reader.GetString("phone_number");
                    customer.Time = reader.GetString("time");
                    customer.Description = reader.GetString("description");

                }
            }

            return result;
        }
        internal void AddEmployee(Customer customer)
        {
            var connect = MariaDB.Instance.GetConnection();
            if (connect == null)
                return;

            int id = MariaDB.Instance.GetAutoID("customer");

            string sql = "INSERT INTO customer VALUES (0, @phone_number, @time, @description)";
            using (var mc = new MySqlCommand(sql, connect))
            {
                mc.Parameters.Add(new MySqlParameter("name", customer.PhoneNumber));
                mc.Parameters.Add(new MySqlParameter("time", customer.Time));
                mc.Parameters.Add(new MySqlParameter("description", customer.Description));
            }
        }
        
    }
}

