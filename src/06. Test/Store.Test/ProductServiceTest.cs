using Common.Interfaces.Repository;
using Implementations.Store;
using Interfaces.Store;
using Models.Entities;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Store.Test
{
    public class ProductServiceTest
    {
        private IProductService _productService;
        private Mock<IRepositoryAsync<Product>> _productRepository;

        [SetUp]
        public void Setup()
        {
            _productRepository = new Mock<IRepositoryAsync<Product>>();
            ConfigureMock();
            _productService = new ProductService(
                    _productRepository.Object
                );
        }

        private void ConfigureMock()
        {
            _productRepository.Setup(x => x.GetByIdAsync(2)).ReturnsAsync(new Product()
            {
                Id = 2,
                Description = "Some article by id",
                Name = "Some article by id",
                Quantity = 10
            });
        }

        [Test]
        public void TestCreateProduct()
        {
            var input = new Product() { Description = "Some article", Name = "Phone", Quantity = 300 };
            var result = _productService.AddNewProduct(input);
            Assert.IsNotNull(result, "error");
        }

        [Test]
        public void UpdateProduct()
        {
            var input = new Product() { Description = "Some article", Name = "Phone", Quantity = 300 };
            var id = 2;
            var result = _productService.UpdateProduct(id, input);
            Assert.IsNotNull(result, "error");
        }
    }
}