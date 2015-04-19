using Cirrious.MvvmCross.ViewModels;
using Merchant.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Core.ViewModels
{
    public class TransactionViewModel : MvxViewModel
    {
        public TransactionViewModel(ITransactionService service)
        {
            var trxList = new List<Transaction>();
            for (var i = 0; i < 100; i++)
            {
                var newTrx = service.CreateNewTransaction(i.ToString(),  i.ToString(), i);
                trxList.Add(newTrx);
            }

            Transactions = trxList;
        }

        private List<Transaction> _transactions;
        public List<Transaction> Transactions
        {
            get { return _transactions; }
            set { _transactions = value; RaisePropertyChanged(() => Transactions); }
        }


    }
}
