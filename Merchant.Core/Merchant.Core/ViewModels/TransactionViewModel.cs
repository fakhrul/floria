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
        private readonly IDataService _dataService;
        public TransactionViewModel(IDataService service)
        {
            _dataService = service;
            //var trxList = new List<Transaction>();
            //for (var i = 0; i < 100; i++)
            //{
            //    var newTrx = service.CreateNewTransaction(i.ToString(),  i.ToString(), i);
            //    trxList.Add(newTrx);
            //}
            //_dataService.G(1).Title;
            Transactions = _dataService.GetAllTransaction();
        }

        private List<Transaction> _transactions;
        public List<Transaction> Transactions
        {
            get { return _transactions; }
            set { _transactions = value; RaisePropertyChanged(() => Transactions); }
        }


    }
}
