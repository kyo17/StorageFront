using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Interfaces;
using Models;
using Newtonsoft.Json;

namespace Services
{
    public class CatalogoService : ICatalogo
    {
        private HttpClient http;

        public CatalogoService(HttpClient client)
        {
            http = client;
        }

        public async Task<IEnumerable<Catalogo>> getAll()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Catalogo>>(
                await http.GetStringAsync($"api/catalogo"));
        }

        public async Task<Catalogo> getOne(string id)
        {

              return JsonConvert.DeserializeObject<Catalogo>(
              await http.GetStringAsync($"api/catalogo/{id}"));
            /*
            return await System.Text.Json.JsonSerializer.DeserializeAsync<Catalogo>
                (await http.GetStreamAsync($"api/catalogo/{id}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true});
            */

        }

        public async Task remove(string id)
        {
            await http.DeleteAsync($"api/catalogo/{id}");
        }

        public async Task save(Catalogo catalogo)
        {
            var json = new StringContent(JsonConvert.SerializeObject(catalogo),
                Encoding.UTF8, "application/json");
            /*
            if (!string.IsNullOrEmpty(catalogo.Id))
            {
                await http.PutAsync($"api/catalogo/{catalogo.Id}", json);
            }
            else
            {
                await http.PostAsync("api/catalogo/", json);
            }
          */
            await http.PostAsync("api/catalogo/", json);
        }
    }
}
