using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoyagerProducts.Models;

namespace VoyagerProducts.Interfacce
{
    public interface IBuildProductMatrix
    {
        Product GetProdPriceMatrix(string prodCode, List<PriceMatrix> priceMatrices);
    }
}
