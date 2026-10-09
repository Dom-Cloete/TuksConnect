using Microsoft.AspNetCore.Mvc;
using Moq;
using TuksConnectAPI.Controllers;
using TuksConnectAPI.Models;
using TuksConnectAPI.Repositories;

namespace TuksConnectAPI.Tests
{
    public class EventControllerTests
    {
        [Fact]
        public async Task GetEvents_ReturnsOk()
        {
            var mockRepo = new Mock<IEventRepository>();
            mockRepo.Setup(r => r.GetAllEvents()).ReturnsAsync(new List<Event>());

            var controller = new EventController(mockRepo.Object);

            var result = await controller.GetEvents();

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetEventById_ReturnsOk()
        {
            var mockRepo = new Mock<IEventRepository>();
            mockRepo.Setup(r => r.GetEventById(1)).ReturnsAsync(new Event());

            var controller = new EventController(mockRepo.Object);

            var result = await controller.GetEvent(1);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}