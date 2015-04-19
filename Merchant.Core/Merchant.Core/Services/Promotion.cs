using Cirrious.MvvmCross.Plugins.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Core.Services
{
    public class Promotion
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Index { get; set; }
        public string Title { get; set; }
        public string PromotionType { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
