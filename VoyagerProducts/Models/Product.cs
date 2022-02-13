using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoyagerProducts.Interfacce;

namespace VoyagerProducts.Models
{
    public class Product : ProductBase, IBuildProductMatrix, IComputePrice
    {

        public List<PriceMatrix> PriceMatrices { get; set; }

        public TransactionDetail ComputePrice(string prodCode, int saleQty, Dictionary<string, Product> products)
        {

            var product = products[prodCode];

            if (product.PriceMatrices == null)
                return null;

            if (product.PriceMatrices.Count == 0)
                return null;

            PriceMatrix priceMatrix = product.PriceMatrices.SingleOrDefault(x => x.Unit == saleQty);

            if (priceMatrix != null)
            {
                return new TransactionDetail
                {
                    IsBulkPrice = priceMatrix.IsBulkPrice,
                    SalePrice = priceMatrix.Amount,
                    SaleQty = saleQty
                };
            }
            else
            {
                priceMatrix = product.PriceMatrices.SingleOrDefault(x => x.IsBulkPrice == false);

                if (priceMatrix != null)
                {
                    return new TransactionDetail
                    {
                        IsBulkPrice = priceMatrix.IsBulkPrice,
                        SalePrice = priceMatrix.Amount,
                        SaleQty = saleQty
                    };
                }
                return null;
            }
        }

        public Product GetProdPriceMatrix(string prodCode, List<PriceMatrix> priceMatrices)
        {
            return new Product
            {
                ProductCode = prodCode,
                PriceMatrices = priceMatrices
            };
        }
    }
}
