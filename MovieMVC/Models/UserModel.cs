using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieMVC.Entitys;

using System.Data;

namespace MovieMVC.Models
{
    public class UserModel
    {
        public User user = new User();
        public List<User> users = new List<User>();   
    }
    public class UserModelUnique
    {      
        public string Name { get; set; }
        public string Surname { get; set; }
        public int id { get; set; }

        public UserModelUnique fillObject(DataRow row)
        {
            UserModelUnique user = new UserModelUnique();
            user.Name = Convert.ToString(row["Name"]);
            user.Surname = Convert.ToString(row["Surname"]);
            user.id = Convert.ToInt32(row["ID"]);
            return user;
        }
    }
    public class LoginModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
    public class AddUsernModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}