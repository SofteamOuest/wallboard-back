using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using WallboardBack.Controllers;
using WallboardBack.Models;
using WallboardBack.Tests.Helpers;

namespace WallboardBack.Tests.Controllers
{
    public class WidgetsControllerUnitTest
    {
        private readonly DbSetMock<Widget> _dbSet;

        private readonly WidgetsController _controller;

        protected Mock<DbSet<Widget>> Database => _dbSet.Moq;

        protected WidgetsController Controller => _controller;

        protected WidgetsControllerUnitTest()
        {
            _dbSet = new DbSetMock<Widget>(new List<Widget>());
            _controller = new WidgetsController(MockWallboardContext());
        }

        private WallboardContext MockWallboardContext()
        {
            var dbContext = new Mock<WallboardContext>();
            dbContext.Setup(m => m.Widgets).Returns(Database.Object);

            return dbContext.Object;
        }


    }
}