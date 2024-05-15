using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace tgbot.DB
{
    //public class MariaDB
    //{
    //    MySqlConnection mySqlConnection;

    //    private MariaDB()
    //    {
    //        mySqlConnection = new MySqlConnection("server=localhost;port=3306;user=root;password=Masha0325;database=coffeeshop;Character Set=utf8mb4");
    //        OpenConnection();
    //    }

    //    private bool OpenConnection()
    //    {
    //        try
    //        {
    //            mySqlConnection.Open();
    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //            return false;
    //        }
    //    }

    //    public void CloseConnection()
    //    {
    //        try
    //        {
    //            mySqlConnection.Close();
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //        }
    //    }


    //    internal MySqlConnection GetConnection()
    //    {
    //        if (mySqlConnection.State != System.Data.ConnectionState.Open)
    //            if (!OpenConnection())
    //                return null;
    //        return mySqlConnection;
    //    }

    //    static MariaDB instance;
    //    public static MariaDB Instance
    //    {
    //        get
    //        {
    //            if (instance == null)
    //                instance = new MariaDB();
    //            return instance;
    //        }
    //    }
    //    public int GetAutoID(string table)
    //    {
    //        try
    //        {
    //            string sql = "SHOW TABLE STATUS WHERE `Name` = '" + table + "'";
    //            using (var mc = new MySqlCommand(sql, mySqlConnection))
    //            using (var reader = mc.ExecuteReader())
    //            {
    //                if (reader.Read())
    //                    return reader.GetInt32("Auto_increment");
    //            }
    //            return -1;
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //            return -1;
    //        }
    //    }



    //}
}
