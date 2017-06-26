using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieMVC.Entitys;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using MovieMVC.Models;

namespace MovieMVC.DAL
{
    public static class UserDAL
    {
        public static List<User> GetUsers()
        {

            string request = "SELECT * FROM bddmovie.tb_user";
            DataTable dt = getData(request);
            if (dt.Rows.Count >= 1)
            {
                return new User().fillObject(dt);
            }
            return null;
        }

        internal static User getUserByLoginPassword(string login, string password)
        {

            string request = "SELECT * FROM bddmovie.tb_user where  `Login` ='" + login + "' and `Password` = '" + password + "'";
            DataTable dt = getData(request);
            if (dt != null && dt.Rows.Count != 0)
            {
                return new User().fillObject(dt.Rows[0]);
            }
            return null;
        }

        public static DataTable getData(string request)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlConnection con = connect();
                MySqlCommand cmd = new MySqlCommand(request, con);
                //MySqlDataReader Reader;
                //Reader = cmd.ExecuteReader();           
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                return dt;

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MySqlException test = ex;
                return null;
            }
        }

        internal static bool ModifyUser(UserModelUnique user)
        {
            

            try
            {
                MySqlConnection con = connect();
                string request = "UPDATE bddmovie.tb_user SET  `Name` ='" +  user.Name + "',`Surname` ='"+ user.Surname + "' WHERE `ID` ='" + user.id + "'";
                MySqlCommand cmd = new MySqlCommand(request, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MySqlException test = ex;
                return false;
            }
        }

        internal static UserModelUnique getUserbyID(int id)
        {
            try
            {

                string request = "SELECT * FROM bddmovie.tb_user where  `ID` ='" + id  + "'";
                DataTable dt = getData(request);
                if (dt != null && dt.Rows.Count != 0)
                {
                    return new UserModelUnique().fillObject(dt.Rows[0]);
                }
                return null;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MySqlException test = ex;
                return null;
            }
        }

        private static MySqlConnection connect()
        {
            MySqlConnection con = new MySqlConnection();
            con = new MySql.Data.MySqlClient.MySqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;
            con.Open();
            return con;
        }

        internal static void Adduser(AddUsernModel user)
        {
            MySqlConnection con = connect();
            string req = "INSERT INTO `bddmovie`.`tb_user`(`Name`,`Surname`,`Login`,`Password`) VALUES ('" + user.Name + "','" + user.Surname + "','" + user.Login + "','" + user.Password + "');";

            MySqlCommand cmd = new MySqlCommand(req, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}


