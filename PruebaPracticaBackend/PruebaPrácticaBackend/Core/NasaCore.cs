using PruebaPracticaBackend.Core.Interface;
using PruebaPracticaBackend.Interface.AccessData;
using PruebaPrácticaBackend.Model;
using PruebaPracticaBackend.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaPracticaBackend.Core
{
    public class NasaCore : INasaCore
    {
        private IDBNasa _IDBNasa;

        public NasaCore(IDBNasa IDBNasa)
        {
            _IDBNasa = IDBNasa;
        }

        public async Task<Nasa> GetAllDataFromNASA()
        {
            return await _IDBNasa.GetAllDataFromNASA();
        }

        public async Task<List<NasaDTO>> GetTop3Asteroids(string planetName)
        {
            try
            {
                Nasa allNasa = await GetAllDataFromNASA();
                var a = allNasa.Near_earth_objects.SelectMany(x => x.Value.Where(y => y.Is_potentially_hazardous_asteroid == true)).ToList();

                List<NasaDTO> listOrderByDiametro = a.GroupBy(student => student.Name,
                    (Nombre, ListObjects) => new NasaDTO
                    {
                        Nombre = Nombre,
                        Diametro = ListObjects.Average(x => (x.Estimated_diameter.Kilometers.Estimated_diameter_max + x.Estimated_diameter.Kilometers.Estimated_diameter_min) / 2),
                        Velocidad = ListObjects.Where(x => x.Name == Nombre).FirstOrDefault().Close_approach_data[0].Relative_velocity.Kilometers_per_hour,
                        Fecha = ListObjects.Where(x => x.Name == Nombre).FirstOrDefault().Close_approach_data[0].Close_approach_date,
                        Planeta = ListObjects.Where(x => x.Name == Nombre).FirstOrDefault().Close_approach_data[0].Orbiting_body
                    })
                    .Where(y => y.Planeta.ToLower() == planetName.ToLower())
                    .OrderByDescending(studentAverage => studentAverage.Diametro).ToList();

                if (listOrderByDiametro.Count > 3)
                    return listOrderByDiametro.Take(3).ToList();
                else
                    return listOrderByDiametro;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
