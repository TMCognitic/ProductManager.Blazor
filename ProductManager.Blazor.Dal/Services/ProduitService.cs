using ProductManager.Blazor.Dal.Entities;
using ProductManager.Blazor.Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductManager.Blazor.Dal.Services
{
    public class ProduitService : IProduitRepository
    {
        private readonly HttpClient _httpClient;

        public ProduitService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Default");
        }

        public async Task<bool> Create(Produit produit)
        {
            HttpContent httpContent = JsonContent.Create(new { produit.Nom, produit.Prix });

            using (HttpResponseMessage responseMessage = await _httpClient.PostAsync("api/produit", httpContent))
            {
                return responseMessage.IsSuccessStatusCode;
            }
        }

        public async Task<IEnumerable<Produit>> Get()
        {
            using (HttpResponseMessage responseMessage = await _httpClient.GetAsync("api/produit"))
            {
                responseMessage.EnsureSuccessStatusCode();

                string json = await responseMessage.Content.ReadAsStringAsync();

                Produit[]? produits = JsonSerializer.Deserialize<Produit[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                if(produits is null)
                    return Enumerable.Empty<Produit>();

                return produits;
            }
        }

        public async Task<Produit?> Get(int id)
        {
            using (HttpResponseMessage responseMessage = await _httpClient.GetAsync($"api/produit/{id}"))
            {
                if(!responseMessage.IsSuccessStatusCode)
                {
                    return null;
                }

                string json = await responseMessage.Content.ReadAsStringAsync();

                Produit produit = JsonSerializer.Deserialize<Produit>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;

                return produit;
            }
        }

        public async Task<bool> Update(Produit produit)
        {
            HttpContent httpContent = JsonContent.Create(new { produit.Nom, produit.Prix });

            using (HttpResponseMessage responseMessage = await _httpClient.PutAsync($"api/produit/{produit.Id}", httpContent))
            {
                return responseMessage.IsSuccessStatusCode;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (HttpResponseMessage responseMessage = await _httpClient.DeleteAsync($"api/produit/{id}"))
            {
                return responseMessage.IsSuccessStatusCode;
            }
        }
    }
}
