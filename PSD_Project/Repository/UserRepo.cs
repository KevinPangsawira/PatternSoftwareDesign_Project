using PSD_Project.Factory;
using PSD_Project.Model;
using PSD_Project.Singleton;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace PSD_Project.Repository
{
    public class UserRepo
    {
        Database1Entities1 db = DatabaseSingleton.GetInstance();
        UserFactory userFactory = new UserFactory();

        public UserRepo() { }

        public void createUser(string email, string username, string pw,
            string gender, DateTime dob)
        {
            MsUser user = userFactory.createUser(email, username, pw, gender, dob);
            db.MsUsers.Add(user);
            db.SaveChanges();
        }

        public string emailUnique(string email)
        {
            string response = "";
            string unique = ( from u in db.MsUsers where u.UserEmail == email select u.UserEmail).FirstOrDefault();
            if (unique != null) { 
                response = "Email already registered";
            }

            return response;
        }

        public MsUser getUser(string email, string password)
        {
            return ( from u in db.MsUsers where u.UserEmail == email && u.UserPassword == password select u).FirstOrDefault();

        }

        public MsUser getUserById(int id)
        {
            return (from u in db.MsUsers where u.UserID == id select u).FirstOrDefault();

        }


        public string checkEmail(string email) {
            string response = "";
            string existEmail = (from u in db.MsUsers where u.UserEmail == email select u.UserEmail).FirstOrDefault();
            if (existEmail == null)
            {
                response = "Email not found";
            }
            return response;
        }

        public string checkPassword( string email,  string pw)
        {
            string response = "";
            string existPassword = (from u in db.MsUsers where u.UserPassword == pw && u.UserEmail == email select u.UserPassword).FirstOrDefault();
            if (existPassword == null)
            {
                response = "Incorrect Password";
            }
            return response;
        }

        public void changePassword(int userId, string newPassword)
        {
            MsUser user = (from x in db.MsUsers
                           where x.UserID == userId
                           select x).FirstOrDefault();

            if (user != null)
            {
                user.UserPassword = newPassword;
            }
            db.SaveChanges();

        }
    }
}