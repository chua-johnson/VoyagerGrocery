using System;
using VoyagerProducts.Controllers;

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

                Console.WriteLine($"Total bill is ${result}");
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong..contact your administrator.");
            }
        }
    }
}
