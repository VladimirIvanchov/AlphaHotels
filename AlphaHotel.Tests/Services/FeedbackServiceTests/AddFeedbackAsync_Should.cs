using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using AlphaHotel.Tests.TestUtils;
using AlphaHotel.Data;
using AlphaHotel.Models;
using Moq;
using AlphaHotel.Services;
using AlphaHotel.Services.Utilities;
using AlphaHotel.Infrastructure.PagingProvider;
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.Censorship;
using Microsoft.EntityFrameworkCore;

namespace AlphaHotel.Tests.Services.FeedbackServiceTests
{
    [TestClass]
    public class AddFeedbackAsync_Should
    {
        [TestMethod]
        public async Task ThrowException_WhenBusinessIsNotFound()
        {
            var text = "text";
            var rating = 5;
            var author = "gosho";
            var businessId = 1;
            var wrongBusinessId = 2;
            var feedbackId = 1;
            var paginatedListMocked = new Mock<IPaginatedList<FeedbackDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var censorMocked = new Mock<ICensor>();

            FeedbackTestUtils.GetContextWithFullFeedback(nameof(ThrowException_WhenBusinessIsNotFound), text, rating, author, businessId, feedbackId);

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(ThrowException_WhenBusinessIsNotFound))))
            {
                var feedbackService = new FeedbackService(assertContext, paginatedListMocked.Object, dateTimeWrapperMocked.Object, censorMocked.Object);

                await Assert.ThrowsExceptionAsync<ArgumentException>(
                    async () => await feedbackService.AddFeedbackAsync(text, rating, author, wrongBusinessId));
            }
        }

        [TestMethod]
        public async Task AddFeedback_Return_WhenAllParametersArePassed()
        {
            var text = "text";
            var rating = 5;
            var author = "gosho";
            var businessId = 1;
            var feedbackId = 2;
            var paginatedListMocked = new Mock<IPaginatedList<FeedbackDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var censorMocked = new Mock<ICensor>();

            FeedbackTestUtils.GetContextWithFullFeedback(nameof(AddFeedback_Return_WhenAllParametersArePassed), text, rating, author, businessId, feedbackId);

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(AddFeedback_Return_WhenAllParametersArePassed))))
            {
                var feedbackService = new FeedbackService(assertContext, paginatedListMocked.Object, dateTimeWrapperMocked.Object, censorMocked.Object);
                await feedbackService.AddFeedbackAsync(text, rating, author, businessId);

                var feedback = await assertContext.Feedbacks.FirstOrDefaultAsync(f => f.BusinessId == businessId);

                Assert.AreEqual(text, feedback.Text);
                Assert.AreEqual(rating, feedback.Rate);
                Assert.AreEqual(author, feedback.Author);
                Assert.AreEqual(businessId, feedback.BusinessId);
                Assert.IsFalse(feedback.IsDeleted);
            }
        }

        [TestMethod]
        public async Task Return_WhenAllParametersArePassedAndAuthorIsAnonymous()
        {
            var feedbackText = "text";
            var rating = 5;
            var author = "";
            var businessId = 1;
            var paginatedListMocked = new Mock<IPaginatedList<FeedbackDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var censorMocked = new Mock<ICensor>();

            FeedbackTestUtils.GetContextWithFullFeedbackAndAnonymousAuthor(nameof(Return_WhenAllParametersArePassedAndAuthorIsAnonymous), feedbackText, rating, author, businessId);

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(Return_WhenAllParametersArePassedAndAuthorIsAnonymous))))
            {
                var feedbackService = new FeedbackService(assertContext, paginatedListMocked.Object, dateTimeWrapperMocked.Object, censorMocked.Object);
                await feedbackService.AddFeedbackAsync(feedbackText, rating, author, businessId);

                var feedback = await assertContext.Feedbacks.FirstOrDefaultAsync(s => s.BusinessId == businessId);

                Assert.AreEqual(feedbackText, feedback.Text);
                Assert.AreEqual(rating, feedback.Rate);
                Assert.AreEqual("Anonymous", feedback.Author);
                Assert.AreEqual(businessId, feedback.BusinessId);
                Assert.IsFalse(feedback.IsDeleted);
            }
        }
    }
}

            //contextOptions = new DbContextOptionsBuilder<SmartDormitoryContext>()
            //.UseInMemoryDatabase(databaseName: "Remove_Sensor_When_Exists_And_Is_Not_Deleted")
            //    .Options;

            //var sensor = SetupFakeSensor();

            //using (var actContext = new SmartDormitoryContext(contextOptions))
            //{
            //    await actContext.Sensors.AddAsync(sensor);
            //    await actContext.SaveChangesAsync();
            //}

            //// Act && Assert
            //using (var assertContext = new SmartDormitoryContext(contextOptions))
            //{
            //    var sut = new SensorsService(assertContext,
            //                    measureTypeServiceMock.Object);

            //    await sut.DeleteSensor(sensor.Id);
            //    var result = await assertContext.Sensors.FirstOrDefaultAsync(s => s.Id == sensor.Id);
            //    Assert.IsTrue(result.IsDeleted);
            //}
