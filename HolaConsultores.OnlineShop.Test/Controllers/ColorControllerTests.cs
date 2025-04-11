using HolaConsultores.OnlineShop.Domain.Interfaces.IServices;
using HolaConsultores.OnlineShop.Domain.Resources.Color;
using HolaConsultores.OnlineShop.API.Controllers.Color;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HolaConsultores.OnlineShop.Test.Controllers
{
    public class ColorControllerTests
    {
        private readonly Mock<IService<ColorResource, ColorInputResource>> _mockColorService;
        private readonly ColorController _controller;

        public ColorControllerTests()
        {
            _mockColorService = new Mock<IService<ColorResource, ColorInputResource>>();
            _controller = new ColorController(_mockColorService.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOk()
        {
            var expectedColors = new List<ColorResource>
            {
                new ColorResource { Id = 1, Name = "Red" },
                new ColorResource { Id = 2, Name = "Blue" }
            };

            _mockColorService.Setup(service => service.GetAllAsync())
                             .Returns(Task.FromResult(expectedColors.AsEnumerable()));

            var result = await _controller.Get();
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedColors = Assert.IsAssignableFrom<IEnumerable<ColorResource>>(okResult.Value);

            Assert.Equal(expectedColors.Count, returnedColors.Count());
        }

        [Fact]
        public async Task GetByIdOkResult()
        {
            var colorId = 1;
            var expectedColor = new ColorResource { Id = colorId, Name = "Red" };

            _mockColorService.Setup(service => service.GetByIdAsync(colorId))
                .Returns(Task.FromResult(expectedColor));

            var result = await _controller.GetById(colorId);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedColor = Assert.IsType<ColorResource>(okResult.Value);

            Assert.Equal(expectedColor.Id, returnedColor.Id);
            Assert.Equal(expectedColor.Name, returnedColor.Name);
        }

        [Fact]
        public async Task GetByIdKoResult()
        {
            var colorId = 999;
            _mockColorService.Setup(service => service.GetByIdAsync(colorId))
                .ReturnsAsync((ColorResource)null);

            var result = await _controller.GetById(colorId);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task CreateOkResult()
        {
            var resource = new ColorInputResource { Name = "Green" };
            var createdColor = new ColorResource { Id = 1, Name = resource.Name };

            _mockColorService.Setup(service => service.AddAsync(resource))
                .Returns(Task.FromResult(createdColor));

            var result = await _controller.Post(resource);

            var createdResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedColor = Assert.IsType<ColorResource>(createdResult.Value);
            Assert.Equal(createdColor.Id, returnedColor.Id);
            Assert.Equal(resource.Name, returnedColor.Name);
        }

        [Fact]
        public async Task UpdateOkResult()
        {
            var colorId = 1;
            var resource = new ColorInputResource { Name = "Updated Green" };
            var updatedColor = new ColorResource { Id = colorId, Name = resource.Name };

            _mockColorService.Setup(service => service.UpdateAsync(resource))
                .Returns(Task.FromResult(updatedColor));

            var result = await _controller.Put(resource);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedColor = Assert.IsType<ColorResource>(okResult.Value);
            Assert.Equal(updatedColor.Id, returnedColor.Id);
            Assert.Equal(resource.Name, returnedColor.Name);
        }

        [Fact]
        public async Task UpdateKoResult()
        {
            var colorId = 1;
            var resource = new ColorInputResource { Name = "Updated Green" };
            var updatedColor = new ColorResource { Id = colorId, Name = resource.Name };
            updatedColor = null;
            _mockColorService.Setup(service => service.UpdateAsync(resource))
                .Returns(Task.FromResult(updatedColor));



            var result = await _controller.Put(resource);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task DeleteOkResult()
        {
            var colorId = 1;
            var resource = new ColorResource { Id = colorId, Name = "Red" };
            _mockColorService.Setup(service => service.DeleteAsync(colorId))
                .Returns(Task.FromResult(resource));

            var result = await _controller.Delete(colorId);

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task DeleteKoResult()
        {
            var colorId = 999;
            ColorResource resource = null;

            _mockColorService.Setup(service => service.DeleteAsync(colorId))
                .Returns(Task.FromResult(resource));

            var result = await _controller.Delete(colorId);

            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
