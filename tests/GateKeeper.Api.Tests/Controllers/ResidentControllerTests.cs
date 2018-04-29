using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using GateKeeper.Api.Controllers;
using GateKeeper.Domain;
using GateKeeper.Domain.Entities;
using GateKeeper.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace GateKeeper.Api.Tests
{
    [TestFixture]
    public class ResidentsControllerTests
    {
        private Mock<IResidentRepository> _mockResidentRepository;
        private Mock<IUnitOfWork> _mockUoW;
        private Mock<IMapper> _mockMapper;


        public ResidentsControllerTests()
        {
            _mockResidentRepository = new Mock<IResidentRepository>();
            _mockUoW = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
        }

        [Test]
        public async Task GetAll_ReturnListOfResidents()
        {
            // Arrange
            _mockResidentRepository.Setup(repo => repo.GetAllAsync(It.IsAny<Expression<Func<Resident, bool>>>()))
                .ReturnsAsync(new List<Resident> { new Resident() });

            var controller = new ResidentsController(_mockResidentRepository.Object,
                _mockUoW.Object, _mockMapper.Object);


            // Act
            var getResidentResult = await controller.GetAll();
            var okResult = getResidentResult as OkObjectResult;

            // assert
            Assert.IsInstanceOf<OkObjectResult>(getResidentResult);
            Assert.IsInstanceOf<OkObjectResult>(okResult);
        }

        [Test]
        public async Task Get_ReturnsSingleResident()
        {
            // Arrange
            _mockResidentRepository.Setup(repo => repo.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(new Resident());

            var controller = new ResidentsController(_mockResidentRepository.Object,
                _mockUoW.Object, _mockMapper.Object);

            // Act
            var getResidentResult = await controller.Get(2);
            var okResult = getResidentResult as OkObjectResult;
            // assert
            Assert.IsInstanceOf<OkObjectResult>(getResidentResult);
            Assert.IsInstanceOf<OkObjectResult>(okResult);
        }


    }
}