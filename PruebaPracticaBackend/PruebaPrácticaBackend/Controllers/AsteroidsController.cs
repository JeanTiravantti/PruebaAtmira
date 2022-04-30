using Microsoft.AspNetCore.Mvc;
using PruebaPracticaBackend.Core.Interface;
using PruebaPracticaBackend.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaPracticaBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AsteroidsController : Controller
    {
        private INasaCore _nasaCore;

        public AsteroidsController(INasaCore nasaCore)
        {
            _nasaCore = nasaCore;
        }

        [HttpGet]
        public async Task<ActionResult> GetTop3ByPlanetName(string planet)
        {
            if (!string.IsNullOrEmpty(planet)) {
                List<NasaDTO> top3 = await _nasaCore.GetTop3Asteroids(planet);
                return Ok(top3);
            }
            else
                return Ok("El parámetro planet no puede ser vacío");
        }
    }
}
