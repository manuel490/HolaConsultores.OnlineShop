using HolaConsultores.OnlineShop.Domain.Interfaces.IServices;
using HolaConsultores.OnlineShop.Domain.Resources.Size;
using HolaConsultores.OnlineShop.API.Controllers.Size;
using HolaConsultores.OnlineShop.Domain.Resources.Product;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HolaConsultores.OnlineShop.Test.Controllers
{
    public class SizeControllerTests
    {
        private readonly Mock<IService<SizeResource, SizeInputResource>> _mockSizeService;
        private readonly SizeController _controller;

        public SizeControllerTests()
        {
            _mockSizeService = new Mock<IService<SizeResource, SizeInputResource>>();
            _controller = new SizeController(_mockSizeService.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOk()
        {
            var expectedSizes = new List<SizeResource>
            {
                new SizeResource { Id = 1, Name = "S" },
                new SizeResource { Id = 2, Name = "S" }
            };

            _mockSizeService.Setup(service => service.GetAllAsync())
                             .Returns(Task.FromResult(expectedSizes.AsEnumerable()));

            var result = await _controller.Get();
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedSizes = Assert.IsAssignableFrom<IEnumerable<SizeResource>>(okResult.Value);

            Assert.Equal(expectedSizes.Count, returnedSizes.Count());
        }

        [Fact]
        public async Task GetByIdOkResult()
        {
            var sizeId = 1;
            var expectedSize = new SizeResource { Id = sizeId, Name = "S" };

            _mockSizeService.Setup(service => service.GetByIdAsync(sizeId))
                .Returns(Task.FromResult(expectedSize));

            var result = await _controller.GetById(sizeId);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedSize = Assert.IsType<SizeResource>(okResult.Value);

            Assert.Equal(expectedSize.Id, returnedSize.Id);
            Assert.Equal(expectedSize.Name, returnedSize.Name);
        }

        [Fact]
        public async Task GetByIdKoResult()
        {
            var productId = 999;
            _mockSizeService.Setup(service => service.GetByIdAsync(productId))
                .ReturnsAsync((SizeResource)null);

            var result = await _controller.GetById(productId);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task CreateOkResult()
        {
            var resource = new SizeInputResource { Id = 5, Name = "S" };
            var createdProduct = new SizeResource { Id = 1, Name = resource.Name};

            _mockSizeService.Setup(service => service.AddAsync(resource))
                .Returns(Task.FromResult(createdProduct));

            var result = await _controller.Post(resource);

            var createdResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedSize = Assert.IsType<SizeResource>(createdResult.Value);
            Assert.Equal(createdProduct.Id, returnedSize.Id);
            Assert.Equal(resource.Name, returnedSize.Name);
        }

        [Fact]
        public async Task UpdateOkResult()
        {
            var productId = 1;
            var resource = new SizeInputResource { Id = 5, Name = "S" };
            var updatedSize = new SizeResource { Id = 1, Name = resource.Name };

            _mockSizeService.Setup(service => service.UpdateAsync(resource))
                .Returns(Task.FromResult(updatedSize));

            var result = await _controller.Put(resource);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedSize = Assert.IsType<SizeResource>(okResult.Value);
            Assert.Equal(updatedSize.Id, returnedSize.Id);
            Assert.Equal(resource.Name, returnedSize.Name);
        }

        [Fact]
        public async Task UpdateKoResult()
        {
            var productId = 1;
            var resource = new SizeInputResource { Id = 5, Name = "S" };
            var updatedSize = new SizeResource { Id = 1, Name = resource.Name };
            updatedSize = null;
            _mockSizeService.Setup(service => service.UpdateAsync(resource))
                .Returns(Task.FromResult(updatedSize));


            var result = await _controller.Put(resource);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task DeleteOkResult()
        {
            var productId = 1;
            var resource = new SizeResource { Id = 1, Name = "S" };
            _mockSizeService.Setup(service => service.DeleteAsync(productId))
                .Returns(Task.FromResult(resource));

            var result = await _controller.Delete(productId);

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task DeleteKoResult()
        {
            var productId = 999;
            SizeResource resource = null;

            _mockSizeService.Setup(service => service.DeleteAsync(productId))
                .Returns(Task.FromResult(resource));

            var result = await _controller.Delete(productId);

            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
