using DalProduit = ProductManager.Blazor.Dal.Entities.Produit;
using IDalProduitRepository = ProductManager.Blazor.Dal.Repositories.IProduitRepository;

using ProductManager.Blazor.Bll.Entities;
using ProductManager.Blazor.Bll.Repositories;
using ProductManager.Blazor.Bll.Mappers;

namespace ProductManager.Blazor.Bll.Services
{
    public class ProduitService : IProduitRepository
    {
        private readonly IDalProduitRepository _dalProduitRepository;

        public ProduitService(IDalProduitRepository dalProduitRepository)
        {
            _dalProduitRepository = dalProduitRepository;
        }

        public async Task<bool> Create(Produit produit)
        {
            return await _dalProduitRepository.Create(produit.ToDal());
        }

        public async Task<IEnumerable<Produit>> Get()
        {
            IEnumerable<DalProduit> produits = await _dalProduitRepository.Get();
            return produits.Select(p => p.ToBll());
        }

        public async Task<Produit?> Get(int id)
        {
            DalProduit? produit = await _dalProduitRepository.Get(id);
            return produit?.ToBll();
        }

        public async Task<bool> Update(int id, Produit entity)
        {
            DalProduit? produit = entity.ToDal();
            produit.Id = id;

            return await _dalProduitRepository.Update(produit);
        }

        public async Task<bool> Delete(int id)
        {
            return await _dalProduitRepository.Delete(id);
        }
    }
}
