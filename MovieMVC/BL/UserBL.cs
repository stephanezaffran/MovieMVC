using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieMVC.Entitys;
using System.Security.Cryptography;
using System.Text;
using MovieMVC.Models;
using MovieMVC.DAL;

namespace MovieMVC.BL
{
    public class UserBL
    {
        public static List<User> getUsers()
        {
            List<User> users = UserDAL.GetUsers();
            return users;
        }
        

        public static String HashMD5(String input)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            Byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            Byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        internal static User getUserByLoginPassword(string login, string password)
        {
            User usr = UserDAL.getUserByLoginPassword(login, password);
            //string MD5 = HashMD5(password);
            return usr;
        }

        internal static void AddUser(AddUsernModel user)
        {
            DAL.UserDAL.Adduser(user);           
        }

        internal static UserModelUnique getUserbyID(int id)
        {
           return UserDAL.getUserbyID(id);
        }

        internal static void ModifyUser(UserModelUnique user)
        {
            UserDAL.ModifyUser(user);
        }

        //public static string getHash(string password)
        //{
        //    SHA1 sha = new SHA1CryptoServiceProvider();
        //    byte[] hashData = sha.ComputeHash(Encoding.UTF8.GetBytes(password));


        //    //create new instance of StringBuilder to save hashed data
        //    StringBuilder returnValue = new StringBuilder();

        //    //loop for each byte and add it to StringBuilder
        //    for (int i = 0; i < hashData.Length; i++)
        //    {
        //        returnValue.Append(hashData[i].ToString());
        //    }
        //    // return hexadecimal string
        //    return returnValue.ToString();

        //}

        private bool ValidateSHA1HashData(string inputData, string storedHashData)
        {
            //hash input text and save it string variable
            string getHashInputData = HashMD5(inputData);

            if (string.Compare(getHashInputData, storedHashData) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}