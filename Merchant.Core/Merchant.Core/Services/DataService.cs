using Cirrious.MvvmCross.Plugins.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Core.Services
{
    public class DataService :IDataService
    {
        private readonly ISQLiteConnection _connection;

        public DataService(ISQLiteConnectionFactory factory)
        {
            _connection = factory.Create("merchant.sql");
            _connection.CreateTable<Transaction>();
            _connection.CreateTable<Promotion>();
        }

        public Promotion GetPromotionByIndex(int index)
        {
                return _connection.Table<Promotion>()
                    .Where(x => x.Index == index)
                    .FirstOrDefault();
        }
        public void InsertPromotion(Promotion promo)
        {
            _connection.Insert(promo);
        }
        public void UpdatePromotion(Promotion promo)
        {
            _connection.Update(promo);
        }


        public List<Transaction> GetAllTransaction()
        {
            return _connection.Table<Transaction>().ToList();
        }

        public void InsertTransaction(Transaction trans)
        {
            _connection.Insert(trans);
        }

        public void Update(Transaction trans)
        {
            _connection.Update(trans);
        }

        public void Delete(Transaction trans)
        {
            _connection.Delete(trans);
        }

        public int Count
        {
            get
            {
                return _connection.Table<Transaction>().Count();
            }
        }
    }
}
