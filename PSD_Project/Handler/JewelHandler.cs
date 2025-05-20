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
        CartRepo cartRepo = new CartRepo();

        public List<MsJewel> getAllJewel()
        {
            return jewelRepo.getAllJewels();
        }

        public string createJewel(string jewelName, int categoryId, int brandId, int jewelPrice, int jewelReleaseYear)
        {
            jewelRepo.createJewel(jewelName, categoryId, brandId, jewelPrice, jewelReleaseYear);
            return "success";
        }

        public MsJewel getJewelById(int brandId)
        {
            return jewelRepo.getJewelById(brandId);
        }

        public string editJewel(int id, string jewelName, int categoryId, int brandId, int jewelPrice, int jewelReleaseYear)
        {
            jewelRepo.editJewel(id, jewelName, categoryId, brandId, jewelPrice, jewelReleaseYear);
            return "success";
        }

        public void removeJewel(int id)
        {
            jewelRepo.removeJewel(id);
        }

        public List<MsCategory> getAllCategories()
        {
            return jewelRepo.getCategoryList();


        }
        public List<MsBrand> getAllBrands()
        {
            return jewelRepo.getBrandList();
        }


        //Cart
        public List<Cart> GetCarts(int userId)
        {
            return cartRepo.getCartAll(userId);
        }


        public void addToCart(int userId, int jewelId)
        {
            cartRepo.addToCart(userId, jewelId);
        }
        
        public string updateQuantity(int userId, int jewelId, int quantity)
        {
            cartRepo.updateQuantity(userId, jewelId, quantity);
            return "success";
        }

        public void deleteCartOnly1(int userId, int jewelId)
        {
            cartRepo.deleteCartOnly1(userId, jewelId);
        }

        public int getTotalPrice(int userId)
        {
            return cartRepo.getTotalPrice(userId);
        }

        public void removeAllCart(int userId)
        {
            cartRepo.removeAllCart(userId);
        }
    }

}