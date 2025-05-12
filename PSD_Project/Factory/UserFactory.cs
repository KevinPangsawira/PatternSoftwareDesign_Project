using PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Factory
{
    public class UserFactory
    {
        public static MsUser createUser(string email, string username, string pw,
            string gender, DateTime dob)
        {
            MsUser user = new MsUser();
            user.UserEmail = email;
            user.UserName = username;
            user.UserPassword = pw;
            user.UserGender = gender;
            user.UserDOB = dob;
            user.UserRole = "Customer";

            return user;
        }
    }
}