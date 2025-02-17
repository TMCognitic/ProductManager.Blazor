using CommandQuerySeparation.Queries;
using ProductManager.Blazor.Domain.Entities;

namespace ProductManager.Blazor.Domain.Queries
{
    public class ListeProduitQuery : IQueryDefinition<IEnumerable<Produit>>
    {
    }
}
