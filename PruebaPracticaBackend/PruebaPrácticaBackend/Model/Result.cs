using PruebaPracticaBackend.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaPracticaBackend.Model
{
    public class Result
    {
        public List<NasaDTO> Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
