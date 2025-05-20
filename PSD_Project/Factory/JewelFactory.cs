using PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Factory
{
    public class JewelFactory
    {
        public MsJewel createJewel(string jewelName, int categoryId, int brandId, int jewelPrice, int jewelReleaseYear)
        {
            MsJewel jewel = new MsJewel();

            jewel.JewelName = jewelName;
            jewel.CategoryID = categoryId;
            jewel.BrandID = brandId;
            jewel.JewelPrice = jewelPrice;
            jewel.JewelReleaseYear = jewelReleaseYear;
   

            return jewel;
        }
    }
}