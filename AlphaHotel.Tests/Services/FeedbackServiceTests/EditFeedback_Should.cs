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
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.PagingProvider;
using AlphaHotel.Services.Utilities;
using AlphaHotel.Infrastructure.Censorship;
using Microsoft.EntityFrameworkCore;

namespace AlphaHotel.Tests.Services.FeedbackServiceTests
{
    [TestClass]
    public class EditFeedback_Should
    {
        [TestMethod]
        public async Task ThrowException_WhenFeedbackIsNotFound()
        {
            var text = "text";
            var author = "gosho";
            var rating = 5;
            var businessId = 1;
            var isDeleted = false;
            var feedbackId = 1;
            var wrongFeedbackId = 2;
            var paginatedListMocked = new Mock<IPaginatedList<FeedbackDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var censorMocked = new Mock<ICensor>();

            FeedbackTestUtils.GetContextWithFullFeedback(nameof(ThrowException_WhenFeedbackIsNotFound), text, rating, author, businessId, feedbackId);

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(ThrowException_WhenFeedbackIsNotFound))))
            {
                var feedbackService = new FeedbackService(assertContext, paginatedListMocked.Object, dateTimeWrapperMocked.Object, censorMocked.Object);

                await Assert.ThrowsExceptionAsync<ArgumentException>(
                    async () => await feedbackService.EditFeedback(wrongFeedbackId, author, text, rating, isDeleted));
            }
        }
        
        [TestMethod]
        public async Task Return_WhenFeedbackIsDeleted()
        {
            var text = "text";
            var author = "gosho";
            var rating = 5;

            var editedText = "new text";
            var editedAuthor = "pesho";
            var editedRating = 4; 
            var isDeleted = true;

            var businessId = 1;
            var feedbackId = 1;

            var paginatedListMocked = new Mock<IPaginatedList<FeedbackDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var censorMocked = new Mock<ICensor>();

            FeedbackTestUtils.GetContextWithFullFeedback(nameof(Return_WhenFeedbackIsDeleted), text, rating, author, businessId, feedbackId);

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(Return_WhenFeedbackIsDeleted))))
            {
                var feedbackService = new FeedbackService(assertContext, paginatedListMocked.Object, dateTimeWrapperMocked.Object, censorMocked.Object);
                await feedbackService.EditFeedback(feedbackId, editedAuthor, editedText, editedRating, isDeleted);

                var feedback = await assertContext.Feedbacks.FirstOrDefaultAsync(f => f.Id == feedbackId);

                Assert.AreEqual(editedText, feedback.Text);
                Assert.AreEqual(editedRating, feedback.Rate);
                Assert.AreEqual(editedAuthor, feedback.Author);
                Assert.AreEqual(feedback.DeletedOn, dateTimeWrapperMocked.Object.Now());
                Assert.IsTrue(feedback.IsDeleted);
                Assert.AreEqual(feedback.ModifiedOn, dateTimeWrapperMocked.Object.Now());
            }
        }

        [TestMethod]
        public async Task Return_WhenFeedbackIsNotDeleted()
        {
            var text = "text";
            var author = "gosho";
            var rating = 5;

            var editedText = "new text";
            var editedAuthor = "pesho";
            var editedRating = 4;
            var isDeleted = false;

            var businessId = 1;
            var feedbackId = 1;

            var paginatedListMocked = new Mock<IPaginatedList<FeedbackDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var censorMocked = new Mock<ICensor>();

            FeedbackTestUtils.GetContextWithFullFeedback(nameof(Return_WhenFeedbackIsNotDeleted), text, rating, author, businessId, feedbackId);

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(Return_WhenFeedbackIsNotDeleted))))
            {
                var feedbackService = new FeedbackService(assertContext, paginatedListMocked.Object, dateTimeWrapperMocked.Object, censorMocked.Object);
                await feedbackService.EditFeedback(feedbackId, editedAuthor, editedText, editedRating, isDeleted);

                var feedback = await assertContext.Feedbacks.FirstOrDefaultAsync(f => f.Id == feedbackId);

                Assert.AreEqual(editedText, feedback.Text);
                Assert.AreEqual(editedRating, feedback.Rate);
                Assert.AreEqual(editedAuthor, feedback.Author);
                Assert.IsFalse(feedback.IsDeleted);
                Assert.AreEqual(feedback.ModifiedOn, dateTimeWrapperMocked.Object.Now());
            }
        }
    }
}
