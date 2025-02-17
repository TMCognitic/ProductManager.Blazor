using ProductManager.Blazor.Domain.Commands;
using ProductManager.Blazor.Domain.Entities;
using ProductManager.Blazor.Domain.Queries;
using ProductManager.Blazor.Domain.Repositories;
using System.Net.Http.Json;
using System.Text.Json;

namespace ProductManager.Blazor.Domain.Services
{
    public class ProduitService : IProduitRepository
    {
        private readonly HttpClient _httpClient;

        public ProduitService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Default");
        }

        public async Task<IEnumerable<Produit>> Execute(ListeProduitQuery query)
        {
            using (HttpResponseMessage responseMessage = await _httpClient.GetAsync("api/produit"))
            {
                responseMessage.EnsureSuccessStatusCode();

                string json = await responseMessage.Content.ReadAsStringAsync();

                Produit[]? produits = JsonSerializer.Deserialize<Produit[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                if (produits is null)
                    return Enumerable.Empty<Produit>();

                return produits;
            }
        }

        public async Task<Produit?> Execute(DetailProduitQuery query)
        {
            using (HttpResponseMessage responseMessage = await _httpClient.GetAsync($"api/produit/{query.Id}"))
            {
                if (!responseMessage.IsSuccessStatusCode)
                {
                    return null;
                }

                string json = await responseMessage.Content.ReadAsStringAsync();

                Produit produit = JsonSerializer.Deserialize<Produit>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;

                return produit;
            }
        }

        public async Task<bool> Execute(AjoutProduitCommand command)
        {
            HttpContent httpContent = JsonContent.Create(command);

            using (HttpResponseMessage responseMessage = await _httpClient.PostAsync("api/produit", httpContent))
            {
                return responseMessage.IsSuccessStatusCode;
            }
        }

        public async Task<bool> Execute(ModifierProduitCommand command)
        {
            HttpContent httpContent = JsonContent.Create(command);

            using (HttpResponseMessage responseMessage = await _httpClient.PutAsync($"api/produit", httpContent))
            {
                return responseMessage.IsSuccessStatusCode;
            }
        }

        public async Task<bool> Execute(SupprimerProduitCommand command)
        {
            using (HttpResponseMessage responseMessage = await _httpClient.DeleteAsync($"api/produit/{command.Id}"))
            {
                return responseMessage.IsSuccessStatusCode;
            }
        }
    }
}
