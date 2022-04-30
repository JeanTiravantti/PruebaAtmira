using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaPracticaBackend.Model.DTO
{
    public class NasaDTO
    {
        public string Nombre { get; set; }
        public decimal Diametro { get; set; }
        public decimal Velocidad { get; set; }
        public DateTime Fecha { get; set; }
        public string Planeta { get; set; }
    }
}
