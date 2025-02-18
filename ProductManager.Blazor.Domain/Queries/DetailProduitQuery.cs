using Tools.CommandQuerySeparation.Queries;
using ProductManager.Blazor.Domain.Entities;

namespace ProductManager.Blazor.Domain.Queries
{
    public class DetailProduitQuery : IQueryDefinition<Produit>
    {
        public int Id { get; }

        public DetailProduitQuery(int id)
        {
            Id = id;
        }
    }
}
