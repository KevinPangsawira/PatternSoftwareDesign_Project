using PSD_Project.Handler;
using PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Controller
{
    public class UserController
    {
        //LoginHandler loginHandler = new LoginHandler();
        //RegisterHandler registerHandler = new RegisterHandler();
        UserHandler userHandler = new UserHandler();

        public string register(string email, string username, string pw, string cpw, string gender, DateTime dob)
        {
            string response = "";
            if (!email.EndsWith("@gmail.com"))
            {
                return "email format must be @gmail.com and must not be empty";
            }
            string isUnique = userHandler.emailUnique(email);
            if (isUnique.Equals("Email already registered"))
            {
                return isUnique;
            }

            if (username.Length < 3 || username.Length > 25)
            {
                return "Username must be between 3 to 25 characters.";
            }

            if (!pw.All(char.IsLetterOrDigit) || pw.Length < 8 || pw.Length > 25)
            {
                return "Only contain alphanumeric and must be between 8 to 20 characters";
            }

            if (!pw.Equals(cpw))
            {
                return "Must be the same as password";
            }
            if (!gender.Equals("Male") && !gender.Equals("Female"))
            {
                return "Gender must be fill";
            }

            if (dob == DateTime.MinValue || dob >= new DateTime(2010, 1, 1))
            {
                return "You must fill dob and must be earlier than 01/01/2010";
            }

            return userHandler.registerUser(email, username, pw, gender, dob);


        }

        public string validationLogin(string email, string password)
        {
            string response = "";
            if (email.Equals(""))
            {
                return "Email must be filled";
            }

            if (password.Equals(""))
            {
                return "Password must be filled";
            }

            if (!userHandler.validateEmail(email).Equals(""))
            {
                return userHandler.validateEmail(email);
            }

            if (!userHandler.validatePassword(password).Equals(""))
            {
                return userHandler.validatePassword(password);
            }

            return response;

        }
        public MsUser getUser(string email, string password)
        {
            MsUser user = userHandler.getUser(email, password);

            return user;

        }

        public MsUser getUserById(int id)
        {
            MsUser user = userHandler.getUserById(id);

            return user;

        }
    }
}