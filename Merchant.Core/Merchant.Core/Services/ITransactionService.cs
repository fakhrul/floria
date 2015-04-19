using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Core.Services
{
    public interface ITransactionService
    {
        Transaction CreateNewTransaction(string merchantId, string promoId, double amount);
    }
}
