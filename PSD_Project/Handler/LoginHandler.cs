using PSD_Project.Model;
using PSD_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace PSD_Project.Handler
{
    public class LoginHandler
    {
        UserRepo userRepo = new UserRepo();
        public MsUser getUser( string email, string password)
        {
            MsUser user = userRepo.getUser(email, password);

            return user;
            
        }
        public MsUser getUserById(int id)
        {
            MsUser user = userRepo.getUserById(id);

            return user;

        }
        public string validateEmail(string email){
            return userRepo.checkEmail(email);
        }
        public string validatePassword(string pw)
        {
            return userRepo.checkPassword(pw);
        }
    }
}