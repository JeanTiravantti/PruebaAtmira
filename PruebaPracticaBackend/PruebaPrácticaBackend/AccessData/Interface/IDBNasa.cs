using PruebaPrácticaBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaPracticaBackend.Interface.AccessData
{
    public interface IDBNasa
    {
        Task<Nasa> GetAllDataFromNASA();
    }
}
