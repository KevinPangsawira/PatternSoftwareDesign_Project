using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace PSD_Project.Controller
{
    public class TransactionController
    {
        Handler.TransactionHandler transactionHandler = new Handler.TransactionHandler();

        public List<Model.TransactionHeader> getUnfinishedTransaction()
        {
            List<Model.TransactionHeader> transactionHeaders = transactionHandler.getUnfinishedTransaction();
            return transactionHeaders;
        }

        public string checkout(int userId, string paymentMethod)
        {
            if (paymentMethod.Equals("Choose Payment Method"))
            {
                return "Please choose a payment method";
            }

            return transactionHandler.checkout(userId, paymentMethod);
        }

        public void updateTransactionStatus(int transactionId, string status)
        {
           
            transactionHandler.updateTransactionStatus(transactionId, status);
        }


        public List<Model.TransactionHeader> GetTransactionHeaderList(int userID) {
            return transactionHandler.getTransactionHeaderList(userID);
        }

        public List<Model.TransactionDetail> GetTransactionDetails(int transactionID)
        {
            return transactionHandler.getTransactionDetail(transactionID);
        }

    }
}