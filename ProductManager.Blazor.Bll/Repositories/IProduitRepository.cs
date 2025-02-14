using ProductManager.Blazor.Bll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Blazor.Bll.Repositories
{
    public interface IProduitRepository
    {
        Task<IEnumerable<Produit>> Get();
        Task<Produit?> Get(int id);
        Task<bool> Create(Produit produit);
        Task<bool> Update(int id, Produit produit);
        Task<bool> Delete(int id);
    }
}
