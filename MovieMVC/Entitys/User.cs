using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace MovieMVC.Entitys
{
    public class User
    {
        public User()
        {

        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int? UserID { get; set; }

        public User fillObject(DataRow row)
        {
            User user = new User();
            user.Name = Convert.ToString(row["Name"]);
            user.Surname = Convert.ToString(row["Surname"]);
            user.UserID = Convert.ToInt32(row["ID"]);

            return user;
        }


        public List<User> fillObject(DataTable dt)
        {
            List<User> Users = new List<User>();
            foreach (DataRow row in dt.Rows)
            {
                User user = new User();
                user.Name = Convert.ToString(row["Name"]);
                user.Surname = Convert.ToString(row["Surname"]);
                user.UserID = Convert.ToInt32(row["ID"]);
                Users.Add(user);
            }
            return Users;
        }
    }



}