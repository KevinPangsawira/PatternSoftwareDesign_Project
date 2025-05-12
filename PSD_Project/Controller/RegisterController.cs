using PSD_Project.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Controller
{
    public class RegisterController
    {
        RegisterHandler registerHandler = new RegisterHandler();

        public string register(string email, string username, string pw, string cpw, string gender, DateTime dob)
        {
            string response = "";
            if (!email.EndsWith("@gmail.com"))
            {
                return "email format must be @gmail.com and must not be empty";
            }
            string isUnique = registerHandler.emailUnique(email);
            if (isUnique.Equals("Email already registered"))
            {
                return isUnique;
            }

            if (username.Length < 3 || username.Length > 25)
            {
                return "Username must be between 3 to 25 characters.";
            }

            if ( !pw.All(char.IsLetterOrDigit) || pw.Length < 8 || pw.Length > 25)
            {
                return "Only contain alphanumeric and must be between 8 to 20 characters";
            }

            if (!pw.Equals(cpw))
            {
                return "Must be the same as password";
            }
            if ( !gender.Equals("Male") && !gender.Equals("Female"))
            {
                return "Gender must be fill";
            }

            if ( dob == DateTime.MinValue || dob >= new DateTime(2010, 1, 1))
            {
                return "You must fill dob and must be earlier than 01/01/2010";
            }

            return registerHandler.registerUser(email, username, pw, gender, dob );
           

        }
    }
}