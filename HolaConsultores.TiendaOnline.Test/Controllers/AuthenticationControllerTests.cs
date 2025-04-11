using Microsoft.Extensions.Configuration;
using HolaConsultores.TiendaOnline.API.Controllers.Authentication;
using HolaConsultores.TiendaOnline.Domain.Interfaces.IServices;
using HolaConsultores.TiendaOnline.Domain.Resources.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HolaConsultores.TiendaOnline.Test.Controllers
{
    public class AuthenticationControllerTests
    {
        private readonly Mock<IUserService<UserResource, UserResource>> _mockUserService;
        private readonly AuthenticationController _controller;
        private readonly Mock<IConfiguration> _configuration;

        public AuthenticationControllerTests()
        {
            var mockSettingsSection = new Mock<IConfigurationSection>();
            mockSettingsSection.Setup(s => s["secretKey"]).Returns("=TechnicalTestHolaConsultores_2025_04=");
            mockSettingsSection.Setup(s => s["adminEmail"]).Returns("admin@admin.com");
            mockSettingsSection.Setup(s => s["adminPassword"]).Returns("Admin_123");

            _configuration = new Mock<IConfiguration>();
            _configuration.Setup(c => c.GetSection("settings")).Returns(mockSettingsSection.Object);
            _mockUserService = new Mock<IUserService<UserResource, UserResource>>();

            _controller = new AuthenticationController(_configuration.Object, _mockUserService.Object);
        }

        [Fact]
        public async Task LoginOkResult()
        {
            var email = "admin@admin.com";
            var password = "Admin_123";
            var resource = new UserResource
            {
                Id = 1,
                Email = email,
                Password = password
            };

            var result = await _controller.Validate(resource);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task LoginKoResult()
        {
            var email = "test@example.com";
            var password = "123";

            var resource = new UserResource
            {
                Id = 1,
                Email = email,
                Password = password
            };

            var result = await _controller.Validate(resource);

            Assert.IsType<UnauthorizedResult>(result);
        }
    }
}
