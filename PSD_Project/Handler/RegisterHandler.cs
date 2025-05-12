using PSD_Project.Model;
using PSD_Project.Repository;
using PSD_Project.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Handler
{
    public class RegisterHandler
    {
        UserRepo userRepo = new UserRepo();
        public string emailUnique(string email)
        {
            string response = userRepo.emailUnique(email);

            return response;
        }


        public string registerUser(string email, string username, string password, string gender, DateTime dob)
        {
           userRepo.createUser(email, username, password, gender, dob); 

            return "success";
        }

        public RegisterHandler()
        {
            
        }
    }
}