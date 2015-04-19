using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Core.Services
{
    public class TransactionService : ITransactionService
    {
        public Transaction CreateNewTransaction(string merchantId, string promoId, double amount)
        {
            return new Transaction()
            {
                DateTime = DateTime.Now,
                MerchantId = merchantId,
                PromoId = promoId,
                Amount = amount
            };
        }
    }
}
