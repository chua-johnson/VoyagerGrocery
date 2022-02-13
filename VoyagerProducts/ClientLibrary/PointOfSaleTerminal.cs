namespace VoyagerProducts.ClientLibrary
{
    using VoyagerProducts.Controllers;
    using VoyagerProducts.Interfacce;

    public class PointOfSaleTerminal : IPos
    {
        private readonly ProductController _prodController;
        public PointOfSaleTerminal(ProductController prodController) => this._prodController = prodController;

        public decimal CalculateTotal() => _prodController.ComputeTotal();

        public void ScanProduct(string prodCode) => _prodController.AddProduct(prodCode);

        public void SetPricing() => _prodController.SetPrice();

    }
}
