using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PruebaPracticaBackend.Controllers;
using PruebaPracticaBackend.Core.Interface;
using PruebaPracticaBackend.Interface.AccessData;
using PruebaPracticaBackend.Model;
using PruebaPracticaBackend.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PruebaPracticaBackend.Test
{
    public class AsteroidsTest
    {
        private readonly List<NasaDTO> _collection;

        public AsteroidsTest()
        {
            _collection = new List<NasaDTO>()
            {
                new NasaDTO() { Nombre = "(2009 FU4)", Diametro = 1.1845205970m, Velocidad = 84543.6535280932m, Fecha =  DateTime.Parse("2020-09-09T00:00:00"), Planeta = "Earth"},
                new NasaDTO() { Nombre = "(2003 BK47)", Diametro = 1.1845205970m, Velocidad = 56925.3589156318m, Fecha =  DateTime.Parse("2020-09-14T00:00:00"), Planeta = "Earth"},
                new NasaDTO() { Nombre = "65909 (1998 FH12)", Diametro = 0.58822383305m, Velocidad = 64169.6113983391m, Fecha =  DateTime.Parse("2020-09-14T00:00:00"), Planeta = "Earth"},
            };
        }

        [Fact]
        public async void GetTop3Earth()
        {
            string planet = "Earth";

            //Arrange
            var mock = new Mock<INasaCore>();

            mock.Setup(x => x.GetTop3Asteroids(planet)).ReturnsAsync(_collection);

            INasaCore repository = mock.Object;
            AsteroidsController controller = new AsteroidsController(repository);

            //Act
            var result = await controller.GetTop3ByPlanetName(planet);

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var item = Assert.IsAssignableFrom<IEnumerable<NasaDTO>>(objectResult.Value);

            Assert.Equal(3, ((List<NasaDTO>)item).Count);
        }


        [Fact]
        public async void ErrorMessageEmptyPlanet()
        {
            string planet = string.Empty;

            //Arrange
            var mock = new Mock<INasaCore>();

            mock.Setup(x => x.GetTop3Asteroids(planet)).ReturnsAsync(_collection);

            INasaCore repository = mock.Object;
            AsteroidsController controller = new AsteroidsController(repository);

            //Act
            var result = await controller.GetTop3ByPlanetName(planet);

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var item = Assert.IsAssignableFrom<string>(objectResult.Value);

            Assert.Equal("El parámetro planet no puede ser vacío", item);
        }
    }
}
