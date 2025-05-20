using PSD_Project.Model;
using PSD_Project.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Repository
{
    public class OrderRepo
    {
        Database1Entities1 db = DatabaseSingleton.GetInstance();
        public List<TransactionHeader> getUnfinishedTransaction()
        {
            return db.TransactionHeaders.Where(x => x.TransactionStatus != "Done" && x.TransactionStatus != "Rejected").ToList();

        }


        public string Checkout(int userId, string paymentMethod)
        {
            TransactionHeader transactionHeader = new TransactionHeader();
            TransactionDetail transactionDetail = new TransactionDetail();
            List<Cart> cartList = db.Carts.Where(x => x.UserID == userId).ToList();
            if (cartList.Count == 0) return "fail";

            transactionHeader = new TransactionHeader
            {
                UserID = userId,
                TransactionDate = DateTime.Now,
                TransactionStatus = "Payment Pending",
                PaymentMethod = paymentMethod,
            };

            foreach (var cart in cartList)
            {
                transactionDetail = new TransactionDetail
                {
                    TransactionID = transactionHeader.TransactionID,
                    JewelID = cart.JewelID,
                    Quantity = cart.Quantity
                };
                db.TransactionDetails.Add(transactionDetail);
            }

            db.TransactionHeaders.Add(transactionHeader);

            db.SaveChanges();

            return "success";
        }


        public void updateTransactionStatus(int transactionId, string status)
        {
            TransactionHeader transactionHeader = db.TransactionHeaders.Find(transactionId);
            if (transactionHeader != null)
            {
                transactionHeader.TransactionStatus = status;
                db.SaveChanges();
            }
        }




        public List<TransactionHeader> getTransactionHeaderList(int userId)
        {
            return db.TransactionHeaders.Where(x => x.UserID == userId).ToList();
        }


        public List<TransactionDetail> getTransactionDetail(int transactionId)
        {
            return db.TransactionDetails.Include("MsJewel").Where(x => x.TransactionID == transactionId).ToList();
        }

    }
}