using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Core.Services
{
    public interface ICalculationAmountService
    {
        string GetAmount(string amount, string inValue);
    }
}
