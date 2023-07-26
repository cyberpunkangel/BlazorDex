using BlazorPokedex.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPokedex.Services
{
    public class PokeApiClient : IPokeApiClient
    {
        private readonly HttpClient _httpClient;
        public PokeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResultObject> GetAllPokemons(PaginationParameters parameters)
        {
            return JsonConvert.DeserializeObject<ResultObject>(
                 await _httpClient.GetStringAsync($"pokemon?limit={parameters.PageSize}&offset={parameters.Offset}"));
        }

        public async Task<Pokemon> GetPokemon(string name)
        {
            return JsonConvert.DeserializeObject<Pokemon>(
                await _httpClient.GetStringAsync($"pokemon/{name}"));
        }
    }
}
