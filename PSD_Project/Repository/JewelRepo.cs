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

        public void createJewel(string jewelName, int categoryId, int brandId,int jewelPrice, int jewelReleaseYear)
        {
            MsJewel jewel = jewelFactory.createJewel(jewelName, categoryId, brandId, jewelPrice, jewelReleaseYear);
            db.MsJewels.Add(jewel);
            db.SaveChanges();
        }

        //public Object getJewelById(int brandId)
        //{

        //    var jewel = (from x in db.MsJewels
        //                  where x.JewelID == brandId
        //                  select new
        //                  {
        //                      JewelName = x.JewelName,
        //                      CategoryName = x.MsCategory.CategoryName,
        //                      BrandName = x.MsBrand.BrandName,
        //                      BrandCountry = x.MsBrand.BrandCountry,
        //                      BrandClass = x.MsBrand.BrandClass,
        //                      JewelPrice = x.JewelPrice,
        //                      JewelReleaseYear = x.JewelReleaseYear
        //                  }).FirstOrDefault();

        //    return jewel;

        //}

        public MsJewel getJewelById(int jewelId)
        {
            return db.MsJewels
                     .Include("MsBrand")
                     .Include("MsCategory")
                     .FirstOrDefault(x => x.JewelID == jewelId);
        }

        public void removeJewel(int id)
        {
            MsJewel jewel = db.MsJewels.Find(id);
            db.MsJewels.Remove(jewel);
            db.SaveChanges() ;
        }

        public List<MsCategory> getCategoryList()
        {
            return db.MsCategories.ToList();
        }

        public List<MsBrand> getBrandList()
        {
            return db.MsBrands.ToList();
        }

        public void editJewel(int id, string jewelName, int categoryId, int brandId, int jewelPrice, int jewelReleaseYear)
        {
            MsJewel jewel = db.MsJewels.Find(id);
            jewel.JewelName = jewelName;
            jewel.CategoryID = categoryId;
            jewel.BrandID = brandId;
            jewel.JewelPrice = jewelPrice;
            jewel.JewelReleaseYear = jewelReleaseYear;
            db.SaveChanges();
        }
    }
}