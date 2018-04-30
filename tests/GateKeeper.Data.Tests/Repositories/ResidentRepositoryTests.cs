using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GateKeeper.Data.Context;
using GateKeeper.Data.Repositories;
using GateKeeper.Domain.Entities;
using GateKeeper.Domain.Queries;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace GateKeeper.Data.Tests.Repositories
{
    [TestFixture]
    public class ResidentRepositoryTests
    {
        private Mock<GateKeeperDbContext> _dbContextMock;

        public ResidentRepositoryTests()
        {
            _dbContextMock = new Mock<GateKeeperDbContext>();

            var mockDbSet = GetQueryableMockDbSet(
                new Resident { Name = "Resident A" },
                new Resident { Name = "Resident B" });

            _dbContextMock.Setup(x => x.Set<Resident>()).Returns(mockDbSet);
        }

        [Test]
        [Ignore("Must implement proper dbset mock")]
        public async Task Repositry_GetAllAsync_ReturnResidents()
        {
            var repository = new ResidentRepository(_dbContextMock.Object);

            var residents = await repository.GetAllAsync(new ResidentQuery());
        }

        [Test]
        public void Repositry_AddResident_CallsDbSet()
        {
            var repository = new ResidentRepository(_dbContextMock.Object);
            repository.Add(new Resident());
            _dbContextMock.Verify(x => x.Set<Resident>(), Times.Once);

        }

        private static DbSet<T> GetQueryableMockDbSet<T>(params T[] sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            return dbSet.Object;
        }
    }
}