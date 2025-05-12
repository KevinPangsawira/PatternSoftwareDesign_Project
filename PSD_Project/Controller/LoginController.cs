using PSD_Project.Handler;
using PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace PSD_Project.Controller
{
    public class LoginController
    {
        LoginHandler loginHandler = new LoginHandler();


        public string validationLogin(string email, string password)
        {
            string response = "";
            if (email.Equals("")) {
                return "Email must be filled";
            }

            if (password.Equals(""))
            {
                return "Password must be filled";
            }

            if (!loginHandler.validateEmail(email).Equals(""))
            {
                return loginHandler.validateEmail(email);
            }
           
            if (!loginHandler.validatePassword(password).Equals(""))
            { 
                return loginHandler.validatePassword(password);
            }

            return response;

        }
        public MsUser getUser(string email, string password)
        {
            MsUser user = loginHandler.getUser(email, password);

            return user;
            
        }

        public MsUser getUserById(int id)
        {
            MsUser user = loginHandler.getUserById(id);

            return user;

        }
    }
}