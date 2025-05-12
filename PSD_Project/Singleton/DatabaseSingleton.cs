using PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Singleton
{
    public class DatabaseSingleton
    {
        private static Database1Entities1 db = null;
        public DatabaseSingleton()
        {
            
        }
        public static Database1Entities1 GetInstance()
        {
            if (db == null)
            {
                db = new Database1Entities1();
            }

            return db;
        }
    }
}