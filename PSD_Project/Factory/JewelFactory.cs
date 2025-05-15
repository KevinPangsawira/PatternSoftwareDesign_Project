using PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Factory
{
    public class JewelFactory
    {
        public MsJewel createJewel(int brandId, int categoryId, string jewelName, int jewelPrice, int jewelReleaseYear)
        {
            MsJewel jewel = new MsJewel();

            jewel.BrandID = brandId;
            jewel.CategoryID = categoryId;
            jewel.JewelName = jewelName;
            jewel.JewelPrice = jewelPrice;
            jewel.JewelReleaseYear = jewelReleaseYear;
   

            return jewel;
        }
    }
}