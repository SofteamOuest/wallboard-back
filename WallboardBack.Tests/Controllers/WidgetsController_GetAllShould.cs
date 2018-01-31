using System.Collections.Generic;
using Xunit;
using Moq;
using WallboardBack.Controllers;
using WallboardBack.Models;
using WallboardBack.Tests.Helpers;

namespace WallboardBack.Tests.Controllers
{
    public class WidgetsController_GetAllShould
    {
        private readonly WidgetsController _controller;

        public WidgetsController_GetAllShould() {
            _controller = new WidgetsController(MockWallboardContext());
        }

        private IWallboardContext MockWallboardContext()
        {
            var widgetsDbSet = new DbSetMock<Widget>(new List<Widget>());

            var dbContext = new Mock<IWallboardContext>();
            dbContext.Setup(m => m.Widgets).Returns(widgetsDbSet.Object);

            return dbContext.Object;
        }

        [Fact]
        public void ReturnAnEnumerable()
        {
            var result = _controller.GetAll();
            Assert.IsAssignableFrom<IEnumerable<Widget>>(result);
        }
    }
}
