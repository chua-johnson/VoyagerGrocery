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
            var prodController = new PointOfSaleTerminal();

            Dictionary<string,Product> prodMatrix = prodController.SetPricing();

            Assert.IsNotNull(prodMatrix["A"].PriceMatrices);
            Assert.AreEqual("A", prodMatrix["A"].ProductCode);
            Assert.IsTrue(prodMatrix["A"].PriceMatrices.Count > 0);
        }

        [TestMethod]
        public void CheckIfProductExists()
        {
            var prodController = new PointOfSaleTerminal();
            Dictionary<string, Product> prodMatrix = prodController.SetPricing();
            prodController.ScanProduct("A");
            Assert.IsTrue(prodController.ProdCodes.Contains("A"));

            prodController.ScanProduct("Z");
            Assert.IsFalse(prodController.ProdCodes.Contains("Z"));
        }

        [TestMethod]
        public void CheckTotal_ABCDABA()
        {
            var terminal = new PointOfSaleTerminal();

            terminal.SetPricing();
            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("C");
            terminal.ScanProduct("D");
            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("A");

            decimal result = terminal.CalculateTotal();

            Assert.AreEqual(13.25M,result);
        }

        [TestMethod]
        public void CheckTotal_CCCCCCC()
        {
            var terminal = new PointOfSaleTerminal();

            terminal.SetPricing();
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");

            decimal result = terminal.CalculateTotal();

            Assert.AreEqual(6.00M, result);
        }

        [TestMethod]
        public void CheckTotal_ABCD()
        {
            var terminal = new PointOfSaleTerminal();

            terminal.SetPricing();
            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("C");
            terminal.ScanProduct("D");

            decimal result = terminal.CalculateTotal();

            Assert.AreEqual(7.25M, result);
        }
    }
}
