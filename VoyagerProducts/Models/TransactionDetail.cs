using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoyagerProducts.Models
{
    public class TransactionDetail
    {
        public bool IsBulkPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int SaleQty { get; set; }
    }
}
