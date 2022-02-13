using System;
using VoyagerProducts.ClientLibrary;
using VoyagerProducts.Controllers;
using VoyagerProducts.Interfacce;

namespace PointOfSaleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            checkOut();
        }

        private static void checkOut()
        {
            try
            {
                var prodController = new ProductController();
                IPos terminal = new PointOfSaleTerminal(prodController);
                
                terminal.SetPricing();
                terminal.ScanProduct("A");
                terminal.ScanProduct("B");
                terminal.ScanProduct("C");
                terminal.ScanProduct("D");
                terminal.ScanProduct("A");
                terminal.ScanProduct("B");
                terminal.ScanProduct("A");

                decimal result = terminal.CalculateTotal();

                Console.WriteLine($"Total bill is ${result}");
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong..contact your administrator.");
            }
        }
    }
}
