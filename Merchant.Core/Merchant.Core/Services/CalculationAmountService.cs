using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Core.Services
{
    public class CalculationAmountService : ICalculationAmountService
    {
        private string amount ="";
        public string GetAmount(string amount, string inValue)
        {
            switch (inValue.ToLower())
            {
                case "clr":
                    amount = "0";
                    break;
                case "del":
                    if (!string.IsNullOrEmpty(amount))
                        amount = amount.Substring(0, amount.Length - 1);
                    break;
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    if (amount.Length <= 6)
                        amount = amount + inValue;
                    break;
                default:
                    break;
            }

            if (string.IsNullOrEmpty(amount))
                return "0";

            return amount;
        }
    }
}
