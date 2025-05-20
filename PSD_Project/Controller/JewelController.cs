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

        public string createJewel(string jewelName, int categoryId, int brandId, string jewelPriceS, string jewelReleaseYearS)
        {
            if (jewelName.Length < 3 || jewelName.Length > 25)
            {
                return "Must be between 3 to 25 characters";
            }
            if (categoryId == 0)
            {
                return "You must choose jewel category";
            }
            if (brandId == 0)
            {
                return "You must choose jewel brand";
            }

            int jewelPrice;
            if (!int.TryParse(jewelPriceS, out jewelPrice))
            {
                return "Price must be a number";
            }
            if (jewelPrice <= 25)
            {
                return "Must be more than $25";
            }

            int jewelReleaseYear;
            if (!int.TryParse(jewelReleaseYearS, out jewelReleaseYear))
            {
                return "Year must be a number";
            }

            jewelPrice = int.Parse(jewelPriceS);
            jewelReleaseYear = int.Parse(jewelReleaseYearS);

            if (jewelReleaseYear >= DateTime.Now.Year)
            {
                return "Must be less than current year";
            }


            return jewelHandler.createJewel(jewelName, categoryId, brandId, jewelPrice, jewelReleaseYear);
        }

        public MsJewel getJewelById(int brandId)
        {
            MsJewel jewel = jewelHandler.getJewelById(brandId);
            //#if ( jewel == null) return null;
            return jewel;
        }

        public string editJewel(int id, string jewelName, int categoryId, int brandId, string jewelPriceS, string jewelReleaseYearS)
        {
            if (jewelName.Length < 3 || jewelName.Length > 25)
            {
                return "Must be between 3 to 25 characters";
            }
            if (categoryId == 0)
            {
                return "You must choose jewel category";
            }
            if (brandId == 0)
            {
                return "You must choose jewel brand";
            }

            int jewelPrice;
            if (!int.TryParse(jewelPriceS, out jewelPrice))
            {
                return "Price must be a number";
            }
            if (jewelPrice <= 25)
            {
                return "Must be more than $25";
            }

            int jewelReleaseYear;
            if (!int.TryParse(jewelReleaseYearS, out jewelReleaseYear))
            {
                return "Year must be a number";
            }

            jewelPrice = int.Parse(jewelPriceS);
            jewelReleaseYear = int.Parse(jewelReleaseYearS);

            if (jewelReleaseYear >= DateTime.Now.Year)
            {
                return "Must be less than current year";
            }
            return jewelHandler.editJewel(id, jewelName, categoryId, brandId, jewelPrice, jewelReleaseYear);
        }

        public void removeJewel(int id)
        {
            jewelHandler.removeJewel(id);
        }

        public List<MsCategory> getCategories()
        {
            return jewelHandler.getAllCategories();
        }

        public List<MsBrand> getBrands()
        {
            return jewelHandler.getAllBrands();
        }



        public void addToCart(int userId, int jewelId)
        {
            jewelHandler.addToCart(userId, jewelId);

        }

        public List<Cart> getCarts(int userId)
        {
            return jewelHandler.GetCarts(userId);
        }

        public string updateQuantity(int userId, int jewelId, string quantityS)
        {
            int quantityInt;
            if (quantityS.Length == 0)
            {
                return "Quantity must be filled";
            }

            if (!int.TryParse(quantityS, out quantityInt))
            {
                return "Quantity must be a number";
            }

            quantityInt = int.Parse(quantityS);
            if (quantityInt == 0)
            {
                return "Quantity must be more than 0";
            }

            return jewelHandler.updateQuantity(userId, jewelId, quantityInt);
        }

        public void deleteCartOnly1(int userId, int jewelId)
        {
            jewelHandler.deleteCartOnly1(userId, jewelId);
        }

        public int getTotalPrice(int userId)
        {
            return jewelHandler.getTotalPrice(userId);
        }

        public void removeAllCart(int userId)
        {
            jewelHandler.removeAllCart(userId);
        }
    }
}