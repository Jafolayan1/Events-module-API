using Contracts;

using Entities.Models;

using Moq;

namespace Event_module_Test
{
    public class EventsControllerTests
    {
        [Fact]
        public void DeleteEvent_ExistingEvent_ReturnsNoContentResult()
        {
            // Arrange
            var eventId = Guid.NewGuid();
            var mockRepository = new Mock<IEventRepository>();
            var mockLogger = new Mock<ILoggerManager>();

            var sampleEvent = new Event { Id = eventId };

            //mockRepository.Setup(r => r.GetEventById(eventId)).Returns(sampleEvent);

            //var controller = new EventsController(mockRepository.Object, mockLogger.Object);

            //// Act
            //var result = controller.DeleteEvent(eventId);

            //// Assert
            //Assert.IsType<NoContentResult>(result);

            //mockRepository.Verify(r => r.DeleteEvent(sampleEvent), Times.Once);
            //mockRepository.Verify(r => r.Save(), Times.Once);
        }
    }
}