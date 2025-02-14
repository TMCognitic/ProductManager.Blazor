using ProductManager.Blazor.Dal.Entities;

namespace ProductManager.Blazor.Dal.Repositories
{
    public interface IProduitRepository
    {
        Task<IEnumerable<Produit>> Get();
        Task<Produit?> Get(int id);
        Task<bool> Create(Produit produit);
        Task<bool> Update(Produit produit);
        Task<bool> Delete(int id);
    }
}
