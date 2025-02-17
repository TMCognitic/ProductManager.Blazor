using CommandQuerySeparation.Commands;
using CommandQuerySeparation.Queries;
using ProductManager.Blazor.Domain.Commands;
using ProductManager.Blazor.Domain.Entities;
using ProductManager.Blazor.Domain.Queries;

namespace ProductManager.Blazor.Domain.Repositories
{
    public interface IProduitRepository :
        IQueryHandlerAsync<ListeProduitQuery, IEnumerable<Produit>>,
        IQueryHandlerAsync<DetailProduitQuery, Produit?>,
        ICommandHandlerAsync<AjoutProduitCommand>,
        ICommandHandlerAsync<ModifierProduitCommand>,
        ICommandHandlerAsync<SupprimerProduitCommand>
    {
    }
}
