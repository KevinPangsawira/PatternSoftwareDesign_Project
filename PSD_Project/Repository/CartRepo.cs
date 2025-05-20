using PSD_Project.Factory;
using PSD_Project.Model;
using PSD_Project.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Repository
{
    public class CartRepo
    {
        Database1Entities1 db = DatabaseSingleton.GetInstance();
        CartFactory cartFactory = new CartFactory();
        public void addToCart(int userId, int jewelId)
        {
            Cart existingCart = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
            if (existingCart != null)
            {
                existingCart.Quantity += 1;
            }
            else
            {
                Cart cart = cartFactory.addToCart(userId, jewelId);
                db.Carts.Add(cart);
            }
            db.SaveChanges();
        }

        public List<Cart> getCartAll(int userId)
        {
            return db.Carts.Include("MsJewel").Include("MsJewel.MsBrand").
                Where(x => x.UserID == userId).ToList();
        }

        public void updateQuantity(int userId, int jewelId, int quantity)
        {
            Cart cart = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
            if (cart != null)
            {
                cart.Quantity = quantity;
                db.SaveChanges();
            }
        }

        public void deleteCartOnly1(int userId, int jewelId)
        {
            Cart cart = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
            if (cart != null)
            {
                db.Carts.Remove(cart);
                db.SaveChanges();
            }
        }

        public int getTotalPrice(int userId)
        {
            return db.Carts.Where(x => x.UserID == userId).Sum(x => x.MsJewel.JewelPrice * x.Quantity);
        }

        public void removeAllCart(int userId)
        {
            List<Cart> carts = db.Carts.Where(x => x.UserID == userId).ToList();
            foreach(var cart in carts)
            {
                db.Carts.Remove(cart);
            }
            db.SaveChanges();
        }
    }
}