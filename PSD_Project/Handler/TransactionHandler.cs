using PSD_Project.Model;
using PSD_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Handler
{
    public class TransactionHandler
    {
        OrderRepo orderRepo = new OrderRepo();
        public List<TransactionHeader> getUnfinishedTransaction()
        {
            return orderRepo.getUnfinishedTransaction();
        }

        public string checkout(int userId, string paymentMethod)
        {
            string response = orderRepo.Checkout(userId, paymentMethod);
         
            return response;
        }

        public void updateTransactionStatus(int transactionId, string status)
        {
            orderRepo.updateTransactionStatus(transactionId, status);
            //return response;
        }

        public List<TransactionHeader> getTransactionHeaderList(int userId) { 
            return orderRepo.getTransactionHeaderList(userId);
        }

        public List<TransactionDetail> getTransactionDetail(int transactionId) { 
            return orderRepo.getTransactionDetail(transactionId);
        }

    }
}