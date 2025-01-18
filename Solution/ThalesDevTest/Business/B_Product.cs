using DataAccess;
using Entity;
using System.ComponentModel.Design;

namespace Business
{
    public class B_Product {
        private readonly ApiService _apiService;

        public B_Product() { }

        public B_Product(HttpClient httpClient) {
            httpClient.BaseAddress = new Uri("https://api.escuelajs.co/api/v1/products/");
            _apiService = new ApiService(httpClient);
        }

        private Product calculateTaxValue(Product product) {
            product.tax = product.price * 0.19;
            return product;
        }

        public virtual async Task<List<Product>> GetProducts() {
            var data = await _apiService.GetData<List<Product>>("");

            var updatedData = data.Data.Select(product =>
            {
                return calculateTaxValue(product);
            }).ToList();

            return updatedData;
        }

        public virtual async Task<Product?> GetProductById(int id) {
            var data = await _apiService.GetData<Product>($"{id}");

            if (data.Error)
                return null;
            else
                return calculateTaxValue(data.Data);
        }
    }
}
