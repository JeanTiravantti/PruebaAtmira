using PruebaPrácticaBackend.Model;
using PruebaPracticaBackend.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaPracticaBackend.Core.Interface
{
    public interface INasaCore
    {
        Task<Nasa> GetAllDataFromNASA();
        Task<List<NasaDTO>> GetTop3Asteroids(string planetName);
    }
}
