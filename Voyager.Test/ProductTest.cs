using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VoyagerProducts.Controllers;
using VoyagerProducts.Interfacce;
using VoyagerProducts.Models;

namespace Voyager.Test
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void SetProductPrice()
        {
            var prodController = new ProductController();

            Dictionary<string,Product> prodMatrix = prodController.SetPrice();

            Assert.IsNotNull(prodMatrix["A"].PriceMatrices);
            Assert.AreEqual("A", prodMatrix["A"].ProductCode);
            Assert.IsTrue(prodMatrix["A"].PriceMatrices.Count > 0);
        }

        [TestMethod]
        public void CheckIfProductExists()
        {
            var prodController = new ProductController();
            Dictionary<string, Product> prodMatrix = prodController.SetPrice();
            prodController.AddProduct("A");
            Assert.IsTrue(prodController.ProdCodes.Contains("A"));

            prodController.AddProduct("Z");
            Assert.IsFalse(prodController.ProdCodes.Contains("Z"));
        }

        [TestMethod]
        public void CheckTotal_ABCDABA()
        {
            var terminal = new ProductController();

            terminal.SetPrice();
            terminal.AddProduct("A");
            terminal.AddProduct("B");
            terminal.AddProduct("C");
            terminal.AddProduct("D");
            terminal.AddProduct("A");
            terminal.AddProduct("B");
            terminal.AddProduct("A");

            decimal result = terminal.ComputeTotal();

            Assert.AreEqual(13.25M,result);
        }

        [TestMethod]
        public void CheckTotal_CCCCCCC()
        {
            var terminal = new ProductController();

            terminal.SetPrice();
            terminal.AddProduct("C");
            terminal.AddProduct("C");
            terminal.AddProduct("C");
            terminal.AddProduct("C");
            terminal.AddProduct("C");
            terminal.AddProduct("C");
            terminal.AddProduct("C");

            decimal result = terminal.ComputeTotal();

            Assert.AreEqual(6.00M, result);
        }

        [TestMethod]
        public void CheckTotal_ABCD()
        {
            var terminal = new ProductController();

            terminal.SetPrice();
            terminal.AddProduct("A");
            terminal.AddProduct("B");
            terminal.AddProduct("C");
            terminal.AddProduct("D");

            decimal result = terminal.ComputeTotal();

            Assert.AreEqual(7.25M, result);
        }
    }
}
