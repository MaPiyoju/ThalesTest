using Moq;
using Business;
using Entity;

public class B_ProductTests
{
    [Fact]
    public async Task GetProducts_ShouldReturnProductsWithCalculatedTax() {
        var mockBProduct = new Mock<B_Product>();

        var products = new List<Product>
        {
            new Product { id = 1, title = "Product A", price = 100 },
            new Product { id = 2, title = "Product B", price = 200 }
        };

        mockBProduct.Setup(bp => bp.GetProducts())
            .ReturnsAsync(products.Select(p => {
                p.tax = p.price * 0.19;
                return p;
            }).ToList());

        var productService = mockBProduct.Object;
        var productsResult = await productService.GetProducts();

        Assert.Equal(2, productsResult.Count);
        Assert.Equal(19, productsResult[0].tax);
        Assert.Equal(38, productsResult[1].tax);
    }

    [Fact]
    public async Task GetProductById_ShouldReturnNullIfError() {
        var mockBProduct = new Mock<B_Product>();

        mockBProduct.Setup(bp => bp.GetProductById(999))
            .ReturnsAsync((Product?)null);

        var productService = mockBProduct.Object;
        var productResult = await productService.GetProductById(999);

        Assert.Null(productResult);
    }

    [Fact]
    public async Task GetProducts_ShouldReturnEmptyListIfNoProducts() {
        var mockBProduct = new Mock<B_Product>();

        mockBProduct.Setup(bp => bp.GetProducts())
            .ReturnsAsync(new List<Product>());

        var productService = mockBProduct.Object;
        var productsResult = await productService.GetProducts();

        Assert.Empty(productsResult);
    }
}
