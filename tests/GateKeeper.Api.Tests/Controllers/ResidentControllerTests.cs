using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using GateKeeper.Api.Controllers;
using GateKeeper.Api.ViewModels;
using GateKeeper.Domain;
using GateKeeper.Domain.Entities;
using GateKeeper.Domain.Queries;
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
            var getResidentResult = await controller.GetAll(new ResidentQuery());
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

        [Test]
        public async Task Create_CreateResidentWithIncompleteData_ReturnsBadRquest()
        {
            // Arrange
            // _mockResidentRepository.Setup(repo => repo.Add(It.IsAny<Resident>()));

            var controller = new ResidentsController(_mockResidentRepository.Object,
                _mockUoW.Object, _mockMapper.Object);

            // Act
            var residentViewModel = new ResidentViewModel { Name = "John Cena" };
            var addResidentResult = await controller.Create(residentViewModel);

            // assert
            Assert.IsInstanceOf<BadRequestObjectResult>(addResidentResult);
            // var badRequestResult = addResidentResult as BadRequestObjectResult;
            // Assert.IsInstanceOf<SerializableError>(badRequestResult.Value);
        }

        [Test]
        public async Task Create_CreateResidentWithCompleteData_ReturnsOKResult()
        {
            // Arrange
            // _mockResidentRepository.Setup(repo => repo.Add(It.IsAny<Resident>()));

            var controller = new ResidentsController(_mockResidentRepository.Object,
                _mockUoW.Object, _mockMapper.Object);

            // Act
            var residentViewModel = new ResidentViewModel
            {
                Name = "John Cena",
                Email = "john.cena@gmail.com",
                Block = "B",
                Apartment = "301",
                Cpf = "3243141431"
            };

            var addResidentResult = await controller.Create(residentViewModel);
            var okResult = addResidentResult as OkObjectResult;
            // assert
            Assert.IsInstanceOf<OkObjectResult>(addResidentResult);
            Assert.IsInstanceOf<OkObjectResult>(okResult);
        }

        [Test]
        public async Task Delete_DeleteResident_DeleteResidentAndReturnsOKResult()
        {
            // Arrange
            var fakeResident = new Resident
            {
                Name = "John Cena",
                Email = "john.cena@gmail.com",
                Block = "B",
                Apartment = "301",
                Cpf = "3243141431"
            };
            _mockResidentRepository.Setup(repo => repo.GetAsync(It.IsAny<int>())).ReturnsAsync(fakeResident); ;

            var controller = new ResidentsController(_mockResidentRepository.Object,
                _mockUoW.Object, _mockMapper.Object);

            // Act
            var residentViewModel = new ResidentViewModel { Name = "John Cena" };
            var deleteResidentResult = await controller.Delete(2);

            // assert
            Assert.IsInstanceOf<OkObjectResult>(deleteResidentResult);
            Assert.AreEqual(true, fakeResident.Deleted);
        }

        [Test]
        public async Task Delete_DeleteNullResident_ReturnsBadRequest()
        {
            // Arrange
            _mockResidentRepository.Setup(repo => repo.GetAsync(It.IsAny<int>())).ReturnsAsync((Resident) null); ;

            var controller = new ResidentsController(_mockResidentRepository.Object,
                _mockUoW.Object, _mockMapper.Object);

            // Act
            var residentViewModel = new ResidentViewModel { Name = "John Cena" };
            var deleteResidentResult = await controller.Delete(2);

            // assert
            Assert.IsInstanceOf<BadRequestObjectResult>(deleteResidentResult);
        }


    }
}