using ProductManager.Blazor.Domain.Commands;
using ProductManager.Blazor.Domain.Entities;
using ProductManager.Blazor.Domain.Queries;
using ProductManager.Blazor.Domain.Repositories;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json;
using Tools.CommandQuerySeparation.Commands;
using Tools.CommandQuerySeparation.Queries;

namespace ProductManager.Blazor.Domain.Services
{
    public class ProduitService : IProduitRepository
    {
        private readonly HttpClient _httpClient;

        public ProduitService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Default");
        }

        public async Task<QueryResult<IEnumerable<Produit>>> Execute(ListeProduitQuery query)
        {
            try
            {
                using (HttpResponseMessage responseMessage = await _httpClient.GetAsync("api/produit"))
                {
                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        return QueryResult<IEnumerable<Produit>>.Failure($"Code de l'api : {(int)responseMessage.StatusCode}");
                    }

                    string json = await responseMessage.Content.ReadAsStringAsync();

                    Produit[]? produits = JsonSerializer.Deserialize<Produit[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    if (produits is null)
                        return QueryResult<IEnumerable<Produit>>.Success(Enumerable.Empty<Produit>());

                    return QueryResult<IEnumerable<Produit>>.Success(produits);
                }
            }
            catch (Exception ex)
            {

                return QueryResult<IEnumerable<Produit>>.Failure(ex.Message, ex);
            }
        }

        public async Task<QueryResult<Produit>> Execute(DetailProduitQuery query)
        {
            try
            {
                using (HttpResponseMessage responseMessage = await _httpClient.GetAsync($"api/produit/{query.Id}"))
                {
                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        return QueryResult<Produit>.Failure($"Code de l'api : {(int)responseMessage.StatusCode}");
                    }

                    string json = await responseMessage.Content.ReadAsStringAsync();

                    Produit produit = JsonSerializer.Deserialize<Produit>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;

                    return QueryResult<Produit>.Success(produit);
                }
            }
            catch (Exception ex)
            {

                return QueryResult<Produit>.Failure(ex.Message, ex);
            }
        }

        public async Task<CommandResult> Execute(AjoutProduitCommand command)
        {
            try
            {
                HttpContent httpContent = JsonContent.Create(command);

                using (HttpResponseMessage responseMessage = await _httpClient.PostAsync("api/produit", httpContent))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return CommandResult.Success();
                    }
                    return CommandResult.Failure($"Code de retour : {responseMessage.StatusCode}");
                }

            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex.Message, ex);
            }
        }

        public async Task<CommandResult> Execute(ModifierProduitCommand command)
        {
            try
            {
                HttpContent httpContent = JsonContent.Create(command);

                using (HttpResponseMessage responseMessage = await _httpClient.PutAsync($"api/produit", httpContent))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return CommandResult.Success();
                    }
                    return CommandResult.Failure($"Code de retour : {responseMessage.StatusCode}");
                }

            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex.Message, ex);
            }
        }

        public async Task<CommandResult> Execute(SupprimerProduitCommand command)
        {
            try
            {
                using (HttpResponseMessage responseMessage = await _httpClient.DeleteAsync($"api/produit/{command.Id}"))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return CommandResult.Success();
                    }
                        
                    return CommandResult.Failure($"Code de retour : {(int)responseMessage.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex.Message, ex);
            }
        }
    }
}
