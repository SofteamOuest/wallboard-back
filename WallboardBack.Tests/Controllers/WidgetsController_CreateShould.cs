using Microsoft.AspNetCore.Mvc;
using Moq;
using WallboardBack.Models;
using Xunit;

namespace WallboardBack.Tests.Controllers
{
    public class WidgetsController_CreateShould: WidgetsControllerUnitTest
    {
        [Fact]
        public void AddToDatabase()
        {
            var result = Controller.Create(new Widget());

            Database.Verify(db => db.Add(It.IsAny<Widget>()), Times.Once());
        }

        [Fact]
        public void RejectNullValue()
        {
            var result = Controller.Create(null);

            Assert.IsAssignableFrom<BadRequestResult>(result);
            Database.Verify(db => db.Add(It.IsAny<Widget>()), Times.Never());
        }
    }
}
