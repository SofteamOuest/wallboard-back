using System.Collections.Generic;
using Xunit;
using WallboardBack.Models;

namespace WallboardBack.Tests.Controllers
{
    public class WidgetsController_GetAllShould : WidgetsControllerUnitTest
    {
        [Fact]
        public void ReturnAnEnumerable()
        {
            var result = Controller.GetAll();
            Assert.IsAssignableFrom<IEnumerable<Widget>>(result);
        }
    }
}
