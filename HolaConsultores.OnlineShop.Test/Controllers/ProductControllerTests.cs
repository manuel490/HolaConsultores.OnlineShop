using HolaConsultores.OnlineShop.Domain.Interfaces.IServices;
using HolaConsultores.OnlineShop.Domain.Resources.Product;
using HolaConsultores.OnlineShop.API.Controllers.Product;
using HolaConsultores.OnlineShop.Domain.Resources.Color;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HolaConsultores.OnlineShop.Test.Controllers
{
    public class ProductControllerTests
    {
        private readonly Mock<IService<ProductResource, ProductInputResource>> _mockProductService;
        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            _mockProductService = new Mock<IService<ProductResource, ProductInputResource>>();
            _controller = new ProductController(_mockProductService.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOk()
        {
            var expectedProducts = new List<ProductResource>
            {
                new ProductResource { Id = 1, Price = 14.19M, Description = "Camiseta" },
                new ProductResource { Id = 2, Price = 20.95M, Description = "Pantalon" }
            };

            _mockProductService.Setup(service => service.GetAllAsync())
                             .Returns(Task.FromResult(expectedProducts.AsEnumerable()));

            var result = await _controller.Get();
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedProducts = Assert.IsAssignableFrom<IEnumerable<ProductResource>>(okResult.Value);

            Assert.Equal(expectedProducts.Count, returnedProducts.Count());
        }

        [Fact]
        public async Task GetByIdOkResult()
        {
            var productId = 1;
            var expectedProduct = new ProductResource { Id = productId, Price = 20.95M, Description = "Pantalon" };

            _mockProductService.Setup(service => service.GetByIdAsync(productId))
                .Returns(Task.FromResult(expectedProduct));

            var result = await _controller.GetById(productId);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedColor = Assert.IsType<ProductResource>(okResult.Value);

            Assert.Equal(expectedProduct.Id, returnedColor.Id);
            Assert.Equal(expectedProduct.Price, returnedColor.Price);
            Assert.Equal(expectedProduct.Description, returnedColor.Description);
        }

        [Fact]
        public async Task GetByIdKoResult()
        {
            var productId = 999;
            _mockProductService.Setup(service => service.GetByIdAsync(productId))
                .ReturnsAsync((ProductResource)null);

            var result = await _controller.GetById(productId);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task CreateOkResult()
        {
            var resource = new ProductInputResource { Id = 5,Price = 14.99M , Description = "Camiseta"};
            var createdProduct = new ProductResource { Id = 1, Price = resource.Price, Description = resource.Description };

            _mockProductService.Setup(service => service.AddAsync(resource))
                .Returns(Task.FromResult(createdProduct));

            var result = await _controller.Post(resource);

            var createdResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedProduct = Assert.IsType<ProductResource>(createdResult.Value);
            Assert.Equal(createdProduct.Id, returnedProduct.Id);
            Assert.Equal(resource.Price, returnedProduct.Price);
            Assert.Equal(resource.Description, returnedProduct.Description);
        }

        [Fact]
        public async Task UpdateOkResult()
        {
            var productId = 1;
            var resource = new ProductInputResource { Id = 5, Price = 14.99M, Description = "Camiseta" };
            var updatedProduct = new ProductResource { Id = 1, Price = resource.Price, Description = resource.Description };

            _mockProductService.Setup(service => service.UpdateAsync(resource))
                .Returns(Task.FromResult(updatedProduct));

            var result = await _controller.Put(resource);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedProduct = Assert.IsType<ProductResource>(okResult.Value);
            Assert.Equal(updatedProduct.Id, returnedProduct.Id);
            Assert.Equal(resource.Price, returnedProduct.Price);
            Assert.Equal(resource.Description, returnedProduct.Description);
        }

        [Fact]
        public async Task UpdateKoResult()
        {
            var productId = 1;
            var resource = new ProductInputResource { Id = 5, Price = 14.99M, Description = "Camiseta" };
            var updatedProduct = new ProductResource { Id = 1, Price = resource.Price, Description = resource.Description };
            updatedProduct = null;
            _mockProductService.Setup(service => service.UpdateAsync(resource))
                .Returns(Task.FromResult(updatedProduct));


            var result = await _controller.Put(resource);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task DeleteOkResult()
        {
            var productId = 1;
            var resource = new ProductResource { Id = 1, Price = 14.99M, Description = "Camiseta" };
            _mockProductService.Setup(service => service.DeleteAsync(productId))
                .Returns(Task.FromResult(resource));

            var result = await _controller.Delete(productId);

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task DeleteKoResult()
        {
            var productId = 999;
            ProductResource resource = null;

            _mockProductService.Setup(service => service.DeleteAsync(productId))
                .Returns(Task.FromResult(resource));

            var result = await _controller.Delete(productId);

            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
