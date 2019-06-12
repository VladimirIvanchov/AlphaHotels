using AlphaHotel.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlphaHotel.Tests.Controllers.ErrorControllerTests
{
    [TestClass]
    public class PageNotFound_Should
    {
        [TestMethod]
        public void ReturnCorrectViewResult()
        {
            var errorController = new ErrorController();

            var result = errorController.PageNotFound() as ViewResult;

            Assert.AreEqual(result.ViewName, "PageNotFound");
        }
    }
}
