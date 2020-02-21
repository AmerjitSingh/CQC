using Microsoft.AspNetCore.Mvc;
using MvcGDSAssessment.Controllers;
using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;

public class HomeControllerTests
{
    [Test]
    public void FullName_ReturnsAViewResult_ForFullName()
    {
        // Arrange
        var mockRepo = new Mock<IHomeApplicationRepository>();
        var httpContext = new DefaultHttpContext();
        var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

        var controller = new HomeController(mockRepo.Object)
        {
            TempData = tempData
        };

        // Act
        var result = controller.FullName((int?)null);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        Assert.AreEqual(
            ((ViewResult)result).ViewName, "Fullname");

    }

    [Test]
    public void FullName_ReturnsARedirectToActionResult_WithValidFullName()
    {
        // Arrange
        var mockRepo = new Mock<IHomeApplicationRepository>();
        var httpContext = new DefaultHttpContext();
        var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

        tempData["CheckAnswers"] = 0;

        var controller = new HomeController(mockRepo.Object)
        {
            TempData = tempData
        };

        // Act
        var viewModel = new FullNameViewModel
        {
            FullName = "Joe Blogs"
        };

        var result = controller.FullName(viewModel);

        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        Assert.AreEqual(
            ((RedirectToActionResult)result).ActionName,
            "Email");

    }

    [Test]
    public void TestFullName_ReturnsAViewResult_ForFullNameError_WithModelStateError()
    {
        // Arrange
        var mockRepo = new Mock<IHomeApplicationRepository>();
        var httpContext = new DefaultHttpContext();
        var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

        tempData["CheckAnswers"] = 0;

        var controller = new HomeController(mockRepo.Object);
        controller.TempData = tempData;
        controller.ModelState.AddModelError("error", "error");

        // Act
        var viewModel = new FullNameViewModel
        {
            FullName = "Jo"
        };

        var result = controller.FullName(viewModel);

        // Assert
        Assert.AreEqual(
            ((ViewResult)result).ViewName, "FullNameError");

    }


    [Test]
    public void FullName_ReturnsARedirectToActionResult_WithValidFullName_ToCheckAnswers()
    {
        // Arrange
        var mockRepo = new Mock<IHomeApplicationRepository>();
        var httpContext = new DefaultHttpContext();
        var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

        tempData["CheckAnswers"] = 1;

        var controller = new HomeController(mockRepo.Object);
        controller.TempData = tempData;

        // Act
        var viewModel = new FullNameViewModel
        {
            FullName = "Jo"
        };

        var result = controller.FullName(viewModel);

        // Assert
        Assert.AreEqual(
            ((RedirectToActionResult)result).ActionName,
            "CheckAnswers");

    }
}



