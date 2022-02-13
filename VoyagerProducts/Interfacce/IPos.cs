using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoyagerProducts.Interfacce
{
    public interface IPos
    {
        void SetPricing();
        void ScanProduct(string prodCode);
        decimal CalculateTotal();
    }
}
