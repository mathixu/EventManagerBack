using EventManager.Business;
using EventManager.DAL.Contracts;
using EventManager.Models;
using Moq;

namespace EventManager.Tests;

[TestClass]
public class EventBusinessTests
{
    private Mock<IEventRepository> _eventRepository;
    private EventBusiness _eventBusiness;

    [TestInitialize]
    public void SetUp()
    {
        _eventRepository = new Mock<IEventRepository>();
        _eventBusiness = new EventBusiness(_eventRepository.Object);
    }

    [TestMethod]
    public async Task CreateAsync_ValidEvent_ReturnsEvent()
    {
        // Arrange
        var eventEntity = new Event { Title = "Title", Description = "Description", Date = DateTime.Now, Location = "Location" };
        _eventRepository.Setup(repo => repo.InsertAsync(It.IsAny<Event>())).ReturnsAsync(eventEntity);

        // Act
        var result = await _eventBusiness.CreateAsync(eventEntity);

        // Assert
        Assert.IsNotNull(result);
        _eventRepository.Verify(repo => repo.InsertAsync(It.IsAny<Event>()), Times.Once);
    }

    [TestMethod]
    public async Task CreateAsync_InvalidEvent_ThrowArgumentException()
    {
        // Arrange
        var eventEntity = new Event { Title = "Title", Date = DateTime.Now, Location = "Location" };
        _eventRepository.Setup(repo => repo.InsertAsync(It.IsAny<Event>())).ReturnsAsync(eventEntity);

        var result = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _eventBusiness.CreateAsync(eventEntity));

        Assert.AreEqual("Description is required", result.Message);

        _eventRepository.Verify(repo => repo.InsertAsync(It.IsAny<Event>()), Times.Never);
    }
}