using DalProduit = ProductManager.Blazor.Dal.Entities.Produit;

using ProductManager.Blazor.Bll.Entities;

namespace ProductManager.Blazor.Bll.Mappers
{
    internal static partial class Mappers
    {
        internal static DalProduit ToDal(this Produit entity)
        {
            return new DalProduit()
            {
                Id = entity.Id,
                Nom = entity.Nom,
                Prix = entity.Prix
            };
        }

        internal static Produit ToBll(this DalProduit entity)
        {
            return new Produit(entity.Id, entity.Nom, entity.Prix);
        }
    }
}
