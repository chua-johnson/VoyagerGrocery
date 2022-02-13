using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoyagerProducts.Interfacce;
using VoyagerProducts.Models;

namespace VoyagerProducts.Controllers
{
    public class ProductController
    {
        public List<string> ProdCodes = new List<string>();
        private readonly Dictionary<string, Product> products = new Dictionary<string, Product>();

        public decimal ComputeTotal()
        {
            try
            {
                if (products == null || products.Count == 0)
                    return 0.00M;

                Product product = new Product();

                int qty = 0;
                decimal totalAmt = 0.00M;
                string prodCode = string.Empty;

                foreach (var prod in ProdCodes)
                {
                    if (prod != prodCode)
                    {
                        qty = 1;
                        prodCode = prod;
                    }

                    var transDetail = product.ComputePrice(prodCode, qty, products);
                    totalAmt += transDetail.SalePrice;

                    if (transDetail.IsBulkPrice)
                    {
                        totalAmt = transDetail.SalePrice;
                    }

                    qty += 1;
                }

                return totalAmt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddProduct(string prodCode)
        {
            if (products.ContainsKey(prodCode))
            {
                ProdCodes.Add(prodCode);
                ProdCodes.Sort();
            }
        }

        public Dictionary<string,Product> SetPrice()
        {
            Product prodA = createProdMatrixA();
            Product prodB = createProdMatrixB();
            Product prodC = createProdMatrixC();
            Product prodD = createProdMatrixD();

            products.Add(prodA.ProductCode,prodA);
            products.Add(prodB.ProductCode, prodB);
            products.Add(prodC.ProductCode,prodC);
            products.Add(prodD.ProductCode, prodD);

            return products;
        }

        private Product createProdMatrixA()
        {
            var priceMatrices = new List<PriceMatrix>
            {
                new PriceMatrix
                {
                    Unit = 1,
                    Amount = 1.25M,
                    Description = "1 for 1.25",
                    IsBulkPrice = false
                },

                new PriceMatrix
                {
                    Unit = 3,
                    Amount = 3.00M,
                    Description = "3 for 3.00",
                    IsBulkPrice = true
                }
            };

            IBuildProductMatrix product = new Product();
            return product.GetProdPriceMatrix("A", priceMatrices);
        }

        private Product createProdMatrixB()
        {
            var priceMatrices = new List<PriceMatrix>
            {
                new PriceMatrix
                {
                    Unit = 1,
                    Amount = 4.25M,
                    Description = "1 for 4.25",
                    IsBulkPrice = false
                }
            };

            IBuildProductMatrix product = new Product();
            return product.GetProdPriceMatrix("B", priceMatrices);
        }

        private Product createProdMatrixC()
        {
            var priceMatrices = new List<PriceMatrix>
            {
                new PriceMatrix
                {
                    Unit = 1,
                    Amount = 1.00M,
                    Description = "1 for 1.00",
                    IsBulkPrice = false
                },

                new PriceMatrix
                {
                    Unit = 6,
                    Amount = 5.00M,
                    Description = "6 packs for 5.00",
                    IsBulkPrice = true
                }
            };

            IBuildProductMatrix product = new Product();
            return product.GetProdPriceMatrix("C", priceMatrices);
        }

        private Product createProdMatrixD()
        {
            var priceMatrices = new List<PriceMatrix>
            {
                new PriceMatrix
                {
                    Unit = 1,
                    Amount = 0.75M,
                    Description = "1 for 0.75",
                    IsBulkPrice = false
                }
            };

            IBuildProductMatrix product = new Product();
            return product.GetProdPriceMatrix("D", priceMatrices);
        }
    }
}
