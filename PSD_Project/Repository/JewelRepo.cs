using PSD_Project.Factory;
using PSD_Project.Model;
using PSD_Project.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Repository
{
    public class JewelRepo
    {
        Database1Entities1 db = DatabaseSingleton.GetInstance();
        JewelFactory jewelFactory = new JewelFactory();
        public List<MsJewel> getAllJewels()
        {
            return db.MsJewels.ToList();
        }

        public void createJewel(int brandId, int categoryId, string jewelName, int jewelPrice, int jewelReleaseYear)
        {
            MsJewel jewel = jewelFactory.createJewel(brandId, categoryId, jewelName, jewelPrice, jewelReleaseYear);
            db.MsJewels.Add(jewel);
            db.SaveChanges();
        }

        public Object getJewelById(int brandId)
        {

            var jewel = (from j in db.MsJewels
                          where j.JewelID == brandId
                          select new
                          {
                              JewelName = j.JewelName,
                              CategoryName = j.MsCategory.CategoryName,
                              BrandName = j.MsBrand.BrandName,
                              BrandCountry = j.MsBrand.BrandCountry,
                              BrandClass = j.MsBrand.BrandClass,
                              JewelPrice = j.JewelPrice,
                              JewelReleaseYear = j.JewelReleaseYear
                          }).FirstOrDefault();

            return jewel;
           
        }
    }
}