using PSD_Project.Model;
using PSD_Project.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Factory
{
   
    public class CartFactory
    {
        public Cart addToCart(int userId, int jewelId)
        {
            Cart cart = new Cart();
            cart.JewelID = jewelId;
            cart.UserID = userId;
            cart.Quantity = 1;
            return cart;
        }
        
         
    }
}