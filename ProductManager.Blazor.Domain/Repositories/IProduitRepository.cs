using CommandQuerySeparation.Commands;
using CommandQuerySeparation.Queries;
using ProductManager.Blazor.Domain.Commands;
using ProductManager.Blazor.Domain.Entities;
using ProductManager.Blazor.Domain.Queries;

namespace ProductManager.Blazor.Domain.Repositories
{
    public interface IProduitRepository :
        IQueryAsyncHandler<ListeProduitQuery, IEnumerable<Produit>>,
        IQueryAsyncHandler<DetailProduitQuery, Produit>,
        ICommandAsyncHandler<AjoutProduitCommand>,
        ICommandAsyncHandler<ModifierProduitCommand>,
        ICommandAsyncHandler<SupprimerProduitCommand>
    {
    }
}
