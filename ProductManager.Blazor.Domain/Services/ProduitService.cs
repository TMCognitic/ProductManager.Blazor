using CommandQuerySeparation.Results;
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

        public async Task<Result<IEnumerable<Produit>>> ExecuteAsync(ListeProduitQuery query)
        {
            try
            {
                using (HttpResponseMessage responseMessage = await _httpClient.GetAsync("api/produit"))
                {
                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        return Result<IEnumerable<Produit>>.Failure($"Code de l'api : {(int)responseMessage.StatusCode}");
                    }

                    string json = await responseMessage.Content.ReadAsStringAsync();

                    Produit[]? produits = JsonSerializer.Deserialize<Produit[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    if (produits is null)
                        return Result<IEnumerable<Produit>>.Success(Enumerable.Empty<Produit>());

                    return Result<IEnumerable<Produit>>.Success(produits);
                }
            }
            catch (Exception ex)
            {

                return Result<IEnumerable<Produit>>.Failure(ex.Message, ex);
            }
        }

        public async Task<Result<Produit>> ExecuteAsync(DetailProduitQuery query)
        {
            try
            {
                using (HttpResponseMessage responseMessage = await _httpClient.GetAsync($"api/produit/{query.Id}"))
                {
                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        return Result<Produit>.Failure($"Code de l'api : {(int)responseMessage.StatusCode}");
                    }

                    string json = await responseMessage.Content.ReadAsStringAsync();

                    Produit produit = JsonSerializer.Deserialize<Produit>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;

                    return Result<Produit>.Success(produit);
                }
            }
            catch (Exception ex)
            {
                return Result<Produit>.Failure(ex.Message, ex);
            }
        }

        public async Task<Result> ExecuteAsync(AjoutProduitCommand command)
        {
            try
            {
                HttpContent httpContent = JsonContent.Create(command);

                using (HttpResponseMessage responseMessage = await _httpClient.PostAsync("api/produit", httpContent))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return Result.Success();
                    }
                    return Result.Failure($"Code de retour : {responseMessage.StatusCode}");
                }

            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message, ex);
            }
        }

        public async Task<Result> ExecuteAsync(ModifierProduitCommand command)
        {
            try
            {
                HttpContent httpContent = JsonContent.Create(command);

                using (HttpResponseMessage responseMessage = await _httpClient.PutAsync($"api/produit", httpContent))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return Result.Success();
                    }
                    return Result.Failure($"Code de retour : {responseMessage.StatusCode}");
                }

            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message, ex);
            }
        }

        public async Task<Result> ExecuteAsync(SupprimerProduitCommand command)
        {
            try
            {
                using (HttpResponseMessage responseMessage = await _httpClient.DeleteAsync($"api/produit/{command.Id}"))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return Result.Success();
                    }
                        
                    return Result.Failure($"Code de retour : {(int)responseMessage.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message, ex);
            }
        }
    }
}
