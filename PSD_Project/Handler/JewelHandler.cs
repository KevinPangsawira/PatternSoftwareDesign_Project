using PSD_Project.Model;
using PSD_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Handler
{
    public class JewelHandler
    {
        JewelRepo jewelRepo = new JewelRepo();

        public List<MsJewel> getAllJewel()
        {
            return jewelRepo.getAllJewels();
        }

        public void createJewel(int brandId, int categoryId, string jewelName, int jewelPrice, int jewelReleaseYear)
        {
            jewelRepo.createJewel(brandId, categoryId, jewelName, jewelPrice, jewelReleaseYear);
            
        }

        public Object getJewelById(int brandId)
        {
            return jewelRepo.getJewelById(brandId);
        } 
    }
}