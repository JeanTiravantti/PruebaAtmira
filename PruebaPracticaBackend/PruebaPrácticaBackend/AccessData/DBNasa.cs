using Newtonsoft.Json;
using PruebaPracticaBackend.Interface.AccessData;
using PruebaPrácticaBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PruebaPracticaBackend.AccessData
{
    public class DBNasa : IDBNasa
    {
        public async Task<Nasa> GetAllDataFromNASA()
        {
            Nasa response;

            try
            {             

                using (HttpClient client = new HttpClient())
                {
                    string url = "https://api.nasa.gov/neo/rest/v1/feed?start_date=2020-09-09&end_date=2020-09-16&api_key=zdUP8ElJv1cehFM0rsZVSQN7uBVxlDnu4diHlLSb";

                    HttpResponseMessage result = await client.GetAsync(url);
                    _ = result.EnsureSuccessStatusCode();

                    if (result.IsSuccessStatusCode)
                    {
                        string body = await result.Content.ReadAsStringAsync();
                        response = JsonConvert.DeserializeObject<Nasa>(body);
                    }
                    else
                        response = null;
                }
            }
            catch (Exception ex)
            {
                response = null;
            }

            return response;
        }
    }
}
