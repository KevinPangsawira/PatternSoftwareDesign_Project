using PSD_Project.Handler;
using PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Controller
{
    public class JewelController
    {
        JewelHandler jewelHandler = new JewelHandler();

        public List<MsJewel> getAllJewels()
        {
            List<MsJewel> getAllJewels = jewelHandler.getAllJewel();
            
            return getAllJewels;
        }

        //public void createJewel(int brandId, int categoryId, string jewelName, int jewelPrice, int jewelReleaseYear)
        //{
        //    jewelHandler.createJewel(brandId, categoryId, jewelName, jewelPrice, jewelReleaseYear);
            
        //}

        public Object getJewelById(int brandId)
        {
            return jewelHandler.getJewelById(brandId);
        }
    }
}