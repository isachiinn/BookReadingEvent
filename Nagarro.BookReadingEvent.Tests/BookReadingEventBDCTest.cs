using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.BookReadingEvent.Business;
using Nagarro.BookReadingEvent.Shared;


namespace Nagarro.BookReadingEvent.Tests
{
    [TestClass]
    public class CommentBDCTest
    {
        private readonly ICommentBDC commentBDC;
        private readonly Mock<IDACFactory> mockDacFactory;
        private readonly Mock<ICommentDAC> mockCommentDac;



        public CommentBDCTest()
        {
            mockDacFactory = new Mock<IDACFactory>();
            mockCommentDac = new Mock<ICommentDAC>();
            mockDacFactory.Setup(x => x.Create(It.IsAny<DACType>())).Returns(mockCommentDac.Object);
            commentBDC = new CommentBDC(mockDacFactory.Object);
        }
        [TestMethod]
        public void AddCommentTest1()
        {
            mockCommentDac.Setup(x => x.AddNewComment(It.IsAny<CommentDTO>())).Returns(commentDTO);
            var response = commentBDC.AddNewComment(commentDTO);
            Assert.AreEqual(OperationResultType.Success, response.ResultType);
        }
        [TestMethod]
        public void AddCommentTest2()
        {
            mockCommentDac.Setup(x => x.AddNewComment(It.IsAny<CommentDTO>())).Returns((CommentDTO)null);
            var response = commentBDC.AddNewComment(new CommentDTO());
            Assert.AreEqual(OperationResultType.Failure, response.ResultType);
        }

        private CommentDTO commentDTO = new CommentDTO()
        {
            Id = 1,
            Username = "abc@gmail.com",
            EventId = 18,
            Comment1 = "confirmation",
            DatePosted = DateTime.Now,
        };
    }


    [TestClass]
    public class BookEventManagementBDCTest
    {
        private readonly IEventBDC eventBDC;
        private readonly Mock<IDACFactory> mockDacFactory;
        private readonly Mock<IEventDAC> mockEventDac;

        public BookEventManagementBDCTest()
        {
            mockDacFactory = new Mock<IDACFactory>();
            mockEventDac = new Mock<IEventDAC>();
            mockDacFactory.Setup(x => x.Create(It.IsAny<DACType>())).Returns(mockEventDac.Object);
            eventBDC = new EventBDC(mockDacFactory.Object);
        }

        [TestMethod]
        public void CreateEventTest1()
        {
            mockEventDac.Setup(x => x.CreateEvent(It.IsAny<EventDTO>())).Returns(eventDTO);
            var response = eventBDC.CreateEvent(eventDTO);
            Assert.AreEqual(OperationResultType.Success, response.ResultType);

        }

        [TestMethod]
        public void CreateEventTest2()
        {
            mockEventDac.Setup(x => x.CreateEvent(It.IsAny<EventDTO>())).Returns((EventDTO)null);
            var response = eventBDC.CreateEvent(new EventDTO());
            Assert.AreEqual(OperationResultType.Failure, response.ResultType);
        }


        private EventDTO eventDTO = new EventDTO
        {
            Title = "Physics",
            AddressId = 3,
            Date = DateTime.Today,
            StartTime = new TimeSpan(3, 5, 6),
            Duration = 3,
            Description = "book",
            OtherDetails = "book",
            Invitations = "pritam@gmail.com"

        };

    }
}
