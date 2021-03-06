﻿using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace WallboardBack.Tests.Helpers
{
    internal class DbSetMock<T> where T : class, new()
    {
        public Mock<DbSet<T>> Moq { get; private set; } 

        public DbSetMock(IEnumerable<T> list)
        {
            Moq = CreateMock(list);
        }

        private Mock<DbSet<T>> CreateMock(IEnumerable<T> list)
        {
            IQueryable<T> queryableList = list.AsQueryable();
            Mock<DbSet<T>> dbSetMock = new Mock<DbSet<T>>();
            dbSetMock.As<IQueryable<T>>().Setup(x => x.Provider).Returns(queryableList.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.Expression).Returns(queryableList.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(queryableList.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(() => queryableList.GetEnumerator());
            // dbSetMock.Setup(x => x.Create()).Returns(new T());

            return dbSetMock;
        }
    }
}
