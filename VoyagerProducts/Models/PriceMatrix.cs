using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoyagerProducts.Models
{
    public class PriceMatrix
    {
        public int Unit { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public bool IsBulkPrice { get; set; }
    }
}
