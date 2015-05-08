using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Core.Services
{
    public interface IDataService
    {
        #region Promotion
        Promotion GetPromotionByIndex(int index);
        void InsertPromotion(Promotion promo);
        void UpdatePromotion(Promotion promo);

        #endregion

        #region Transaction
        Transaction GetPreviousTransaction();
        List<Transaction> GetAllTransaction();
        void InsertTransaction(Transaction trans);
        void Update(Transaction trans);
        void Delete(Transaction trans);
        int Count { get; }
        #endregion


    }
}
